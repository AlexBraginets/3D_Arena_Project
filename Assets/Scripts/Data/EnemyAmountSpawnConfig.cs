using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class EnemyAmountSpawnConfig : ScriptableObject
    {
        [SerializeField] private EnemyDelaySpawnConfig delayConfig;
        [SerializeField] private float enemyAmountIncreaseRate;
        public int GetEnemySpawnAmount(float time)
        {
            if (!delayConfig.IsMinDelayBetweenSpawnsReached(time)) return 1;
            float enemyAmount = 1 + enemyAmountIncreaseRate * (time - delayConfig.TransitionTime);
            return Mathf.CeilToInt(enemyAmount);
        }
    }
}
