using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Quantum;
using Animancer;
using Photon.Deterministic;

[RequireComponent(typeof(AnimSampler))]
[ExecuteInEditMode]
public class HitboxBaker : MonoBehaviour
{

    public AnimSampler sampler;
    public bool Preview;
    public HitboxFrame[] frames;
    public List<JointTracker> trackers;

    private void OnValidate() {
        sampler = GetComponent<AnimSampler>();
        }

    public void Sample(int frame) {

        sampler.Sample(frame);
        }

    public void Bake() {

        Preview = false;
        int frameCount = (int)(sampler.clip.length * 60f);

        frames = new HitboxFrame[frameCount];


        for (int frame = 0; frame < frameCount; frame++) {
            Sample(frame);

            frames[frame] = new HitboxFrame(); // Initialize the element at the current frame index
            frames[frame].hitboxes = new List<HitboxData>(); // Initialize the joints list

            foreach (JointTracker j in trackers) {
                
                }



            }

        }





    }

[System.Serializable]
public class HitboxTween {

    public EasingFunction.Ease easeType;
    public jointType joint;
    public int frameStart;
    public int frameEnd;
    public Vector3 offsetStart;
    public Vector3 offsetEnd;

    }
