using Scripts.Characters.Common;
using Scripts.Infrastructure;
using Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Scripts.Level
{
    public class GameLevelCoordinator 
    {
        private CharacterFactory _characterFactory;
        private LevelPointsSettings _levelPoints;
        private Character _mainPlayer;
        private CinemachineCameraSettings _cinemachineCamera;

        private GameLevelCoordinator(CharacterFactory gameObjectFactory, LevelPointsSettings levelPoints, CinemachineCameraSettings cinemachineCamera)
        {
            _characterFactory = gameObjectFactory;
            _levelPoints = levelPoints;
            _cinemachineCamera = cinemachineCamera;
            GameLoopEvents.SpawnMainPlayer += SpawnMainPlayer;
            CharacterHealth.OnDeadMainPlayer += OnPause;
            OffPause();
        }


        private void SpawnMainPlayer()
        {
            GameLoopEvents.SpawnMainPlayer -= SpawnMainPlayer;
            _mainPlayer =  _characterFactory.CreateCharacter(CharacterType.MainPlayer, _levelPoints.MainPlayerSpawnPoint.position);
            _cinemachineCamera.cinemachineVirtualCamera.Follow = _mainPlayer.transform;
        }

        private void OnPause()
        {
            CharacterHealth.OnDeadMainPlayer -= OnPause;
            Time.timeScale = 0;
        }

        private void OffPause()
        {
            Time.timeScale = 1;
        }
    }

}
