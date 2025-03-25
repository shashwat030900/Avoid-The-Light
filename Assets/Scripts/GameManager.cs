using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public TMP_Text survivalTimeText;
    public float surviveTime = 10f;

    private float elapsedTime = 0f;
    private bool isGameOver = false;

    private void Start()
    {
        if (gameOverUI != null) gameOverUI.SetActive(false);
        if (gameWinUI != null) gameWinUI.SetActive(false);

        elapsedTime = 0f;
        Invoke(nameof(GameWin), surviveTime);
    }
    
    void Awake()
    {
        
    }

    private void Update()
    {
    if (!isGameOver)
        {
        elapsedTime += Time.deltaTime;
        int timeElapsed = Mathf.FloorToInt(elapsedTime); 
        survivalTimeText.text = "Survival Time: " + timeElapsed + "s";

        }
    }



    public void GameOver()
    {
        isGameOver = true;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void GameWin()
        {
        isGameOver = true;

        if (gameWinUI != null)
        {
            gameWinUI.SetActive(true);
        }
        Time.timeScale = 0f;
        }

    public void RestartGame()
        {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    public void NextLevel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
}
