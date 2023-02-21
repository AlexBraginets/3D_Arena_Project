using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class UltimatePowerConfig : ScriptableObject
    {
        [SerializeField] private float initialPower;
        [SerializeField] private float maxPower;
        public float InitialPower => initialPower;
        public float MaxPower => maxPower;

    }
}
