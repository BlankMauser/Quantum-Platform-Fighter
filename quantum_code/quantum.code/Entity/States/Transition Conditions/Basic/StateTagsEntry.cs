using System;
using Photon.Deterministic;

namespace Quantum {
    public class StateTagsEntry : T_Condition {

        public StateTags[] tagsToCheck;

        public override unsafe bool TryCondition(Frame f, AbilityEntity* abilityEnt, EntityRef ent) {

            bool containsAll = false;
            var state = f.Assets.State(abilityEnt->FSM.CurrentState);
            foreach (StateTags t in tagsToCheck) {
                containsAll = false;
                foreach (StateTags entry in state.Tags) {
                    if (t == entry) containsAll = true;
                    }
                if (containsAll) {
                    continue;
                    } else {
                    return containsAll;
                    }
                }
            return containsAll;

              }
            }

        }
