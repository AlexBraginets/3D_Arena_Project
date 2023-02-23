using Data;
using Enemies;
using UnityEngine;

namespace SessionStats
{
    public class SessionStatsManager : MonoBehaviour
    {
        [SerializeField] private SessionStatsInfo _stats;
        public SessionStatsInfo Stats => _stats;
        private void Awake()
        {
            _stats.ResetStats();
            Enemy.OnEnemyDied += OnEnemyDied;
        }

        private void OnDestroy()
        {
            Enemy.OnEnemyDied -= OnEnemyDied;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            _stats.EnemiesKilled++;
        }
        
    }
}
