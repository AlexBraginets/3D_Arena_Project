using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class HealthConfig : ScriptableObject
    {
        [SerializeField] private float initialHealth;
        [SerializeField] private float maxHealth;
        public float InitialHealth => initialHealth;
        public float MaxHealth => maxHealth;
    }
}