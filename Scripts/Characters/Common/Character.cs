using UnityEngine;

namespace Scripts.Characters.Common
{
    public enum CharacterType
    {
        MainPlayer,
        EnemySimple,
        EnemyMiddle
    }
    public class Character : MonoBehaviour
    {
        [SerializeField] protected CharacterData _characterData;

        public CharacterData CharacterData => _characterData;
    }

}
