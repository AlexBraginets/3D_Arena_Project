using Shooting.Weapons;
using UnitStats;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private BallisticBulletWeapon _weapon;
    [Header("Stats")] [SerializeField] private Health health;
    [SerializeField] private UltimatePower ultimatePower;

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _weapon.Shoot();
        }
    }

    public void Damage(float amount)
    {
        AddHealth(-amount);
    }

    public void AddHealth(float amout)
    {
        health.Value += amout;
    }

    public void AddPower(float amount)
    {
        ultimatePower.Value += amount;
    }
}