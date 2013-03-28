using Gnome;
using Gdk;
using Gtk;
using System;

class PopupMenu: Menu {

	private AccelGroup accelGroup;
	private ConfigReader config;

	public PopupMenu (AccelGroup accelGroup, ConfigReader config)
	{
		this.accelGroup = accelGroup;
		this.config = config;
		AddPreferencesItem ();
		AddAboutItem ();
		AddQuitItem ();
	}
	
	private void AddPreferencesItem ()
	{
		MenuItem item = new ImageMenuItem (Gtk.Stock.Preferences, accelGroup);
		item.Activated += OnPreferencesActivated;
		item.Show ();
		this.Append (item);
	}
	
	private void AddAboutItem ()
	{
		MenuItem item = new ImageMenuItem (Gnome.Stock.About, accelGroup);
		item.Activated += OnAboutActivated;
		item.Show ();
		this.Append (item);
	}
	
	private void AddQuitItem ()
	{
		MenuItem item = new SeparatorMenuItem ();
		item.Show (); 
		this.Append (item);
		item = new ImageMenuItem (Gtk.Stock.Quit, accelGroup);
		item.Activated += OnQuitActivated;
		item.Show ();
		this.Append (item);
	}
	
	private void OnPreferencesActivated (object o, EventArgs args)
	{
		PreferencesDialog dialog = new PreferencesDialog (config);
		dialog.Run ();
	}

	private void OnAboutActivated (object o, EventArgs args)
	{
		string [] authors = { "Graham Ashton <ashtong@users.sourceforge.net>" };
		string [] documenters = {};
		Pixbuf logo = new Pixbuf (null, "spamtrainer.png");
		About about = new About (
			"Spam Trainer", 
			Constants.VERSION,
			"Copyright \xa9 2004-2007 Graham Ashton",
			"A spam filter training program for GNOME",
			authors,
			documenters,
			null,
			logo);
		about.SetIconFromFile (Constants.PIXMAPSDIR + "/" + Constants.ICONFILE);
		about.Show ();
	}
	
	private void OnQuitActivated (object o, EventArgs args)
	{
		Application.Quit ();
	}
}
