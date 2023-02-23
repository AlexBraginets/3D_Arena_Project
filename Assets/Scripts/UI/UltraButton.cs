using System;
using Enemies;
using UnitStats;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class UltraButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private UltimatePower _ultimatePower;
        [SerializeField] private EnemiesDestroyer _enemiesDestroyer;

        private void Awake()
        {
            _ultimatePower.OnMaxPower += Show;
            _button.onClick.AddListener(UseUltraAbility);
        }

        private void Update()
        {
            if (Keyboard.current.gKey.wasPressedThisFrame)
            {
                if (_ultimatePower.RelativePower > .99f)
                {
                    UseUltraAbility();
                    _ultimatePower.Value = 0f;
                }
            }
        }

        private void UseUltraAbility()
        {
            Hide();
            _enemiesDestroyer.KillAllEnemies();
        }

        private void Show(float maxPower) => _button.gameObject.SetActive(true);

        private void Hide() => _button.gameObject.SetActive(false);
    }
}