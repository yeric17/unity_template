
using System;
using UnityEngine;
namespace Assets.Scripts.StateMachine
{
    public class MainMenuState : GameState
    {
        public MainMenuState(GameStateMachine gameStateMachine, GameStateFactory gameStateFactory) : base(gameStateMachine, gameStateFactory)
        {
           
        }

        public override void CheckSwitchStates()
        {
            base.CheckSwitchStates();
            if (!CheckActive())
            {
                SwitchState(Factory.LoadingState(Factory.GameplayState(), Scenes.SceneController.Instance.CallbackIsNotLoading));
            }
        }

        private bool CheckActive()
        {
            return GameManager.Instance.mainMenuScenes.isLoaded;
        }
    }
}
