namespace XRL.World.Conversations
{
	[HasConversationDelegate]
	public static class FortUrfurufuru_ConversationDelegates
	{
		[ConversationDelegate(Key = "FortUrfurufuru_IfClever")]
		public static bool IfClever(DelegateContext Context) => Context.Target.Statistics["Intelligence"].Value >= 23;

		[ConversationDelegate(Key = "FortUrfurufuru_IfStrongOfMind", InverseKey = "FortUrfurufuru_IfNotStrongOfMind")]
		public static bool IfStrongOfMind(DelegateContext Context) => Context.Target.Statistics["Willpower"].Value >= 23;

		[ConversationDelegate(Key = "FortUrfurufuru_IfCharismatic")]
		public static bool IfCharismatic(DelegateContext Context) => Context.Target.Statistics["Ego"].Value >= 27;
	}
}
