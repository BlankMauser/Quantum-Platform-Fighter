using System;
using Photon.Deterministic;

namespace Quantum {
    [Serializable]
    public unsafe partial class HurtboxAnimator : AnimatedBehaviour {

        public HurtboxFrame[] Frame;

        public override object SampleAnim(Frame f, Int16 animFrame, EntityRef ent) {

            return Frame[animFrame];
            }

        }

    [Serializable]
    public class HurtboxFrame {

        //bitmask showing what hurtboxes are enabled
        public Int16 enabledBoxes;
        public HurtboxData[] hurtboxes;

        }

    [Serializable]
    public class HurtboxData {

        public jointType joint_1;
        public jointType joint_2;
        public FP size;

        }



    }
