using UnityEngine;
using Utils;

namespace Visibility
{
    [DefaultExecutionOrder(-1)]
    public class PlayerVisibilityDetector : MonoBehaviour
    {
        [SerializeField] private bool _isVisible;
        [SerializeField] private LayerMask _raycastMask;
        [SerializeField] private float _maxRaycastDistance = 20f;
        public bool IsVisible { get; private set; }
        private Transform _player;

        private void Awake()
        {
            var player = ReferencesHolder.Instance.Player.transform;
            SetPlayer(player);
        }

        public void SetPlayer(Transform player)
        {
            _player = player;
        }

        private void Update()
        {
            if (!_player) return;
            var rayOrigin = transform.position;
            var rayDirection = _player.position - transform.position;
            Ray ray = new Ray(rayOrigin, rayDirection);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxRaycastDistance, _raycastMask))
            {
                IsVisible = hit.collider.CompareTag("Player");
            }
            else
            {
                Debug.LogError("Not possible.");
                IsVisible = false;
            }

            _isVisible = IsVisible;
        }

        private void OnDrawGizmosSelected()
        {
            if (!_player) return;
            var rayOrigin = transform.position;
            var rayDirection = _player.position - transform.position;
            Ray ray = new Ray(rayOrigin, rayDirection);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxRaycastDistance, _raycastMask))
            {
                IsVisible = hit.collider.CompareTag("Player");
                Vector3 from = transform.position;
                Vector3 to = hit.point;
                Gizmos.color = IsVisible ? Color.green : Color.red;
                Gizmos.DrawLine(from, to);
            }
            else
            {
                Debug.LogError("Not possible.");
                IsVisible = false;
            }
        }
    }
}