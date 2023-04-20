using System;
using Photon.Deterministic;

namespace Quantum {
    public unsafe partial class VelocityImpulse : StateBehaviour {
        public FP Velocity;
        public FP Duration;

        public override void Update(Frame f, AbilityEntity* abilityEnt, EntityRef ent) {
            if (abilityEnt->controllerType == ControllerType.Platformer3D) {
                f.Unsafe.TryGetPointer<CharacterController3D>(ent, out CharacterController3D* c);
                c->Velocity.Y += Velocity * Duration;
                }



            }

        }
    }
