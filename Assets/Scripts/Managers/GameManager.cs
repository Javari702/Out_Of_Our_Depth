using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private string sceneReloadKey;

    public delegate void RestartFromCheckpoint();
    public static RestartFromCheckpoint restartFromCheckpoint;

    void Awake()
    {
        makeGameManagerSingleton();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(sceneReloadKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(sceneReloadKey))
        {
            restartFromCheckpoint?.Invoke();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    
    private void makeGameManagerSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
