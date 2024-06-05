using Scripts.Characters.Common;
using Scripts.Infrastructure.Factory;
using Scripts.Weapons;
using UnityEngine;
using Zenject;

namespace Scripts.Characters.MainPlayer
{
    
    public class MainPlayerCharacterAttack : MonoBehaviour
    {
        [SerializeField] private WeaponType _type;

        private CharacterType _headCharacterType;
        
        private WeaponFactory _weaponFactory;

        private float _shootTimer = 2;

        private float _reloadSpeed;

        [Inject]
        private void Construct(WeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }



        private void OnEnable()
        {
            _headCharacterType = GetComponent<Character>().CharacterData.CharacterType;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Shoot();
            }
            if (_shootTimer < 2)
            {
                _shootTimer += Time.deltaTime;
            }
        }

        private void Shoot()
        {
            if (_shootTimer >= _reloadSpeed)
            {
                _shootTimer = 0;
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 objectPosition = gameObject.transform.position;
                Vector3 relativeMousePosition = mouseWorldPosition - objectPosition;
                Weapon weapon = _weaponFactory.Create(_type, objectPosition);
                weapon.Launch(relativeMousePosition, _headCharacterType, gameObject.tag);
                _reloadSpeed = weapon.WeaponData.ReloadSpeed;
            }
           
        }
    }
}

