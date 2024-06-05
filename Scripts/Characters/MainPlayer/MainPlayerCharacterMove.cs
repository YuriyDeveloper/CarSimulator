using Scripts.Characters.Common;
using UnityEngine;

namespace Scripts.Characters.MainPlayer
{
    public class MainPlayerCharacterMove : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        private static Transform _transform; 
        
        private float _moveSpeed = 5f;

        public static Transform Transform => _transform;

        private void OnEnable()
        {
            _moveSpeed = GetComponent<Character>().CharacterData.MoveSpeed;
            _transform = gameObject.transform;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis(Horizontal);
            float moveVertical = Input.GetAxis(Vertical);
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            if (movement.magnitude > 1)
            {
                movement = movement.normalized;
            }
            transform.Translate(movement * _moveSpeed * Time.deltaTime, Space.World);
            if (_transform)
            { 
                _transform.position = transform.position;

            }
          
        }
    }

}
