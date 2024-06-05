using Scripts.Characters.Common;
using Scripts.Characters.MainPlayer;
using Scripts.Infrastructure.Factory;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Enemy
{
    public class LevelEnemyController : MonoBehaviour
    {
        [SerializeField] private Vector2 _createEnemyRangeInterval;
        [SerializeField] private Vector2 _enemyCreatePositionRangeNearMainPlayer;

        private CharacterFactory _characterFactory;

        [Inject]
        private void Construct(CharacterFactory characterFactory)
        {
            _characterFactory = characterFactory;
        }

        private void OnEnable()
        {
            StartCoroutine(Create());
        }

        private IEnumerator Create()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_createEnemyRangeInterval.x, _createEnemyRangeInterval.y));
                int i = Random.Range(0, 4);
                CharacterType type;
                if (i == 2)
                {
                    type = CharacterType.EnemyMiddle;
                }
                else
                {
                    type = CharacterType.EnemySimple;
                }

                Vector2 position = default;
                bool isValidPosition = false;

                while (!isValidPosition)
                {
                    Vector2 playerPosition = MainPlayerCharacterMove.Transform.position;
                    float angle = Random.Range(0f, 2f * Mathf.PI);
                    Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                    float distance = Random.Range(_enemyCreatePositionRangeNearMainPlayer.x, _enemyCreatePositionRangeNearMainPlayer.y);
                    position = playerPosition + direction * distance;
                    if (position.x >= -25 && position.x <= 25 && position.y >= -25 && position.y <= 25)
                    {
                        isValidPosition = true;
                    }
                }
                Character character = _characterFactory.CreateCharacter(type, position);
            }
        }
    }
}

