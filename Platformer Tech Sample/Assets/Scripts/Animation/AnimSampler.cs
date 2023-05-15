using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Quantum;
using Animancer;
using Photon.Deterministic;

public class AnimSampler : MonoBehaviour
{

    public bool Preview;
    public AnimDataAsset animData;
    public AnimancerComponent animator;
    public AnimationClip clip;

    public int CurrentFrame;

    public void Sample(int frame) {

        CurrentFrame = frame;
        var play = animator.Play(clip);
        play.Time = frame * (1f / 60f);
        play.IsPlaying = false;
        animator.Evaluate();
        }


}
