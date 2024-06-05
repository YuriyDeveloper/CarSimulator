using Scripts.Characters.Common;
using Scripts.Characters.MainPlayer;
using Scripts.Infrastructure.Factory;
using Scripts.Weapons;
using UnityEngine;
using Zenject;

namespace Scripts.Characters.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private WeaponType _type;

        private CharacterType _headCharacterType;


        private WeaponFactory _weaponFactory;

        private bool _isAttacking;

        private float _shootTimer = 2;

        private float _reloadSpeed;

        [Inject]
        private void Construct(WeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }

        private void OnEnable()
        {
            GetComponent<EnemyMove>().AtAttackRange += StartShot;
            GetComponent<EnemyMove>().NotAtAttackRange += StopShoot;
            _headCharacterType = GetComponent<Character>().CharacterData.CharacterType;
        }

        private void Update()
        {
            if (_shootTimer < 2)
            {
                _shootTimer += Time.deltaTime;
            }
            if (_isAttacking)
            {
                Shoot();
            }
           
        }

        private void StartShot()
        {
            _isAttacking  = true;
        }

        private void StopShoot()
        {
            _isAttacking = false;
        }

        private void Shoot()
        {
            
            if (_shootTimer >= _reloadSpeed)
            {
                _shootTimer = 0;
                Weapon weapon = _weaponFactory.Create(_type, gameObject.transform.position);
                Vector3 targetPosition = MainPlayerCharacterMove.Transform.position;
                Vector3 direction = (targetPosition - weapon.transform.position).normalized;
                weapon.Launch(direction, _headCharacterType, gameObject.tag);
                _reloadSpeed = weapon.WeaponData.ReloadSpeed;
            }
            
        }
    }
}

