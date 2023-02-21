using Enemies;
using UnityEngine;

namespace Shooting.Bullets
{
    public class BallisticBullet : MonoBehaviour
    {
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
            enemy.Kill();
        }
    }
}