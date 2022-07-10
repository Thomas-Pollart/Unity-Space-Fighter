using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public float Score { get => score; set { score = value; } }
    public float ScoreMultiplier { get => scoreMultiplier; set { scoreMultiplier = value; } }
    public float TimeSpentInTheCurrentSession { get => timeSpentInTheCurrentSession; }
    public static GameManager Instance { get => instance; }

    private static GameManager instance;
    private PlayerController playerController;
    private AudioSource audioSource;
    private float scoreMultiplier = 5f;
    private float timeSpentInTheCurrentSession = 0f;
    private float score = 0f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        DefaultConfigurationInit();

        SceneManager.activeSceneChanged += GetTypes;
    }

    private void GetTypes(Scene arg0, Scene arg1)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            playerController = FindObjectOfType<PlayerController>();

            playerController.GameOverEvent += GameOverEvent;
        }
    }

    private void GameOverEvent()
    {
        score = timeSpentInTheCurrentSession * scoreMultiplier;
        timeSpentInTheCurrentSession = 0f;
    }

    private void DefaultConfigurationInit()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        Application.targetFrameRate = 60;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            timeSpentInTheCurrentSession += Time.deltaTime;

        CheckNextSceneToLoad();
    }

    private void CheckNextSceneToLoad()
    {
        var mainScene = SceneManager.GetSceneByBuildIndex(0);
        var levelScene = SceneManager.GetSceneByBuildIndex(1);

        var startButtonPressed = Input.GetKeyDown(KeyCode.Joystick1Button9);
        var enterKeyPressed = Input.GetKeyDown(KeyCode.Return);

        if (startButtonPressed || enterKeyPressed)
        {
            if (SceneManager.GetActiveScene() == mainScene)
            {
                SceneManager.LoadScene(1);
            }

            if (SceneManager.GetActiveScene() == levelScene)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

