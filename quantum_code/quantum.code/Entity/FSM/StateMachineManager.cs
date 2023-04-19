using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum {
    public static unsafe class StateMachineManager {

        public static void UpdateStateMachine(Frame f, AbilityEntity* e, EntityRef ent) {
            f.Assets.State(e->FSM.CurrentState).UpdateState(f, e, ent);
            f.Assets.State(e->FSM.CurrentState).UpdateBehaviours(f, e, ent);

            }


        }
    }
