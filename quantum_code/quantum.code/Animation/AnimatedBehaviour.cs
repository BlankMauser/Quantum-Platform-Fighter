using System;
using Photon.Deterministic;

namespace Quantum {

    [Serializable]
    public unsafe partial class AnimatedBehaviour {

        public virtual object SampleAnim(Frame f, Int16 animFrame, EntityRef ent) {
            return null;

            }

        public virtual object SampleAnim(Frame f, Int16 animFrame, EntityRef ent, AnimData data) {
            return null;

            }

        }

    }
