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
            var gameManager = ReferencesHolder.Instance.gameManager;
            pauseButton.onClick.AddListener(gameManager.PauseGame);
            resumeButton.onClick.AddListener(gameManager.ResumeGame);

            gameManager.OnGamePaused += OnGamePaused;
            gameManager.OnGameResumed += OnGameResumed;
        }

        private void OnGamePaused()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
        }

        private void OnGameResumed()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }
    }
}