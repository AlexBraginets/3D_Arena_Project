using UnityEngine;
using Utils;

namespace Shooting.Bullets
{
    public class TargetBullet : MonoBehaviour
    {
        [SerializeField] private float powerDamage = 25f;
        [SerializeField] private float speed;
        private float _targetYOffset;
        private Transform _target;

        private bool _hasPlayerTeleported = false;

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
            ReferencesHolder.Instance.TeleportManager.OnPlayerTeleported += OnPlayerTeleported;
        }

        private void OnPlayerTeleported(Vector3 from, Vector3 to)
        {
            _hasPlayerTeleported = true;
            ReferencesHolder.Instance.TeleportManager.OnPlayerTeleported -= OnPlayerTeleported;
        }

        private Vector3 _lastDirectionToTarget;

        private void Update()
        {
            if (!_target) return;
            float dt = Time.deltaTime;
            var directionToTarget = _hasPlayerTeleported ? _lastDirectionToTarget : DirectionToTarget;
            Vector3 dPosition = speed * dt * directionToTarget;
            transform.position += dPosition;
            if (!_hasPlayerTeleported)
                _lastDirectionToTarget = DirectionToTarget;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            var player = ReferencesHolder.Instance.Player;
            if (!player) return;
            player.AddPower(-powerDamage);
            Destroy(gameObject);
        }
    }
}