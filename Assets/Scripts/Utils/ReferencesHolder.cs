using Enemies;
using Metrics;
using UnityEngine;

namespace Utils
{
    [DefaultExecutionOrder(-1000)]
    public class ReferencesHolder : MonoBehaviour
    {
        public Player Player;
        public ProximityEnemyProvider ProximityEnemyProvider;
        public EnemiesList EnemiesList;
        public static ReferencesHolder Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}