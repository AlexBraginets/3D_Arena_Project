using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class EnemyDelaySpawnConfig : ScriptableObject
    {
        [SerializeField] private float maxDelayBetweenSpawns = 5f;
        [SerializeField] private float minDelayBetweenSpawns = 2f;
        [SerializeField] private float transitionTime;
        public float TransitionTime=>transitionTime;
        public bool IsMinDelayBetweenSpawnsReached(float time) => time / transitionTime >= 1f;
        public float GetDelayBeforeNextSpawn(float time)
        {
            return Mathf.Lerp(minDelayBetweenSpawns, maxDelayBetweenSpawns, time / transitionTime);
        }
    }
}
