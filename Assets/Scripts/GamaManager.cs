using UI;
using UnitStats;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameOverDisplay _gameOverDisplay;

    private void Awake()
    {
        _playerHealth.OnDied += _gameOverDisplay.Show;
    }
}