using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class CharacterHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _imageBar;

        public void UpdateHealth(int startingHealthValue, int decreaseValue)
        {
            if (decreaseValue == 0)
            {
                _imageBar.fillAmount = 100;
            }
            else
            {
                float percentageDecrease = ((float)decreaseValue / startingHealthValue) * 100;
                _imageBar.fillAmount -= percentageDecrease / 100;
            }
            
        }
    }
}

