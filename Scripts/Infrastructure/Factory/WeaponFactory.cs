using Scripts.Infrastructure.Cache;
using Scripts.Weapons;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Factory
{
    public class WeaponFactory
    {
        private readonly DiContainer _diContainer;

        private Dictionary<Weapon, Pool<Weapon>> _poolWeapon = new Dictionary<Weapon, Pool<Weapon>>();

        private WeaponSettings _weaponSettings;

        public WeaponFactory(DiContainer diContainer, WeaponSettings weaponSettings)
        {
            _diContainer = diContainer;
            _weaponSettings = weaponSettings;
        }

        public Weapon Create(WeaponType weaponType, Vector2 position)
        {
            Weapon copy = _weaponSettings.WeaponContainer.GetWeaponCopy(weaponType);
            Weapon currentWeapon;
            Pool<Weapon> currentWeaponPool;
            if (_poolWeapon.TryGetValue(copy, out currentWeaponPool))
            {
                currentWeapon = currentWeaponPool.Get();
                _poolWeapon[copy] = currentWeaponPool;
            }
            else
            {
                currentWeaponPool = new Pool<Weapon>();
                currentWeaponPool.IsActive = (Weapon item) =>
                {
                    return item && item.gameObject && item.gameObject.activeSelf;
                };
                if (copy != null)
                {
                    currentWeaponPool.Instantiate = () =>
                    {
                        if (_diContainer.InstantiatePrefab(copy).TryGetComponent<Weapon>(out Weapon instance))
                        {
                            return instance;
                        }
                        return null;
                    };
                }
                currentWeapon = currentWeaponPool.Get();
                _poolWeapon.Add(copy, currentWeaponPool);
            }
            currentWeapon.gameObject.transform.position = position;
            currentWeapon.gameObject.SetActive(true);
            return currentWeapon;
        }
    }

}
