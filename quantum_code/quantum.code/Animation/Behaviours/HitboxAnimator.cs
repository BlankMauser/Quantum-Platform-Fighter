using System;
using System.Collections.Generic;
using Photon.Deterministic;

namespace Quantum {
    [Serializable]
    public unsafe partial class HitboxAnimator : AnimatedBehaviour {

        public HitboxFrame[] Frame;

        public override object SampleAnim(Frame f, Int16 animFrame, EntityRef ent) {
/*            var jointdata = (JointFrame)data.Behaviours.Find(AnimatedBehaviour => AnimatedBehaviour is JointAnimator).SampleAnim(f, animFrame, ent);*/

            return Frame[animFrame];
            }

        }

    [Serializable]
    public class HitboxFrame {

        public List<HitboxData> hitboxes;

        }

    [Serializable]
    public class HitboxData {

        public jointType joint;
        public byte attackIndex;
        public FPVector3 offset;
        public FP size;
        public bool interpolate;

        }



    }
