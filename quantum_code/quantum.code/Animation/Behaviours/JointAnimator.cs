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

        public JointData[] joints;

        }

    [Serializable]
    public class JointData {

        public jointType type;
        public FPVector3 localPosition;
        public FPQuaternion rotation;

        }

    public enum jointType {

        Root = 0,
        Hip_L,
        Hip_R,
        Spine_1,
        Spine_2,
        Neck,
        Head,
        Arm_L,
        Arm_R,
        Elbow_L,
        Elbow_R,
        Knee_L,
        Knee_R,
        Foot_L,
        Foot_R,
        Weapon_base,
        Weapon_tip,
        Custom_1,
        Custom_2,

        }




    }
