using System.Linq;
using Enemies;
using Enums;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class EnemySpawnConfig : ScriptableObject
    {
        [SerializeField] private EnemyTypePrefabPair[] _prefabPairs;
        [SerializeField] private EnemyTypeSpawnDistribution _typeDistribution;
        [SerializeField] private EnemyAmountSpawnConfig _amountConfig;
        [SerializeField] private EnemyDelaySpawnConfig _delayConfig;

        private float Time => UnityEngine.Time.time;

        public Enemy GetPrefab()
        {
            var rnd = Random.value;
            var type = _typeDistribution.GetEnemyType(rnd);
            return _prefabPairs.First(pair => pair.type == type).prefab;
        }

        public float GetSpawnDelay() => _delayConfig.GetDelayBeforeNextSpawn(Time);
        public int GetSpawnAmount() => _amountConfig.GetEnemySpawnAmount(Time);

        [System.Serializable]
        private class EnemyTypePrefabPair
        {
            public EnemyType type;
            public Enemy prefab;
        }
    }
}