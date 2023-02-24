using System.Collections;
using Data;
using Enemies;
using UnityEngine;
using Utils;

namespace Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnConfig _config;
        [SerializeField] private Transform _spawnPoint;
        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            StartSpawning();
        }

        public void StartSpawning()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }

            _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                int spawnAmount = _config.GetSpawnAmount();
                for (int i = 0; i < spawnAmount; i++)
                {
                    Spawn();
                }
                float spawnTime = _config.GetSpawnDelay();
                yield return new WaitForSeconds(spawnTime);
            }
        }

        private void Spawn()
        {
            var spawnPosition = GetRandomSpawnPosition();
            var enemyPrefab = _config.GetPrefab();
            Spawn(spawnPosition, enemyPrefab);
        }


        private void Spawn(Vector3 position, Enemy enemyPrefab)
        {
            var player = ReferencesHolder.Instance.Player;
            var enemy = Instantiate(enemyPrefab);
            (enemy as RedEnemy)?.Place(position);
            (enemy as RedEnemy)?.Attack(player.transform);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return _spawnPoint.position;
        }
    }
}