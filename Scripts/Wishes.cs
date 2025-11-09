using XRL;
using XRL.Messages;
using XRL.Wish;

namespace FortUrfurufuru.Scripts
{
	[HasWishCommand]
	public class WishHandler
	{
		[WishCommand(Command = "reseturf")]
		public static void Reset()
		{
			The.Game.PlayerReputation.Set("FortUrfurufuru_UrfurufuruFaction", 400);
			The.Player.SetIntProperty("FortUrfurufuru_TestFailure", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_StrengthTestFailureWeak", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_StrengthTestFailureMiss", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_WillpowerTestFailure", 0, true);

			The.Player.SetIntProperty("FortUrfurufuru_TestSuccess", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_StrengthTestSuccess", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestSuccess", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestSuccessAccidental", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_AgilityTestSuccess", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_WillpowerTestSuccess", 0, true);
			The.Player.SetIntProperty("FortUrfurufuru_TestComplete", 0, true);

			MessageQueue.AddPlayerMessage("Reset Urfurufuru quest/conversation state");
		}
	}
}
