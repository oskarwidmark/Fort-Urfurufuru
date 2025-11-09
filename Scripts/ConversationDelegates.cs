namespace XRL.World.Conversations
{
	[HasConversationDelegate]
	public static class FortUrfurufuru_ConversationDelegates
	{
		[ConversationDelegate(Speaker = true, SpeakerKey = "FortUrfurufuru_IfSpeakerFullHealth", SpeakerInverseKey = "FortUrfurufuru_IfSpeakerNotFullHealth")]
		public static bool IfUrfurufuruFullHealth(DelegateContext Context) => Context.Target.Health() == 1.0;

		[ConversationDelegate(Key = "FortUrfurufuru_IfClever")]
		public static bool IfClever(DelegateContext Context) => Context.Target.Statistics["Intelligence"].Value >= 23;

		[ConversationDelegate(Key = "FortUrfurufuru_IfStrongOfMind", InverseKey = "FortUrfurufuru_IfNotStrongOfMind")]
		public static bool IfStrongOfMind(DelegateContext Context) => Context.Target.Statistics["Willpower"].Value >= 23;

		[ConversationDelegate(Key = "FortUrfurufuru_IfCharismatic")]
		public static bool IfCharismatic(DelegateContext Context) => Context.Target.Statistics["Ego"].Value >= 27;

		[ConversationDelegate(Key = "FortUrfurufuru_HasAttemptedTestRecently", InverseKey = "FortUrfurufuru_HasNotAttemptedTestRecently")]
		public static bool HasTestFailure(DelegateContext Context) => Context.Target.HasIntProperty("FortUrfurufuru_TestFailure") || Context.Target.HasIntProperty("FortUrfurufuru_TestSuccess");

		[ConversationDelegate(Key = "FortUrfurufuru_HasCompletedTest", InverseKey = "FortUrfurufuru_HasNotCompletedTest")]
		public static bool HasTestSuccess(DelegateContext Context) => Context.Target.HasIntProperty("FortUrfurufuru_TestComplete");
	}
}
