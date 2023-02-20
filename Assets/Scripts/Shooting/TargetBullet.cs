using UnityEngine;

namespace Shooting
{
    public class TargetBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        private float _targetYOffset; 
        private Transform _target;

        private Vector3 DirectionToTarget
        {
            get
            {
                var from = transform.position;
                var to = _target.position + Vector3.up * _targetYOffset;
                return (to - from).normalized;
            }
        }
        public void SetTarget(Transform target, float yOffset)
        {
            _target = target;
            _targetYOffset = yOffset;
        }

        private void Update()
        {
            if (!_target) return;
            float dt = Time.deltaTime;
            Vector3 dPosition = speed * dt * DirectionToTarget;
            transform.position += dPosition;
        }
    }
}
