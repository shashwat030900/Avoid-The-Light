using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button button; 
    private void Start()  
    {
        button.onClick.AddListener(StartButton);
    }

    private void StartButton()  
    {
        SceneManager.LoadScene(1);
    }
}
