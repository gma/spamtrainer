using Gtk;
using Glade;
using System;

public class ErrorDialog
{
	[Widget] private Dialog error;
	[Widget] private Label message;
	
    public ErrorDialog (string overview, string details)
    {
        Glade.XML gxml = new Glade.XML (null, "gui.glade", "error", null);
        gxml.Autoconnect (this);
        error.SetIconFromFile (Constants.PIXMAPSDIR + "/" + Constants.ICONFILE);
        SetMessage (overview, details);
    }

	private void SetMessage (string overview, string details)
	{
		message.Markup = String.Format (
			"<span weight=\"bold\" size=\"larger\">{0}</span>\n\n{1}", 
			overview, details);
	}    
            
    public void Run ()
    {
    	error.Run ();
    	error.Destroy ();
    }
}