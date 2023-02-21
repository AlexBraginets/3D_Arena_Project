using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StatDisplays
{
    public class UltimatePowerDisplay : MonoBehaviour
    {
        [SerializeField] private UltimatePower ultimatePower;
        [SerializeField] private Image ultimatePowerBar;

        public void SetUltimatePower(UltimatePower ultimatePower)
        {
            this.ultimatePower = ultimatePower;
            if (ultimatePower)
            {
                ultimatePower.OnChanged -= UpdateUI;
            }

            ultimatePower.OnChanged += UpdateUI;
        }

        private void Awake()
        {
            if (ultimatePower)
            {
                SetUltimatePower(ultimatePower);
            }
        }

        private void UpdateUI(float ultimatePower)
        {
            ultimatePowerBar.fillAmount = this.ultimatePower.RelativePower;
        }
    }
}
