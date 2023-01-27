using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    int highscore;
    public Text textScore;
    public Text lastScore;
    public Text highScore;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            score += Time.deltaTime;
        }
        else
        {
            score += Time.deltaTime * 5;
        }   
      
        if(Mathf.FloorToInt(score) > highscore)
        {
            highscore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt("highscore", highscore);
        } 

        textScore.text = Mathf.FloorToInt(score).ToString();
        lastScore.text = Mathf.FloorToInt(score).ToString();
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
        
    }

}
