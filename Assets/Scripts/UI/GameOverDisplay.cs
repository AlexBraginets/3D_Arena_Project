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
        [SerializeField] private GamaManager _gameManager;

        private void Awake()
        {
            restartButton.onClick.AddListener(_gameManager.RestartLevel);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            int killedEnemiesAmount = _sessionStatsManager.Stats.EnemiesKilled;
            killedEnemiesLabel.text = $"Enemies killed: {killedEnemiesAmount}";
        }
    }
}