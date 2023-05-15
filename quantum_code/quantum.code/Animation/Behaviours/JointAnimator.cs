using System;
using System.Collections.Generic;
using Photon.Deterministic;

namespace Quantum {
    public unsafe partial class JointAnimator : AnimatedBehaviour {

        public JointFrame[] Frame;

        public override object SampleAnim(Frame f, Int16 animFrame, EntityRef ent) {
            return Frame[animFrame];


            }

        }

    [Serializable]
    public class JointFrame {

        public List<JointData> joints;

        }

    [Serializable]
    public class JointData {

        public jointType type;
        public FPVector3 localPosition;
        public FPQuaternion rotation;

        }

    public enum jointType {


        Hip_L,
        Hip_R,
        Arm_L,
        Arm_R,
        Weapon_base,
        Weapon_tip,
        Custom_1,
        Custom_2,

        }




    }
