using UnityEngine;
using Utils;

namespace UI
{
    public class UIVisibilityController : MonoBehaviour
    {
        [SerializeField] private GameObject MobileInputCanvas;
        private bool _isMobileInputCanvasActiveByDefault;

        private void Awake()
        {
            _isMobileInputCanvasActiveByDefault = MobileInputCanvas.activeSelf;
            if (!_isMobileInputCanvasActiveByDefault) return;
            ReferencesHolder.Instance.gameManager.OnGamePaused += OnGamePaused;
            ReferencesHolder.Instance.gameManager.OnGameResumed += OnGameResumed;
        }

        private void OnGamePaused()
        {
            MobileInputCanvas.SetActive(false);
        }

        private void OnGameResumed()
        {
            MobileInputCanvas.SetActive(true);
        }
    }
}