using UnityEngine;

namespace Enemies.Data
{
    [CreateAssetMenu]
    public class RedEnemyData : ScriptableObject
    {
        public float FlyAboveOffset;
        public float FlyAboveDuration;
        public float PauseDuration;
        public float AttackSpeed;
    }
}
