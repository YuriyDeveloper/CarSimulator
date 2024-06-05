using UnityEngine;

namespace Scripts.Weapons
{
    [CreateAssetMenu(fileName = "WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private int _flightSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private int _lifeTime;
        [SerializeField] private float _reloadSpeed;

        public WeaponType WeaponType => _weaponType;
        public int FlightSpeed => _flightSpeed;
        public int Damage => _damage;
        public int LifeTime => _lifeTime;
        public float ReloadSpeed => _reloadSpeed; 
    }

}
