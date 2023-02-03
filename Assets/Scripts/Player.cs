using System;
using System.Collections;
using System.Collections.Generic;
using Stats;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health health;

    public void Damage(float amount)
    {
        health.Value -= amount;
    }
}
