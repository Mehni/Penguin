using System;
using Verse;
using Verse.AI;
using RimWorld;
using System.Collections.Generic;

namespace Penguin
{
    public class Penguin_JobGiver_Cleaning : ThinkNode_JobGiver
    {

        protected override Job TryGiveJob(Pawn pawn)
        {
        Predicate<Thing> filth = t => t.def.category == ThingCategory.Filth;

            Thing thing = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForGroup(ThingRequestGroup.Filth), PathEndMode.ClosestTouch,
                TraverseParms.For(pawn, Danger.Deadly, TraverseMode.ByPawn, false), 300f, filth, null, 0, -1, false, RegionType.Set_Passable, false);

            if (thing != null && pawn.CanReserve(thing))
            {
                Job job = new Job(JobDefOf.Clean);
                job.AddQueuedTarget(TargetIndex.A, thing);
                return job;
            }
        return null;
        }
    }
}