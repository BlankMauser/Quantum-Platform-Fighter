using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using Quantum;
using Photon.Deterministic;
using Animancer;

[CustomEditor(typeof(JointBaker))]
public class JointBakerEditor : Editor
{
    private JointBaker jointBaker;

    private void OnEnable() {
        jointBaker = (JointBaker)target;
        }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add JointTrackers")) {
            jointBaker.joints.Clear();
            JointTracker[] allJointTrackers = FindObjectsOfType<JointTracker>();
            jointBaker.joints.AddRange(allJointTrackers);
            EditorUtility.SetDirty(jointBaker);
            }

        EditorGUI.BeginDisabledGroup(jointBaker.joints.Count == 0);

        if (GUILayout.Button("Bake Animation")) {
            jointBaker.Preview = false;
            int frameCount = (int)(jointBaker.clip.length * 60f);
            Transform rootBone = jointBaker.rootBone;

            jointBaker.frames = new JointFrame[frameCount];

            for (int frame = 0; frame < frameCount; frame++) {
                jointBaker.Sample(frame);

                jointBaker.frames[frame] = new JointFrame(); // Initialize the element at the current frame index
                jointBaker.frames[frame].joints = new List<JointData>(); // Initialize the joints list

                foreach (JointTracker j in jointBaker.joints) {
                    Vector3 positionOffset = j.transform.position - rootBone.position;
                    Quaternion rotationOffset = Quaternion.Inverse(rootBone.rotation) * j.transform.rotation;
                    JointData jd = new JointData();
                    jd.type = j.joint;
                    jd.localPosition = new FPVector3(FP.FromFloat_UNSAFE(positionOffset.x), FP.FromFloat_UNSAFE(positionOffset.y), FP.FromFloat_UNSAFE(positionOffset.z));
                    jd.rotation = new FPQuaternion(FP.FromFloat_UNSAFE(rotationOffset.x), FP.FromFloat_UNSAFE(rotationOffset.y), FP.FromFloat_UNSAFE(rotationOffset.z), FP.FromFloat_UNSAFE(rotationOffset.w));
                    Debug.Log(jd);
                    jointBaker.frames[frame].joints.Add(jd);

                    }



                }

/*            jointBaker.positionOffsets = positions;
            jointBaker.rotationOffsets = rotations;*/
            EditorUtility.SetDirty(jointBaker);

            JointAnimator anim = (JointAnimator)jointBaker.animData.behaviours.Find(AnimatedBehaviour => AnimatedBehaviour is JointAnimator);
            anim.Frame = jointBaker.frames;
            EditorUtility.SetDirty(jointBaker.animData);
            }

        EditorGUI.EndDisabledGroup();
        }
    }
