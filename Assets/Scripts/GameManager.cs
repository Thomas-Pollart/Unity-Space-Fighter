using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static AudioSource audioSource;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private PlayerController playerController;
    private GameUI userInterface;

    public float Score { get; set; }


    private void Start()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();

        SceneManager.activeSceneChanged += ReloadAssignementEvent;


        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                SceneManager.LoadScene("InGame");
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            if (SceneManager.GetActiveScene().name == "InGame")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void ReloadAssignementEvent(Scene arg0, Scene arg1)
    {
        print($"Changement de scène détecté. Scène {SceneManager.GetActiveScene().name} chargée.");

        if (SceneManager.GetSceneByName("InGame").isLoaded)
        {
            playerController = FindObjectOfType<PlayerController>();
            userInterface = FindObjectOfType<GameUI>();
        }
    }
}

