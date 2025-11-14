using System;
using XRL.Messages;
using XRL.World.AI.Pathfinding;
using XRL.World.Conversations;
using XRL.World.Parts;

namespace XRL.World.AI.GoalHandlers
{

    [Serializable]
    public class MoveToAndConsult : IMovementGoal
    {
        Cell cell;
        int stayTime;
        int stayTimeCounter = 0;
        Preacher preacherPart = new()
        {
            Book = "UrfurufuruMurmur",
            Prefix = "{{W|'",
        };

        public MoveToAndConsult(Cell cell, int stayTime = 10)
        {
            this.cell = cell;
            this.stayTime = stayTime;
        }

        public override void TakeAction()
        {
            if (CurrentCell != cell)
            {
                MoveTowards(cell);
            }
            else
            {
                if (stayTimeCounter == 0)
                {
                    ParentObject.AddPart(preacherPart);
                    ParentObject.SetIntProperty("FortUrfurfuru_Consulting", 1);
                }
                ParentObject.UseEnergy(1000, "Consulting");
                stayTimeCounter++;
            }

            if (stayTimeCounter >= stayTime)
            {
                ParentObject.RemovePart(preacherPart);
                ParentObject.SetIntProperty("FortUrfurfuru_Consulting", 0, true);
                Pop();
            }
        }

        public override bool Finished()
        {
            return false;
        }
    }
}