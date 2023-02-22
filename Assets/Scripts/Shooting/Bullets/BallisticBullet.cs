using System;
using Data;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Shooting.Bullets
{
    public class BallisticBullet : MonoBehaviour
    {
        [FormerlySerializedAs("_config")] [SerializeField] private BallisticBulletBehaviourConfig _behaviourConfig;
        [SerializeField] private BallisticBulletRewardConfig _rewardConfig;
        [SerializeField] private float _gravity = 0f;
        private Vector3 _velocity;
        private LayerMask _targetMask;
        private BallisticBulletBehaviour _behaviour = BallisticBulletBehaviour.Destruction;
        public void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
        }

        public void SetTargetMask(LayerMask targetMask)
        {
            _targetMask = targetMask;
        }

        private void Update()
        {
            float dt = Time.deltaTime;
            _velocity.y -= _gravity * dt;
            transform.position += _velocity * dt;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (2 << ((other.gameObject.layer - 1)) != _targetMask) return;
            var enemyReference = other.GetComponent<EnemyReference>();
            if(!enemyReference) return;
            var enemy = enemyReference.Reference;
            PowerupPlayer();
            UpdateBehaviour(enemy);
            enemy.Kill();
        }

        private void PowerupPlayer()
        {
            if (_behaviour != BallisticBulletBehaviour.Ricochet) return;
            var player = ReferencesHolder.Instance.Player;
            _rewardConfig.ApplyReward(player);
        }
        private void UpdateBehaviour(Enemy enemy)
        {
            _behaviour = _behaviourConfig.Behaviour;
            switch (_behaviour)
            {
                case BallisticBulletBehaviour.Unchanged:
                    break;
                case BallisticBulletBehaviour.Ricochet:
                    float speed = _velocity.magnitude;
                    var closestEnemy =
                        ReferencesHolder.Instance.ProximityEnemyProvider.ClosestEnemy(transform.position, enemy);
                    if (closestEnemy == null) return;
                    Vector3 direction = (closestEnemy.Position - transform.position).normalized;
                    SetVelocity(speed * direction);
                    break;
                case BallisticBulletBehaviour.Destruction:
                    Destroy(gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}