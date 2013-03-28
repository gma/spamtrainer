using System;
using System.Diagnostics;
using System.Threading;

public class MessageTrainer {

	private ConfigReader config;

	public MessageTrainer (ConfigReader config)
	{
		this.config = config;
	}

	private string SubstituteFilename (string command, string filename)
	{
		filename = filename.Replace ("\"", "\\\\\\\"");  // " -> \\\"
		filename = filename.Replace ("'", "\\'");
		filename = filename.Replace (" ", "\\ ");
		return command.Replace ("%f", filename);
	}

	private bool RunCommandInShell (string command)
	{
		try
		{
			string bash_command = String.Format ("bash -c \"{0}\"", command);
			Console.WriteLine (bash_command);
			Process proc = Process.Start (bash_command);
			while (proc.HasExited == false)
			{
				Thread.Sleep (10);
			}
			return (proc.ExitCode == 0);
		}
		catch (InvalidOperationException)
		{
			return false;
		}
	}

	public bool TrainAsHam (string filename)
	{
		string command = SubstituteFilename (config.HamCommand, filename);
		return RunCommandInShell (command);
	}

	public bool TrainAsSpam (string filename)
	{
		string command = SubstituteFilename (config.SpamCommand, filename);
		return RunCommandInShell (command);
	}
}
