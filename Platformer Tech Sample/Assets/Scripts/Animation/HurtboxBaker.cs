using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Quantum;
using Animancer;
using Photon.Deterministic;

[RequireComponent(typeof(AnimSampler))]
[ExecuteInEditMode]
public class HurtboxBaker : MonoBehaviour
{

    public AnimSampler sampler;
    public bool Preview;
    public HurtboxFrame[] frames;
    public List<JointTracker> trackers;

    private void OnValidate() {
        sampler = GetComponent<AnimSampler>();
        }

    public void Sample(int frame) {

        sampler.Sample(frame);
        }

    public void OnDrawGizmos() {
        if (Preview) {
/*            FPVector3 rootPos = new FPVector3(FP.FromFloat_UNSAFE(rootBone.position.x), FP.FromFloat_UNSAFE(rootBone.position.y), FP.FromFloat_UNSAFE(rootBone.position.z));

            foreach (JointData jd in frames[CurrentFrame].joints) {

                Gizmos.color = Color.red;
                FPVector3 pos = jd.localPosition + rootPos;
                Vector3 vPos = new Vector3((float)pos.X, (float)pos.Y, (float)pos.Z);
                Gizmos.DrawSphere(vPos, .25f);*/

                /*            Draw.Sphere(jd.localPosition + rootPos, FP.FromFloat_UNSAFE(5f), ColorRGBA.Red);*/

                }


            }


   }
