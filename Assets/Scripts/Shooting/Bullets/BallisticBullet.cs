using System;
using Data;
using Enemies;
using UnityEngine;
using Utils;

namespace Shooting.Bullets
{
    public class BallisticBullet : MonoBehaviour
    {
        [SerializeField] private BallisticBulletBehaviourConfig _config;
        [SerializeField] private float _gravity = 0f;
        private Vector3 _velocity;
        private LayerMask _targetMask;

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
            var enemy = other.GetComponent<Enemy>();
            if (!enemy) return;
            UpdateBehaviour(enemy);
            enemy.Kill();
        }

        private void UpdateBehaviour(Enemy enemy)
        {
            var behaviour = _config.Behaviour;
            switch (behaviour)
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