using System;
using UnitStats;
using UnityEngine;
using Utils;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected Health health;
        public static event Action<Enemy> OnEnemyDied;
        public virtual Vector3 Position => transform.position;
        protected virtual void Awake()
        {
            health.OnDied += Die;
            Register();
        }

        protected virtual void Die()
        {
            OnEnemyDied?.Invoke(this);
            Destroy(gameObject);
        }

        public void Kill()
        {
            health.Value = 0f;
        }

        protected void OnDestroy()
        {
            Unregister();
        }

        private void Register()
        {
            ReferencesHolder.Instance.EnemiesList.RegisterEnemy(this);
        }

        private void Unregister()
        {
            ReferencesHolder.Instance.EnemiesList.UnregisterEnemy(this);
        }
    }
}
