using System;
using UnityEngine;

namespace Stats
{
    public class UltimatePower : MonoBehaviour
    {
        [SerializeField] private float initialPower;
        [SerializeField] private float maxPower;
        public float RelativePower => Value / maxPower;
        public event Action<float> OnChanged;
        public event Action<float> OnMaxPower;
        private float _value;
        private const float TOLERANCE = Single.Epsilon * 10f;

        private void Start()
        {
            Value = initialPower;
        }

        public float Value
        {
            get => _value;
            set
            {
                if (Mathf.Abs(value - _value) < TOLERANCE) return;
                _value = Mathf.Clamp(value, 0f, maxPower);
                OnChanged?.Invoke(_value);
                if (Mathf.Abs(_value - maxPower) < TOLERANCE)
                {
                    OnMaxPower?.Invoke(maxPower);
                }
            }
        }
    }
}