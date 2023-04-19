using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quantum;
using Animancer;

public partial class StateAsset
{
    [SerializeReference] [SerializeReferenceDropdown]
    public StateBehaviour[] behaviours;

    [SerializeField]
    public ClipTransition Animation;

    public override void PrepareAsset() {
        Settings.Behaviours = behaviours;

        }

    }
