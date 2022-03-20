using Assets.Scripts.Commons;
using Assets.Scripts.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.StateMachine
{
    public class GameStateMachine : Singleton<GameStateMachine>
    {
        [SerializeField] private SceneController _sceneController;

        private GameStateFactory _gameStateFactory = null;
        private GameState _currentState = null;
        private GameState _lastState = null;

        private void Start()
        {
            _gameStateFactory = new GameStateFactory(this);
            ChangeState(_gameStateFactory.LoadingState(_gameStateFactory.MainMenuState(), _sceneController.CallbackIsNotLoading));
        }

        private void Update()
        {
            _currentState.Update();
            //Debug.Log(SceneManager.GetSceneByName("MainMenu").isLoaded);
        }

        public void ChangeState(GameState newState)
        {
            _lastState = _currentState;
            _currentState = newState;
        }
    }
}
