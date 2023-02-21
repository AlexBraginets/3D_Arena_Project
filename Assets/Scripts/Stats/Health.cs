using System;
using Data;
using UnityEngine;

namespace Stats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private HealthConfig _config;
        public float RelativeHealth => Value / MaxHealth;
        public event Action<float> OnChanged;
        public event Action OnDied;
        private float _value;
        private const float TOLERANCE = Single.Epsilon * 10f;
        private float MaxHealth => _config.MaxHealth;
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            Value = _config.InitialHealth;
        }

        public float Value
        {
            get => _value;
            set
            {
                if (Math.Abs(value - _value) < TOLERANCE) return;
                _value = Mathf.Clamp(value, 0f, MaxHealth);
                OnChanged?.Invoke(_value);
                if (_value <= TOLERANCE)
                {
                    OnDied?.Invoke();
                }
            }
        }
    }
}