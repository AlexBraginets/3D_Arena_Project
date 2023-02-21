using Stats;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private UltimatePower ultimatePower;

    public void Damage(float amount)
    {
        health.Value -= amount;
    }

    public void AddPower(float amount)
    {
        Debug.LogError($"add power: {amount}");
        ultimatePower.Value += amount;
    }
}
