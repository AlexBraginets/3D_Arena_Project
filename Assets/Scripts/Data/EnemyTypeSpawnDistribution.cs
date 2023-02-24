using System;
using Enums;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class EnemyTypeSpawnDistribution : ScriptableObject
    {
        [SerializeField] private EnemyTypeCummulativePair[] distribution;

        public EnemyType GetEnemyType(float rnd)
        {
            for (int i = 0; i < distribution.Length; i++)
            {
                if (rnd <= distribution[i].cummulative) return distribution[i].type;
            }

            throw new NotImplementedException();
        }

        [System.Serializable]
        public class EnemyTypeCummulativePair
        {
            public EnemyType type;
            public float cummulative;
        }
    }
}