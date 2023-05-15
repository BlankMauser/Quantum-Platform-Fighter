using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quantum;
using Animancer;
using System.Linq;
public partial class AnimDataAsset {

    public HitboxAnimator hitboxes;


    [SerializeReference][SerializeReferenceDropdown]
    public List<AnimatedBehaviour> behaviours;

    public override void PrepareAsset() {
        var changer = (AnimData)AssetObject;
        changer.Behaviours = behaviours;

        }


    }

