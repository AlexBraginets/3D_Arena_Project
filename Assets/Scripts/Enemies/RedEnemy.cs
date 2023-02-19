using System.Collections;
using AI;
using DG.Tweening;
using Enemies.Data;
using UnityEngine;
using Utils;

namespace Enemies
{
    public class RedEnemy : Enemy
    {
        [SerializeField] private float damage;
        [SerializeField] private Transform graphics;
        [SerializeField] private ActionTrigger _actionTrigger;

        protected override void Awake()
        {
            base.Awake();
            SubscribeToOnTriggerEnter();

            var player = ReferencesHolder.Instance.Player;
            Attack(player.transform);
        }

        [SerializeField] private RedEnemyData config;
        [SerializeField] private Transform _player;
        [SerializeField] private FlyingFollower _flyingFollower;

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
            _flyingFollower.Follow(_player, config.AttackSpeed);
        }

        private IEnumerator Pause()
        {
            yield return new WaitForSeconds(config.PauseDuration);
        }


        private IEnumerator FlyAbove()
        {
            float yOffset = config.FlyAboveOffset;
            float duration = config.FlyAboveDuration;
            float y = graphics.position.y;
            float yEnd = y + yOffset;
            graphics.DOMoveY(yEnd, duration);
            yield return new WaitForSeconds(duration);
        }

        private void SubscribeToOnTriggerEnter()
        {
            _actionTrigger.OnTriggerEntered += other =>
            {
                Player player;
                if (!other.IsPlayer(out player)) return;
                player.Damage(damage);
                health.Value = 0;
            };
        }
    }
}