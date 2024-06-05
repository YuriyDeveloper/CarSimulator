using UnityEngine;

namespace Scripts.Characters.Common
{
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private int _distanceToAttack;
        [SerializeField] private int _moveSpeed;
        [SerializeField] private int _health;
        [SerializeField] private int _xpForKill;
      

        public CharacterType CharacterType => _characterType;
        public int DistanceToAttack => _distanceToAttack;
        public int MoveSpeed => _moveSpeed;
        public int Health => _health; 
        public int XPForKill => _xpForKill;
       

    }
}

