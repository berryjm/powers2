using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HomeScene : MonoBehaviour
{
    public Button expButton;
    public Button ansButton;
    public Button timer1mButton;
    public Button timer30sButton;
    public Button playButton;

    void Start()
    {
        // Set the initial state of the buttons based on the PlayerPrefs values
        expButton.interactable = !PlayerPrefs.GetString("mode").Equals("exp");
        ansButton.interactable = !PlayerPrefs.GetString("mode").Equals("ans");
        timer1mButton.interactable = !PlayerPrefs.GetInt("timer").Equals(60);
        timer30sButton.interactable = !PlayerPrefs.GetInt("timer").Equals(30);

        // Add onClick event listeners for the mode buttons
        expButton.onClick.AddListener(SetExpMode);
        ansButton.onClick.AddListener(SetAnsMode);

        // Add onClick event listeners for the timer buttons
        timer1mButton.onClick.AddListener(SetTimer1m);
        timer30sButton.onClick.AddListener(SetTimer30s);

        // Add onClick event listener for the play button
        playButton.onClick.AddListener(LoadPlayScene);
    }

    public void SetExpMode()
    {
        // Set the mode to "exp" and update the button interactability
        PlayerPrefs.SetString("mode", "exp");
        expButton.interactable = false;
        ansButton.interactable = true;
    }

    public void SetAnsMode()
    {
        // Set the mode to "ans" and update the button interactability
        PlayerPrefs.SetString("mode", "ans");
        ansButton.interactable = false;
        expButton.interactable = true;
    }

    public void SetTimer1m()
    {
        // Set the timer to 1 minute and update the button interactability
        PlayerPrefs.SetInt("timer", 60);
        timer1mButton.interactable = false;
        timer30sButton.interactable = true;
    }

    public void SetTimer30s()
    {
        // Set the timer to 30 seconds and update the button interactability
        PlayerPrefs.SetInt("timer", 30);
        timer30sButton.interactable = false;
        timer1mButton.interactable = true;
    }

    public void LoadPlayScene()
    {
        // Set the default mode to "ans" if it is not already set
        if (!PlayerPrefs.HasKey("mode"))
        {
            PlayerPrefs.SetString("mode", "ans");   
        }

        // Set the default timer to "30s" if it is not already set
        if (!PlayerPrefs.HasKey("timer"))
        {
            PlayerPrefs.SetInt("timer", 30);
        }

        // Load the play scene
        SceneManager.LoadScene("PlayScene");
    }
}