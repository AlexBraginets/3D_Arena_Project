using SessionStats;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverDisplay : MonoBehaviour
    {
        [SerializeField] private SessionStatsManager _sessionStatsManager;
        [SerializeField] private TMP_Text killedEnemiesLabel;

        public void Show()
        {
            gameObject.SetActive(true);
            int killedEnemiesAmount = _sessionStatsManager.Stats.EnemiesKilled;
            killedEnemiesLabel.text = $"Enemies killed: {killedEnemiesAmount}";
        }
    }
}