using System;
using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StatDisplays
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Image healthBar;

        public void SetHealth(Health health)
        {
            this.health = health;
            if (health)
            {
                health.OnChanged -= UpdateUI;
            }

            health.OnChanged += UpdateUI;
        }

        private void Awake()
        {
            if (health)
            {
                SetHealth(health);
            }
        }

        private void UpdateUI(float health)
        {
            healthBar.fillAmount = this.health.RelativeHealth;
            Debug.LogError($"health = {health}");
        }
    }
}
