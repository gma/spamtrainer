using Gtk;
using Glade;
using System;

public class PreferencesDialog
{
	private ConfigReader config;
	
	[Widget] private Dialog preferences;
	[Widget] private Entry hamCommand;
	[Widget] private Entry spamCommand;
	
    public PreferencesDialog (ConfigReader config)
    {
    	this.config = config;
        Glade.XML gxml = new Glade.XML (null, "gui.glade", "preferences", null);
        gxml.Autoconnect (this);
        preferences.SetIconFromFile (
        	Constants.PIXMAPSDIR + "/" + Constants.ICONFILE);
    }
    
    public void OnHamCommandActivate (object o, EventArgs args)
    {
    	this.spamCommand.GrabFocus ();
    }
    
    public void Run ()
    {
    	hamCommand.Text = config.HamCommand;
    	spamCommand.Text = config.SpamCommand;
    	int response = preferences.Run ();
    	if (response == (int) ResponseType.Close) {
    		config.HamCommand = hamCommand.Text;
    		config.SpamCommand = spamCommand.Text;
    	}
    	preferences.Destroy ();
    }
}
