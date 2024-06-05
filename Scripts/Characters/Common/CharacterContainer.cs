using Scripts.Characters.Common;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Characters
{
    public class CharacterContainer : MonoBehaviour
    {
        [SerializeField] private List<Character> _characterList;

        public Character GetCharacterCopy(CharacterType characternType)
        {
            foreach (Character character in _characterList)
            {
                if (character.CharacterData.CharacterType == characternType)
                {
                    return character;
                }
            }
            return null;
        }
    }
}

