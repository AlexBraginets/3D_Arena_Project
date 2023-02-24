using Enemies;
using Metrics;
using Teleportation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utils
{
    [DefaultExecutionOrder(-1000)]
    public class ReferencesHolder : MonoBehaviour
    {
        public Player Player;
        public ProximityEnemyProvider ProximityEnemyProvider;
        public EnemiesList EnemiesList;
        public TeleportManager TeleportManager;
        [FormerlySerializedAs("GamaManager")] public GameManager gameManager;
        public static ReferencesHolder Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}