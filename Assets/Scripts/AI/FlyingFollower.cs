using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class FlyingFollower : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform graphics;
        private Vector3 TargetPosition => _target.position + Vector3.up * 0.15f * 3f;
        private Vector3 CurrentPosition => graphics.position;

        private float Angle
        {
            get
            {
                var dPosition = TargetPosition - CurrentPosition;
                var dPlanePosition = dPosition;
                dPlanePosition.y = 0f;
                float dy = dPosition.y;
                float dxz = dPlanePosition.magnitude;
                return Mathf.Atan2(dy, dxz);
            }
        }

        private float cos => Mathf.Cos(Angle);
        private float sin => Mathf.Sin(Angle);
        private Transform _target;
        private float _speed;
        private Coroutine _followCorout;

        public void Follow(Transform target, float speed)
        {
            _target = target;
            _speed = speed;
        }

        private void Update()
        {
            if (!_target) return;
            // update destination
            _agent.destination = _target.position;
            // update y position
            graphics.transform.position += Vector3.up * _speed * sin * Time.deltaTime;
            // update xz plane speed
            _agent.speed = _speed * cos;
        }
    }
}