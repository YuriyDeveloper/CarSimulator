using UnityEngine;

namespace Scripts.Characters.MainPlayer
{
    public class MainPlayerCharacterLookDirection : MonoBehaviour
    {
        [SerializeField] private Transform _transformToRotate;

        private void Update()
        {
            RotateTowardsMouse();
        }

        private void RotateTowardsMouse()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = transform.position.z;
            Vector3 direction = mouseWorldPosition - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transformToRotate.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
