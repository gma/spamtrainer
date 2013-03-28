// project created on 09/10/2004 at 22:20
using System;
using Gnome;

class MainClass {

	public static void Main(string[] args)
	{
		Program program = new Program ("spamtrainer", Constants.VERSION, 
			Modules.UI, args);
		ConfigReader config = new ConfigReader ();
		MessageTrainer trainer = new MessageTrainer (config);
		new MainWindow (config, trainer);
		program.Run ();
	}

}
