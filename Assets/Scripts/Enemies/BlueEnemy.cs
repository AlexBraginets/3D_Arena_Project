using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Enemies
{
    public class BlueEnemy : Enemy
    {
        [SerializeField] private NavMeshAgent _agent;
        private Transform _target;
        protected override void Awake()
        {
            base.Awake();
            Player player = ReferencesHolder.Instance.Player;
            SetTarget(player.transform);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            if (!_target) return;
            _agent.SetDestination(_target.position);
        }
    }
}
