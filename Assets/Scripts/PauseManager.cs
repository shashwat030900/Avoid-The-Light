using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;  
    public Button pauseButton;
    public Button resumeButton;
    public Button restartButton;

    private bool isPaused = false;

    private void Start()
    {
        
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);

        pauseMenu.SetActive(false);  
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;  
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1; 
            pauseMenu.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
