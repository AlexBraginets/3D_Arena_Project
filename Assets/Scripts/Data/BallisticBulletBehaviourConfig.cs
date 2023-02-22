using Shooting.Bullets;
using Stats;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class BallisticBulletBehaviourConfig : ScriptableObject
    {
        [SerializeField] private float minProbability;
        [SerializeField] private float maxProbability;
        private Health _playerHealth;

        public void SetHealth(Health playerHealth)
        {
            _playerHealth = playerHealth;
        }

        public BallisticBulletBehaviour Behaviour
        {
            get
            {
                var rnd = Random.value;
                var thresholdRnd = Mathf.Lerp(maxProbability, minProbability, _playerHealth.RelativeHealth);
                if (rnd < thresholdRnd)
                {
                    rnd = Random.value;
                    return rnd < .5f ? BallisticBulletBehaviour.Ricochet : BallisticBulletBehaviour.Unchanged;
                }
                else
                {
                    return BallisticBulletBehaviour.Destruction;
                }
            }
        }
    }
}