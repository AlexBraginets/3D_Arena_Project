using UnityEngine;

namespace Shooting.Bullets
{
    public class BallisticBullet : MonoBehaviour
    {
        [SerializeField] private float _gravity = 0f;
        private Vector3 _velocity;

        public void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
        }

        private void Update()
        {
            float dt = Time.deltaTime;
            _velocity.y -= _gravity * dt;
            transform.position += _velocity * dt;
        }
    }
}