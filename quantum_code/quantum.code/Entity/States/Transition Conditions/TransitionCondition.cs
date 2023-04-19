using System;
using Photon.Deterministic;

namespace Quantum {

    [Serializable]
    public unsafe partial class TransitionCondition {

        public virtual bool TryCondition(Frame f, AbilityEntity* abilityEnt, EntityRef ent) {
            return false;
            }

        }
    }
