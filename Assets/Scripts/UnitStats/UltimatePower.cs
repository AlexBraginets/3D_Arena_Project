using System;
using Data;
using UnityEngine;

namespace UnitStats
{
    public class UltimatePower : MonoBehaviour
    {
        [SerializeField] private UltimatePowerConfig _config;
        private float MaxPower => _config.MaxPower;
        public float RelativePower => Value / MaxPower;
        public event Action<float> OnChanged;
        public event Action<float> OnMaxPower;
        private float _value;
        private const float TOLERANCE = Single.Epsilon * 10f;

        private void Start()
        {
           Init();
        }

        private void Init()
        {
            Value = _config.InitialPower;
        }

        public float Value
        {
            get => _value;
            set
            {
                if (Mathf.Abs(value - _value) < TOLERANCE) return;
                _value = Mathf.Clamp(value, 0f, MaxPower);
                OnChanged?.Invoke(_value);
                if (Mathf.Abs(_value - MaxPower) < TOLERANCE)
                {
                    OnMaxPower?.Invoke(MaxPower);
                }
            }
        }
    }
}