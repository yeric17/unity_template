

using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public abstract class State
    {
        public abstract void Exit();

        public abstract void Enter();

        public abstract void Update();

        public abstract void CheckSwitchStates();
        public abstract void InitializeSubState();

    }
}
