using System;
using System.Collections.Generic;
using System.Linq;
using XRL.Language;
using XRL.UI;
using XRL.World.Tinkering;

namespace XRL.World.Conversations.Parts
{
    public class FortUrfurufuru_SetTerrified : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            The.Player.ApplyEffect(new Effects.Terrified(10, GameObject.FindByID("FortUrfurufuru_Urfurufuru")));
            return base.HandleEvent(E);
        }
    }

    public class FortUrfurufuru_GetShot : IConversationPart
    {
        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation) || ID == EnterElementEvent.ID;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            The.Player.PlayWorldOrUISound("Sounds/Missile/Fires/Rifles/sfx_missile_phaseCannon_fire");
            The.Player.TakeDamage(10, null, null, "You couldn't withstand the blast of Urfurufuru's phase cannon!", null, null, GameObject.FindByID("FortUrfurufuru_Urfurufuru"), null, null, null);
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
            // TODO: find out how to fire phase cannon
            return base.HandleEvent(E);
        }
    }
}