using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HiscoreScene : MonoBehaviour
{
    // The text box that will display the high scores
    public Text textBox;

    public Button oneMinButton;
    public Button thirtySecButton;
    public Button homeButton;

    void Start()
    {
        // Add a listener for when the 1 minute button is clicked
        oneMinButton.onClick.AddListener(delegate
        {
            oneMinButton.interactable = false;
            thirtySecButton.interactable = true;

            // Retrieve the high scores for the 1 minute game mode from PlayerPrefs
            int score1 = PlayerPrefs.GetInt("1mScore1");
            int score2 = PlayerPrefs.GetInt("1mScore2");
            int score3 = PlayerPrefs.GetInt("1mScore3");
            int score4 = PlayerPrefs.GetInt("1mScore4");
            int score5 = PlayerPrefs.GetInt("1mScore5");

            // Display the high scores in the text box
            //textBox.text = "1. " + score1 + "\n2. " + score2 + "\n3. " + score3 + "\n4. " + score4 + "\n5. " + score5;
            textBox.text = "1. " + score1.ToString() + "\n2. " + score2.ToString() + "\n3. " + score3.ToString() + "\n4. " + score4.ToString() + "\n5. " + score5.ToString();
        });

        // Add a listener for when the 30 second button is clicked
        thirtySecButton.onClick.AddListener(delegate
        {
            oneMinButton.interactable = true;
            thirtySecButton.interactable = false;

            // Retrieve the high scores for the 30 second game mode from PlayerPrefs
            int score1 = PlayerPrefs.GetInt("30sScore1");
            int score2 = PlayerPrefs.GetInt("30sScore2");
            int score3 = PlayerPrefs.GetInt("30sScore3");
            int score4 = PlayerPrefs.GetInt("30sScore4");
            int score5 = PlayerPrefs.GetInt("30sScore5");

            // Display the high scores in the text box
            textBox.text = "1. " + score1.ToString() + "\n2. " + score2.ToString() + "\n3. " + score3.ToString() + "\n4. " + score4.ToString() + "\n5. " + score5.ToString();
        });

        // Add onClick event listener for the home button
        homeButton.onClick.AddListener(LoadHomeScene);
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
