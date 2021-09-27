using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text bestTime;
    public Text timeText;
    public Text recordText;

    float surviveTime;
    bool isGameover;
    
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    
    void Update()
    {
        if (isGameover == false)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + $"{surviveTime:f3}";
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(bestTime <= surviveTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time: " + $"{bestTime:f3}";
        
    }
}
