using System;
using SessionStats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverDisplay : MonoBehaviour
    {
        [SerializeField] private SessionStatsManager _sessionStatsManager;
        [SerializeField] private TMP_Text killedEnemiesLabel;
        [SerializeField] private Button restartButton;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _pauseUIController;

        private void Awake()
        {
            restartButton.onClick.AddListener(_gameManager.RestartLevel);
        }

        public void Show()
        {
            _pauseUIController.SetActive(false);
            gameObject.SetActive(true);
            int killedEnemiesAmount = _sessionStatsManager.Stats.EnemiesKilled;
            killedEnemiesLabel.text = $"Enemies killed: {killedEnemiesAmount}";
        }
    }
}