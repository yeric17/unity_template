using System;

namespace Assets.Scripts.StateMachine
{
    public class GameStateFactory
    {
        private GameStateMachine _context = null;
        public GameStateFactory(GameStateMachine context)
        {
            _context = context;

        }

        public LoadingSceneState LoadingState(GameState nexState, Func<bool> callBack)
        {
            var loadingState = new LoadingSceneState(_context, this, callBack);
            loadingState.SetNextState(nexState);
            return loadingState;
        }

        public MainMenuState MainMenuState()
        {
            return new MainMenuState(_context, this);
        }

        public GameplayState GameplayState()
        {
            return new GameplayState(_context, this);
        }
    }
}
