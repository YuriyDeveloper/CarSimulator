using Scripts.Characters.Common;
using Scripts.Infrastructure.Cache;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Factory
{
    public class CharacterFactory
    {
        private Dictionary<Character, Pool<Character>> _poolCharacter = new Dictionary<Character, Pool<Character>>();
        private DiContainer _diContainer;
        private CharacterSettings _characterSettings;

        public CharacterFactory(DiContainer diContainer, CharacterSettings characterSettings)
        { 
            _diContainer = diContainer;
            _characterSettings = characterSettings;
        }

        public Character CreateCharacter(CharacterType type, Vector2 position)
        {
            Character copy = _characterSettings.CharacterContainer.GetCharacterCopy(type);
            Character currentCharacter;
            Pool<Character> currentCharacterPool;
            if (_poolCharacter.TryGetValue(copy, out currentCharacterPool))
            {
                currentCharacter = currentCharacterPool.Get();
                _poolCharacter[copy] = currentCharacterPool;
            }
            else
            {
                currentCharacterPool = new Pool<Character>();
                currentCharacterPool.IsActive = (Character item) =>
                {
                    return item && item.gameObject && item.gameObject.activeSelf;
                };
                if (copy != null)
                {
                    currentCharacterPool.Instantiate = () =>
                    {
                        if (_diContainer.InstantiatePrefab(copy).TryGetComponent<Character>(out Character instance))
                        {
                            return instance;
                        }
                        return null;
                    };
                }
                currentCharacter = currentCharacterPool.Get();
                _poolCharacter.Add(copy, currentCharacterPool);
            }
            currentCharacter.gameObject.transform.position = position;
            currentCharacter.gameObject.SetActive(true);
            return currentCharacter;
        }
    }
}

