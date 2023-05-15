using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Quantum;
using Animancer;
using Photon.Deterministic;

[RequireComponent(typeof(AnimSampler))]
public class JointBaker : MonoBehaviour
{
    public AnimSampler sampler;
    public bool Preview;
    public AnimDataAsset animData;
    public AnimancerComponent animator;
    public AnimationClip clip;

    public Transform rootBone;
    public List<JointTracker> joints;

    public int CurrentFrame;
    public JointFrame[] frames;

    private void Awake() {
        sampler = GetComponent<AnimSampler>();
        }

    public void Sample(int frame) {

/*        sampler.Sample(frame);*/
        }



    public void OnDrawGizmos() {
        if (Preview) {
            Sample(CurrentFrame);

            }
        FPVector3 rootPos = new FPVector3(FP.FromFloat_UNSAFE(rootBone.position.x), FP.FromFloat_UNSAFE(rootBone.position.y), FP.FromFloat_UNSAFE(rootBone.position.z));

        foreach (JointData jd in frames[CurrentFrame].joints) {

            Gizmos.color = Color.red;
            FPVector3 pos = jd.localPosition + rootPos;
            Vector3 vPos = new Vector3((float)pos.X, (float)pos.Y, (float)pos.Z);
            Gizmos.DrawSphere( vPos, .25f);

/*            Draw.Sphere(jd.localPosition + rootPos, FP.FromFloat_UNSAFE(5f), ColorRGBA.Red);*/

            }

        }


    }
