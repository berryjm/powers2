using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayScene : MonoBehaviour
{
    // The mode the user has selected (passed from the home screen)
    public string mode;

    // The timer mode the user has selected (passed from the home screen)
    public int timer;

    // The text component to display the exponent
    public Text exponentText;

    // The text component to display the equation
    public Text equationText;

    // The text component to display the equation
    public Text answerText;

    // The input field for the exponent
    public InputField exponentInput;

    // The input field for the answer
    public InputField answerInput;

    // The text component to display the timer
    public Text timerText;

    // The current score
    private int score;

    // The remaining time
    private float timeRemaining;

    private int exponent;

    void Start()
    {
        // Get the timer mode from PlayerPrefs
        int timer = PlayerPrefs.GetInt("timer");

        // Get the mode from PlayerPrefs
        mode = PlayerPrefs.GetString("mode");


        // Set the remaining time based on the selected timer mode
        if (timer == 30)
        {
            timeRemaining = 30f;
        }
        else if (timer == 60)
        {
            timeRemaining = 60f;
        }

        // Generate a new equation
        GenerateEquation();
    }

// This function generates an equation with a base of 2 and a randomly generated exponent
void GenerateEquation()
{
    // Generate a random exponent
    exponent = Random.Range(0, 13);

    // Set the equation text based on the selected mode
    if (mode == "exp")
    {
        // Enable the exponent input field
        exponentInput.gameObject.SetActive(true);

        // Disable the answer input field
        answerInput.gameObject.SetActive(false);

        // Disable the exponent text field
        exponentText.gameObject.SetActive(false);

        answerText.text = ((int)Mathf.Pow(2, exponent)).ToString();

        //equationText.text = "2 = " + (int)Mathf.Pow(2, exponent);
    }
    else if (mode == "ans")
    {
        // Enable the answer input field
        answerInput.gameObject.SetActive(true);

        // Disable the exponent input field
        exponentInput.gameObject.SetActive(false);

        // Disable the answer text field
        answerText.gameObject.SetActive(false);

        exponentText.text = exponent.ToString();
        //equationText.text = "2^" + exponent + " = ";
    }
}

// This function checks if the answer is correct
void CheckAnswer()
{
    // Check if the answer is correct
    if (mode == "exp")
    {
        // Get the user's exponent
        int answer = int.Parse(exponentInput.text);

        if (answer == exponent)
        {
            // Increment the score
            score++;

            // Generate a new equation
            GenerateEquation();
        }
    }
    else if (mode == "ans")
    {
        // Get the user's answer
        int answer = int.Parse(answerInput.text);
        if (answer == (int)Mathf.Pow(2, exponent))
        {
            // Increment the score
            score++;

            // Generate a new equation
            GenerateEquation();
        }
    }
}
/*
void CheckAnswer()
{

    else if (mode == "ans")
    {
        // Get the user's answer
        int answer = int.Parse(answerInput.text);

        // Check if the user's answer is correct
        if (Mathf.Log(answer, baseNumber) == exponent)
        {
            // The user's answer is correct
            score++;
        }
    }
}*/

    void Update()
    {
    // Decrease the remaining time by the elapsed time since the last frame
    timeRemaining -= Time.deltaTime;

    // Update the timer text
    timerText.text = ": " + Mathf.Floor(timeRemaining);

    // Check if the "Enter" key is pressed
    //if (Input.GetKeyDown(KeyCode.Return))
    //{
    // Check if the virtual keyboard is currently visible
    if (!TouchScreenKeyboard.visible)
    {
        // Check the answer
        CheckAnswer();
    }

    // Check if the timer has run out
    if (timeRemaining <= 0f)
    {
        // The timer has run out, end the game

        // Save the score and date to PlayerPrefs
        SaveScore();

        // Go back to the home screen
        // (Replace "HomeScene" with the name of your home scene)
        SceneManager.LoadScene("HomeScene");
    }
    }

    // This function saves the score and date to PlayerPrefs
void SaveScore()
{
    // Get the current date
    string date = System.DateTime.Now.ToString();

    // Save the score and date to PlayerPrefs
    PlayerPrefs.SetInt("Score1", score);
    PlayerPrefs.SetString("Date1", date);

    // Shift the previous scores down
    for (int i = 2; i <= 5; i++)
    {
        PlayerPrefs.SetInt("Score" + i, PlayerPrefs.GetInt("Score" + (i - 1)));
        PlayerPrefs.SetString("Date" + i, PlayerPrefs.GetString("Date" + (i - 1)));
    }
}
}