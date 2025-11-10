using XRL.World.Parts;

namespace XRL.World.Conversations.Parts
{
    public class FortUrfurufuru_GetShot : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            var oldPlayerHealth = The.Player.Health();
            Combat.FireMissileWeapon(The.Speaker, null, The.Player.GetCurrentCell());
            if (The.Player.Health() < oldPlayerHealth)
            {
                The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestDodge", 0, true);
                The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestSuccess", 1);
                The.Player.SetIntProperty("FortUrfurufuru_TestSuccess", 1);
            }
            else
            {
                The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestDodge", 1);
            }

            return base.HandleEvent(E);
        }
    }

    public class FortUrfurufuru_GetShotAt : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            var playerHealth = The.Player.Health();
            Combat.FireMissileWeapon(The.Speaker, null, The.Player.GetCurrentCell());
            if (The.Player.Health() < playerHealth)
            {
                The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestSuccessAccidental", 1);
                The.Player.SetIntProperty("FortUrfurufuru_TestSuccess", 1);
            }
            else
            {
                The.Player.SetIntProperty("FortUrfurufuru_AgilityTestSuccess", 1);
                The.Player.SetIntProperty("FortUrfurufuru_TestSuccess", 1);
            }

            return base.HandleEvent(E);
        }
    }

    public class FortUrfurufuru_AttackUrfurufuru : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            var oldSpeakerHealth = The.Speaker.Health();
            The.Player.PerformMeleeAttack(The.Speaker);
            The.Speaker.Brain.Forgive(The.Player);
            foreach (var o in The.ActiveZone.GetObjectsThatInheritFrom("Snapjaw"))
            {
                if (The.Speaker.Health() > 0)
                {
                    // TODO: only forgive for snapjaws that were non-hostile before
                    o.Brain.Forgive(The.Player);
                }
            }

            var healthDiff = oldSpeakerHealth - The.Speaker.Health();
            if (healthDiff >= 0.25)
            {
                The.Player.SetIntProperty("FortUrfurufuru_TestSuccess", 1);
                The.Player.SetIntProperty("FortUrfurufuru_StrengthTestSuccess", 1);
            }
            else if (healthDiff > 0)
            {
                The.Player.SetIntProperty("FortUrfurufuru_StrengthTestFailureWeak", 1);
                The.Player.SetIntProperty("FortUrfurufuru_TestFailure", 1);
            }
            else
            {
                The.Player.SetIntProperty("FortUrfurufuru_StrengthTestFailureMiss", 1);
                The.Player.SetIntProperty("FortUrfurufuru_TestFailure", 1);
            }

            return base.HandleEvent(E);
        }
    }

    public class FortUrfurufuru_TestFailure : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            The.Game.PlayerReputation.Modify("FortUrfurufuru_UrfurufuruFaction", -100);
            The.Player.SetIntProperty("FortUrfurufuru_StrengthTestFailureWeak", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_StrengthTestFailureMiss", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_WillpowerTestFailure", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestDodge", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_TestFailure", 0, true);
            return base.HandleEvent(E);
        }
    }

    public class FortUrfurufuru_StareDownFailure : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            The.Player.SetIntProperty("FortUrfurufuru_WillpowerTestFailure", 1);
            The.Player.SetIntProperty("FortUrfurufuru_TestFailure", 1);
            The.Player.ForceApplyEffect(new Effects.Terrified(5, The.Speaker));
            return base.HandleEvent(E);
        }
    }

    public class FortUrfurufuru_StareDownSuccess : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            The.Player.SetIntProperty("FortUrfurufuru_WillpowerTestSuccess", 1);
            The.Player.SetIntProperty("FortUrfurufuru_TestSuccess", 1);
            The.Speaker.ForceApplyEffect(new Effects.Shamed(10));
            return base.HandleEvent(E);
        }
    }

    public class FortUrfurufuru_TestSuccess : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            The.Player.SetIntProperty("FortUrfurufuru_TestSuccess", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_StrengthTestSuccess", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestSuccess", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestDodge", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_ToughnessTestSuccessAccidental", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_AgilityTestSuccess", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_WillpowerTestSuccess", 0, true);
            The.Player.SetIntProperty("FortUrfurufuru_TestComplete", 1);
            return base.HandleEvent(E);
        }
    }
}