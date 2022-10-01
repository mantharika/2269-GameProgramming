using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    
    [SerializeField] public int PlayerLives = 3;
    [SerializeField] private LiveDisplay liveDisplays;
    [SerializeField] private Transform livesText;
    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateLives();
    }

    private void Update()
    {
        if(PlayerLives <= 0)
        {
            Destroy(gameObject);
            LoadScene(0);
        }

        if(GetCurrentBuildIndex() == 0)
        {
            livesText.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            livesText.gameObject.SetActive(true);
        }
    } 

    public void ProcessPlayerDeath()
    {
        UpdateLives();
        LoadScene(GetCurrentBuildIndex());
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        LoadScene(nextSceneIndex);
        UpdateLives();
    }

    public int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int buildindex)
    {
        UpdateLives();
        SceneManager.LoadScene(buildindex);
        DOTween.KillAll();
    }

    public void DeLive()
    {
        UpdateLives();
        PlayerLives -= 1;
    }

    public void UpdateLives()
    {
        liveDisplays.UpdatePoint(PlayerLives);
    }
    
}
