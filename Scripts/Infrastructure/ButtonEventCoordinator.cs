using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class ButtonEventCoordinator : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;


        [Inject]
        private void Construct( IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void RestartLevel()
        {
            IExitableState gameLoopState = _gameStateMachine.RegisteredStates[typeof(GameLoopState)];
            _gameStateMachine.Enter<LoadSceneState, string, IExitableState, bool>("GameLevelScene", gameLoopState, true);
            DontDestroyOnLoad(this);
        }

    }
}

