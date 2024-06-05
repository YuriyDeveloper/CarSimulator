using Scripts.Characters.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class MainPlayerXP : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void OnEnable()
        {
            CharacterHealth.OnDeadEnemy += Increase;
        }

        private void OnDisable()
        {
            CharacterHealth.OnDeadEnemy -= Increase;
        }

        private void Increase(int xp)
        {
            int currentXp = int.Parse(_text.text);
            currentXp += xp;
            _text.text = currentXp.ToString();
        }
    }

}
