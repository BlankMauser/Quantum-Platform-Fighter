using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quantum;
using Photon.Deterministic;

public class JointTracker : MonoBehaviour
{

    public jointType joint;

    public HurtboxTracker hurtbox;


}

[System.Serializable]
public class HurtboxTracker {

    public bool isHurtbox;
    public bool enabled;
    public jointType endJoint;
    public FP size;

    }
