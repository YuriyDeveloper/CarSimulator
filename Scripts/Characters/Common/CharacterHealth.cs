using Scripts.UI;
using System;
using UnityEngine;

namespace Scripts.Characters.Common
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private CharacterHealthBar _characterHealthBar;

        private int _startHealth;
        private int _currentHealth;

        public static Action<int> OnDeadEnemy;
        public static Action OnDeadMainPlayer;

        private void OnEnable()
        {
            _startHealth = _character.CharacterData.Health;
            _currentHealth = _startHealth;
            _characterHealthBar.UpdateHealth(_startHealth, 0);
        }

        public void GetDamage(int damage)
        {
            _currentHealth -= damage;
            _characterHealthBar.UpdateHealth(_startHealth, damage);
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (gameObject.CompareTag("Enemy"))
            {
                OnDeadEnemy?.Invoke(_character.CharacterData.XPForKill);
            }
            else
            {
                
                OnDeadMainPlayer?.Invoke();
            }
            gameObject.SetActive(false);
        }
    }
}

