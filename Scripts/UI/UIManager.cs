using Scripts.Characters.Common;
using UnityEngine;

namespace Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _buttonRestart;

        private void OnEnable()
        {
            CharacterHealth.OnDeadMainPlayer += ShowGameOverPanel;
        }

        private void ShowGameOverPanel()
        {
            CharacterHealth.OnDeadMainPlayer -= ShowGameOverPanel;
            _gameOverPanel.SetActive(true);
            _buttonRestart.SetActive(true);
        }
    }

}
