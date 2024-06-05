using Scripts.Characters.Common;
using System.Collections;
using UnityEngine;

namespace Scripts.Weapons
{
    public enum WeaponType
    {
        LongRangeSimple,
        LongRangeMiddle,
        LongRangeHard
    }
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        private CharacterType _headCharacterType;
        private string _tag;

        public WeaponData WeaponData => _weaponData;

        private Rigidbody2D _rigidbody;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Character>() && 
                _headCharacterType != collision.GetComponent<Character>().CharacterData.CharacterType)
            {
                if (collision.CompareTag("Enemy") && _tag == "Enemy")
                {
                    return;
                }
                collision.GetComponent<CharacterHealth>().GetDamage(_weaponData.Damage);
                gameObject.SetActive(false);
            }
        }

        public void Launch(Vector3 direction, CharacterType type, string tag)
        {
            _tag = tag;
            _headCharacterType = type;
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            _rigidbody.AddForce(direction2D * _weaponData.FlightSpeed, ForceMode2D.Impulse);
            StartCoroutine(SelfDestroy());
        }

        private IEnumerator SelfDestroy()
        {
            yield return new WaitForSeconds(_weaponData.LifeTime);
            gameObject.SetActive(false);
        }

      
    }

}
