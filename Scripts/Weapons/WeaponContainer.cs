using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapons
{
    public class WeaponContainer : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weaponList;

        public Weapon GetWeaponCopy(WeaponType weaponType)
        {
            foreach (Weapon weapon in _weaponList)
            { 
                if (weapon.WeaponData.WeaponType == weaponType)
                {
                    return weapon;
                }
            }
            return null;
        }
    }

}
