using System;
using UI;
using UnitStats;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameOverDisplay _gameOverDisplay;

    private void Awake()
    {
        _playerHealth.OnDied += _gameOverDisplay.Show;
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Debug.LogError("SceneManager.LoadScene(0)");
    }
}