using TMPro;
using UnityEngine;

public class GameOverGUI : MonoBehaviour
{
    private PlayerController playerController;
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI gameOverTMPro, scoreTMPro, timerTMPro, labelTMPro;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();

        playerController.GameOverEvent += GameOverGUIEvent;
        DefaultGUIConfig();
    }

    private void DefaultGUIConfig()
    {
        gameOverTMPro.enabled = false;
        scoreTMPro.enabled = false;
        labelTMPro.enabled = false;

        timerTMPro.enabled = true;
    }


    private void Update()
    {
        DisplayTheTimeCounterInGame();
    }

    private void DisplayTheTimeCounterInGame()
    {
        timerTMPro.text = $"{gameManager.TimeSpentInTheCurrentSession.ToString("0")}";
    }

    private void GameOverGUIEvent()
    {
        scoreTMPro.text = $"Score {gameManager.Score}";
        scoreTMPro.enabled = true;
        gameOverTMPro.enabled = true;
        labelTMPro.enabled = true;

        timerTMPro.enabled = false;
    }

    private void OnDisable()
    {
        playerController.GameOverEvent -= GameOverGUIEvent;
    }
}
