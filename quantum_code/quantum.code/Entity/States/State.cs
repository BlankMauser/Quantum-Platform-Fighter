using System;
using Photon.Deterministic;

namespace Quantum {
    public unsafe partial class State {
        public StateBehaviour[] Behaviours;
        public StateTags[] Tags;

        #region Animation Parameters
        public int Length;
        public bool OverrideAnimation;
        public bool Loop;

        #endregion

        public virtual void UpdateBehaviours(Frame f, AbilityEntity* abilityEnt, EntityRef ent) {
            foreach (StateBehaviour sb in Behaviours) {
                sb.Update(f, abilityEnt, ent);

                }

            }

        public virtual void OnEnterState(Frame f, AbilityEntity* abilityEnt, EntityRef ent) {
            abilityEnt->AnimationFrame = 0;
            }

        public virtual void UpdateState(Frame f, AbilityEntity* abilityEnt, EntityRef ent) {
            abilityEnt->AnimationFrame += 1;

            if (abilityEnt->AnimationFrame > Length) {
                if (Loop) {
                    abilityEnt->AnimationFrame = 0;
                    } else {
                    abilityEnt->AnimationFrame = Length;
                    }
                

                }

            }

        public virtual void OnExitState(Frame f, AbilityEntity* abilityEnt, EntityRef ent) {

            }

        }






    }
