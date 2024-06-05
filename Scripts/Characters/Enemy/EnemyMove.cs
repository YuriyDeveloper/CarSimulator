using Scripts.Characters.Common;
using Scripts.Characters.MainPlayer;
using System;
using UnityEngine;

namespace Scripts.Characters.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Transform _transformToRotate;

        private CharacterData _characterData;

        public Action AtAttackRange;
        public Action NotAtAttackRange;

        private void OnEnable()
        {
            _characterData = _character.CharacterData;
        }

        private void Update()
        {
            MoveToMainPlayer();
            RotateToPlayer();
        }

        private void MoveToMainPlayer()
        {
            Transform mainPlayerTransform = MainPlayerCharacterMove.Transform;
            float distanceToPlayer = Vector3.Distance(transform.position, mainPlayerTransform.position);

            if (distanceToPlayer > _characterData.DistanceToAttack / 2.4f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    mainPlayerTransform.position,
                    _characterData.MoveSpeed * Time.deltaTime
                );
                NotAtAttackRange?.Invoke();
            }
            else
            {
                AtAttackRange?.Invoke();
            }
        }

        private void RotateToPlayer()
        {
            Transform mainPlayerTransform = MainPlayerCharacterMove.Transform;
            Vector3 directionToPlayer = (mainPlayerTransform.position - transform.position).normalized;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            _transformToRotate.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}

