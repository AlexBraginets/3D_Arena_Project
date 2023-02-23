using Data;
using UnitStats;
using UnityEngine;

public class ReferencesInjector : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private BallisticBulletBehaviourConfig _config;

    private void Awake()
    {
        _config.SetHealth(_playerHealth);
    }
}
