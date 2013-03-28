using GConf;

public class ConfigReader {

	private GConf.Client client;
	
	private static string BASE_KEY = "/apps/spamtrainer";
	private static string HAM_COMMAND_KEY = BASE_KEY + "/commands/train_ham";
	private static string SPAM_COMMAND_KEY = BASE_KEY + "/commands/train_spam";

	public ConfigReader ()
	{
		client = new GConf.Client ();
	}
	
	private string GetKey (string keyName)
	{
		try
		{
			return (string) client.Get (keyName);
		}
		catch (GConf.NoSuchKeyException)
		{
			return "";
		}
	}
	
	public string HamCommand
	{
		get
		{
			return GetKey (HAM_COMMAND_KEY);
		}
		
		set
		{
			client.Set (HAM_COMMAND_KEY, value);
		}
	}
	
	public string SpamCommand
	{
		get
		{
			return GetKey (SPAM_COMMAND_KEY);
		}
		
		set
		{
			client.Set (SPAM_COMMAND_KEY, value);
		}
	}
}
