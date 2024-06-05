using Cinemachine;
using Scripts.Characters;
using Scripts.Infrastructure.Factory;
using Scripts.Level;
using Scripts.Weapons;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class GameLevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelPointsSettings _levelPointsSettings;
        [SerializeField] private CinemachineCameraSettings _cinemachineCameraSettings;
        [SerializeField] private WeaponSettings _weaponSettings;
        [SerializeField] private CharacterSettings _characterSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_levelPointsSettings).IfNotBound();
            Container.BindInstance(_cinemachineCameraSettings).IfNotBound();
            Container.BindInstance(_weaponSettings).IfNotBound();
            Container.BindInstance(_characterSettings).IfNotBound();
            Container.Bind<CharacterFactory>().AsSingle();
            Container.Bind<GameLevelCoordinator>().AsSingle().NonLazy();
            Container.Bind<WeaponFactory>().AsSingle();

        }
    }

    [Serializable]
    public class LevelPointsSettings
    {
        [SerializeField] private Transform _mainPlayerSpawnPoint;

        public Transform MainPlayerSpawnPoint => _mainPlayerSpawnPoint;
    }


    [Serializable]
    public class CinemachineCameraSettings
    {
        public CinemachineVirtualCamera cinemachineVirtualCamera;
    }

    [Serializable]
    public class WeaponSettings
    {
        [SerializeField] private WeaponContainer _weaponContainer;

        public WeaponContainer WeaponContainer => _weaponContainer;
    }

    [Serializable]
    public class CharacterSettings
    {
        [SerializeField] private CharacterContainer _characterContainer;

        public CharacterContainer CharacterContainer => _characterContainer;    
    }

    
}
