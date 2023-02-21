using System;
using Shooting.Weapons;
using Stats;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private BallisticBulletWeapon _weapon;
    [Header("Stats")]
    [SerializeField] private Health health;
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
        health.Value -= amount;
    }

    public void AddPower(float amount)
    {
        ultimatePower.Value += amount;
    }
}
