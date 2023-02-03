using Stats;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected Health health;

        protected virtual void Awake()
        {
            health.OnDied += Die;
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
