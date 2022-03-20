

using Assets.Scripts.Scenes;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public class LoadingSceneState : GameState
    {

        private GameState _nextState = null;
        private Func<bool> _callBack = null;
        public LoadingSceneState(GameStateMachine gameStateMachine, GameStateFactory gameStateFactory, Func<bool> callBack): base(gameStateMachine, gameStateFactory)
        {
            _callBack = callBack;
        }
        public override void Enter()
        {
            base.Enter();
            
        }
        public void SetNextState(GameState gameState)
        {
            _nextState = gameState;
        }
        public override void CheckSwitchStates()
        {
            base.CheckSwitchStates();
            if (_callBack())
            {
                SwitchState(_nextState);
            }
        }



    }
}
