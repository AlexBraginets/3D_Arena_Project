using System;
using UI;
using UnitStats;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameOverDisplay _gameOverDisplay;
    public event Action OnGamePaused;
    public event Action OnGameResumed;
    private void Awake()
    {
        _playerHealth.OnDied += _gameOverDisplay.Show;
        _playerHealth.OnDied += PauseGame;
    }

    private void Update()
    {
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
    }

    private Player Player => ReferencesHolder.Instance.Player;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Player.gameObject.SetActive(false);
        OnGamePaused?.Invoke();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Player.gameObject.SetActive(true);
        OnGameResumed?.Invoke();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}