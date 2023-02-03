using System;
using UnityEngine;

namespace Stats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float initialHealth;
        public event Action<float> OnChanged;
        public event Action OnDied;
        private float _value;
        private const float TOLERANCE = Single.Epsilon * 10f;

        private void Start()
        {
            Value = initialHealth;
        }

        public float Value
        {
            get => _value;
            set
            {
                if (Math.Abs(value - _value) < TOLERANCE) return;
                _value = Mathf.Clamp(value, 0f, float.MaxValue);
                OnChanged?.Invoke(value);
                if (_value <= TOLERANCE)
                {
                    OnDied?.Invoke();
                }
            }
        }
    }
}