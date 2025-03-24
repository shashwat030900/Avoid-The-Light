    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        public GameObject gameOverUI;
        public GameObject gameWinUI;
        public float surviveTime = 10f;

        private void Start()
        {
             gameOverUI.SetActive(false); 
             gameWinUI.SetActive(false);   

            Invoke(nameof(GameWin), surviveTime);
        }

        public void GameOver()
    {
        Debug.Log("GameOver() function triggered.");

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("Game Over UI is now active.");
            Time.timeScale = 0f; 
        }
        else
        {
            Debug.LogError("GameOver UI is NOT assigned in GameManager!");
        }
}

        public void GameWin()
        {
            if (gameWinUI != null) gameWinUI.SetActive(true);
            Time.timeScale = 0f; 
        }

        public void RestartGame()
        {
            Debug.Log("Restart Button Clicked!");
            Time.timeScale = 1f; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
