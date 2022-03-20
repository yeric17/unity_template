using System;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public class GameState : State
    {
        private GameStateMachine _context = null;
        private GameStateFactory _factory = null;
        protected bool debugMessage = true;
        protected GameStateMachine Context => _context;
        protected GameStateFactory Factory => _factory;
        public GameState(GameStateMachine gameStateMachine, GameStateFactory gameStateFactory) {
            _context = gameStateMachine;
            _factory = gameStateFactory;
        }

        public override void CheckSwitchStates()
        {
            Log($"CheckSwitchStates in {this}");
        }

        public override void Enter()
        {
            Log($"Enter in {this}");
        }

        public override void Exit()
        {
            Log($"Exit in {this}");
        }

        public override void InitializeSubState()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            Log($"Update in {this}");
            CheckSwitchStates();
        }

        public void Log(string message)
        {
            if(debugMessage) Debug.Log(message);
        }


        protected void SwitchState(GameState nextState) {
            Exit();
            nextState.Enter();
            Context.ChangeState(nextState);
        }

    }
}
