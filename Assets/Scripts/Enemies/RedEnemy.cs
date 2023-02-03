using System;
using System.Collections;
using System.Runtime.InteropServices;
using DG.Tweening;
using Enemies.Data;
using UnityEngine;

namespace Enemies
{
    public class RedEnemy : Enemy
    {
        private void Awake()
        {
            Attack(_player);
        }

        [SerializeField] private RedEnemyData config;
        [SerializeField] private Transform _player;
        private void Setup(Transform player)
        {
            _player = player;
        }

        public void Attack(Transform player)
        {
            Setup(player);
            StartCoroutine(AttackCorout());
        }

        private IEnumerator AttackCorout()
        {
            yield return FlyAbove();
            yield return Pause();
            yield return ChasePlayer();
        }

        private IEnumerator Pause()
        {
            yield return new WaitForSeconds(config.PauseDuration);
        }

        private IEnumerator ChasePlayer()
        {
            float simulaitonStep = .025f;
            WaitForSeconds wait = new WaitForSeconds(simulaitonStep);
            while (true)
            {

                yield return wait;
                Vector3 direction = (_player.position - transform.position).normalized;
                transform.position += direction * config.AttackSpeed * simulaitonStep;
            }
        }
        private IEnumerator FlyAbove()
        {
            float yOffset = config.FlyAboveOffset;
            float duration = config.FlyAboveDuration;
            float y = transform.position.y;
            float yEnd = y + yOffset;
            transform.DOMoveY(yEnd, duration);
            yield return new WaitForSeconds(duration);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.IsPlayer()) return;
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
