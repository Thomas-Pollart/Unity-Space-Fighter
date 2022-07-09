using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    PlayerController player;
    GameManager gameManager;

    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Instruction;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();

        GameOverText.enabled = false;
        ScoreText.enabled = false;
        Instruction.enabled = false;
        Timer.enabled = true;

        player.GameOver += GameOverUIEvent;
    }

    private float timeSession = 0f;

    private void Update()
    {
        timeSession += Time.deltaTime;
        Timer.text = $"{timeSession.ToString("0")}";
    }

    private void GameOverUIEvent()
    {
        gameManager.Score = timeSession * 5;

        ScoreText.enabled = true;
        GameOverText.enabled = true;
        Instruction.enabled = true;
        Timer.enabled = false;

        timeSession = 0f;

        ScoreText.text = $"Score {gameManager.Score}";
    }

    private void OnDisable()
    {
        player.GameOver -= GameOverUIEvent;
    }
}
