using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text highScoreText;
    
    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("highscore").ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake() {
        Time.timeScale = 1; 
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
