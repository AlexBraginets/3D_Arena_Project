using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class PauseUIController : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;

        private void Awake()
        {
            pauseButton.onClick.AddListener(PauseGame);
            resumeButton.onClick.AddListener(ResumeGame);
        }

        private void PauseGame()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
            var gameManager = ReferencesHolder.Instance.gameManager;
            gameManager.PauseGame();
        }

        private void ResumeGame()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            var gameManager = ReferencesHolder.Instance.gameManager;
            gameManager.ResumeGame();
        }
    }
}