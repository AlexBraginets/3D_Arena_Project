using System.Collections;
using Enemies;
using UnityEngine;
using Utils;

namespace Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _spawnTime;
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
            var wait = new WaitForSeconds(_spawnTime);
            while (true)
            {
                yield return wait;
                Spawn();
            }
        }

        private void Spawn()
        {
            var spawnPosition = GetRandomSpawnPosition();
            var enemyPrefab = _enemyPrefab;
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