using System;
using System.Diagnostics;
using System.Text;
using Gdk;
using Gtk;

public class MainWindow : Gtk.Window {

	private AccelGroup accelGroup;
	private ConfigReader config; 
	private MessageTrainer trainer;
	private static int SPACING = 12;
	private static Gtk.TargetEntry [] drag_targets =
		new TargetEntry [] { new TargetEntry ("text/uri-list", 0, 0) };
	private static Tooltips toolTips = new Tooltips ();
			
	public MainWindow (ConfigReader config, MessageTrainer trainer) : 
		base ("Spam Trainer")
	{
		this.config = config;
		this.trainer = trainer;
		this.accelGroup = new AccelGroup ();
		this.AllowGrow = false;
		this.ButtonPressEvent += new ButtonPressEventHandler (OnButtonPress);
		this.DeleteEvent += new DeleteEventHandler (OnMyWindowDelete);
		this.Add (this.SetupContents());
		this.SetIconFromFile (Constants.PIXMAPSDIR + "/" + Constants.ICONFILE);
		this.ShowAll ();
	}
	
	private Gtk.Widget WrapImage (String filename, String tipWord)
	{
		Pixbuf buf = new Pixbuf (null, filename);
		Gtk.Image image = new Gtk.Image (buf);
		Alignment alignment = new Alignment(0, 0, 0, 0);
		alignment.BorderWidth = (uint) SPACING;
		alignment.Add (image);
		EventBox ebox = new EventBox ();
		ebox.Add (alignment);
		Frame frame = new Frame ();
		Color white = new Color (0xff, 0xff, 0xff);
		ebox.ModifyBg (StateType.Normal, white);
		String tipText = "Drop \"{0}\" messages here. " +
			"Right click to change preferences.";
		toolTips.SetTip (ebox, String.Format (tipText, tipWord), null);
		frame.ShadowType = ShadowType.In;
		frame.Add (ebox);
		return frame;
	}
	
	private Gtk.Widget SetupHamGraphic ()
	{
		Gtk.Widget ham = WrapImage ("ham.png", "ham");
		Gtk.Drag.DestSet (ham, DestDefaults.All, drag_targets,
			Gdk.DragAction.Copy);
		ham.DragDataReceived += OnHamDragDataReceived;
		return ham;
	}
	
	private Gtk.Widget SetupSpamGraphic ()
	{
		Gtk.Widget spam = WrapImage ("spam.png", "spam");
		Gtk.Drag.DestSet (spam, DestDefaults.All, drag_targets,
			Gdk.DragAction.Copy);
		spam.DragDataReceived += OnSpamDragDataReceived;
		return spam;
	}
	
	private Widget SetupContents ()
	{
		HBox hbox = new HBox ();
		hbox.BorderWidth = (uint) SPACING;
		hbox.Spacing = SPACING;
		hbox.Add (SetupHamGraphic ());
		hbox.Add (SetupSpamGraphic ());
		EventBox ebox = new EventBox ();
		ebox.Add (hbox);
		return ebox;
	}

	private void DisplayErrorDialog ()
	{
		ErrorDialog dialog = new ErrorDialog (
			"Error encountered during training",
			"There was an error running the command. " +
			"Please check the preferences (right click in the main " +
			"window and select the Preferences menu item) and try again.");
		dialog.Run ();
	}

	// TODO: replace two drag event handlers with one
	// Connect the creation of the event box to the realize event to get
	// it's GdkWindow, stuff a spam/ham identifier into it's UserData and 
	// then pull it back out of args.Context.DestWindow.
	void OnHamDragDataReceived (object o, DragDataReceivedArgs args)
	{
		bool success = false;
		string uriString = Encoding.UTF8.GetString (args.SelectionData.Data);

		// evo 2.0 passes file:////path/to/file, which breaks uri.LocalPath
		uriString = uriString.Replace ("////", "///");
		
		Uri uri = new Uri (uriString);
		if (uri.Scheme == Uri.UriSchemeFile) {
			success = this.trainer.TrainAsHam (uri.LocalPath.Trim ());
			if (success == false)
			{
				DisplayErrorDialog ();
			}
		}
		Gtk.Drag.Finish (args.Context, success, false, args.Time);
	}
	
	void OnSpamDragDataReceived (object o, DragDataReceivedArgs args)
	{
		bool success = false;
		string uriString = Encoding.UTF8.GetString (args.SelectionData.Data);

		// evo 2.0 passes file:////path/to/file, which breaks uri.LocalPath
		uriString = uriString.Replace ("////", "///");
		
		Uri uri = new Uri (uriString);
		if (uri.Scheme == Uri.UriSchemeFile) {
			success = this.trainer.TrainAsSpam (uri.LocalPath.Trim ());
			if (success == false)
			{
				DisplayErrorDialog ();
			}
		}
		Gtk.Drag.Finish (args.Context, success, false, args.Time);
	}

	void OnButtonPress (object o, ButtonPressEventArgs args)
	{
		int rightButton = 3;
		if (args.Event.Button == rightButton) {
		    PopupMenu menu = new PopupMenu (accelGroup, config);
		    menu.Popup ();
		}
	}	
			
	void OnMyWindowDelete (object o, DeleteEventArgs args)
	{
		Application.Quit ();
	}
}
