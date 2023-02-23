using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class SessionStatsInfo : ScriptableObject
    {
        public int EnemiesKilled = 0;
        public void ResetStats()
        {
            EnemiesKilled = 0;
        }
    }
}
