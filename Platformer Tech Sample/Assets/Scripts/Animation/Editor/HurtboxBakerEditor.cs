using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using Quantum;
using Photon.Deterministic;
using Animancer;

[CustomEditor(typeof(HurtboxBaker))]
public class HurtboxBakerEditor : Editor {
    private HurtboxBaker hurtboxBaker;

    private void OnEnable() {
        hurtboxBaker = (HurtboxBaker)target;
        }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add JointTrackers")) {
            hurtboxBaker.trackers.Clear();
            JointTracker[] allJointTrackers = FindObjectsOfType<JointTracker>();
            foreach (JointTracker j in allJointTrackers) {
                if (j.hurtbox.isHurtbox) {
                    hurtboxBaker.trackers.Add(j);
                    }
                }
            EditorUtility.SetDirty(hurtboxBaker);
            }

        EditorGUI.BeginDisabledGroup(hurtboxBaker.trackers.Count == 0);

        if (GUILayout.Button("Bake Animation")) {
            hurtboxBaker.Preview = false;
            int frameCount = (int)(hurtboxBaker.sampler.clip.length * 60f);

            hurtboxBaker.frames = new HurtboxFrame[frameCount];


                for (int frame = 0; frame < frameCount; frame++) {
                hurtboxBaker.Sample(frame);

                hurtboxBaker.frames[frame] = new HurtboxFrame(); // Initialize the element at the current frame index
                hurtboxBaker.frames[frame].hurtboxes = new HurtboxData[hurtboxBaker.trackers.Count]; // Initialize the joints list

                int i = 0;
                foreach (JointTracker j in hurtboxBaker.trackers) {
                    if (j.hurtbox.enabled) {
                        hurtboxBaker.frames[frame].enabledBoxes |= (short)(1 << i);
                        } else {
                        hurtboxBaker.frames[frame].enabledBoxes &= (short)(~(1 << i));
                        }
                    hurtboxBaker.frames[frame].hurtboxes[i] = new HurtboxData();
                    hurtboxBaker.frames[frame].hurtboxes[i].joint_1 = j.joint;
                    hurtboxBaker.frames[frame].hurtboxes[i].joint_2 = j.hurtbox.endJoint;
                    hurtboxBaker.frames[frame].hurtboxes[i].size = j.hurtbox.size;
                    i++;
                    }



                }

            EditorUtility.SetDirty(hurtboxBaker);

            HurtboxAnimator anim = (HurtboxAnimator)hurtboxBaker.sampler.animData.behaviours.Find(AnimatedBehaviour => AnimatedBehaviour is HurtboxAnimator);
            anim.Frame = hurtboxBaker.frames;
            EditorUtility.SetDirty(hurtboxBaker.sampler.animData);
            }

        EditorGUI.EndDisabledGroup();


        }


   }
