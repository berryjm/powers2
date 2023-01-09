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
			//if (Input.GetKeyDown(KeyCode.Return))
			//{
			// Check the answer
			CheckAnswer();
			Debug.Log(score);
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

	void SaveScore()
	{
		string date = System.DateTime.Now.ToString();
		int timer = PlayerPrefs.GetInt("timer");
		// Save the score and date to PlayerPrefs
		if (timer == 60)
		{
			// Shift the previous scores down if they exist
			if (PlayerPrefs.HasKey("1mScore4"))
			{
				PlayerPrefs.SetInt("1mScore5", PlayerPrefs.GetInt("1mScore4"));
				PlayerPrefs.SetString("1mDate5", PlayerPrefs.GetString("1mDate4"));
			}

			if (PlayerPrefs.HasKey("1mScore3"))
			{
				PlayerPrefs.SetInt("1mScore4", PlayerPrefs.GetInt("1mScore3"));
				PlayerPrefs.SetString("1mDate4", PlayerPrefs.GetString("1mDate3"));
			}

			if (PlayerPrefs.HasKey("1mScore2"))
			{
				PlayerPrefs.SetInt("1mScore3", PlayerPrefs.GetInt("1mScore2"));
				PlayerPrefs.SetString("1mDate3", PlayerPrefs.GetString("1mDate2"));
			}

			if (PlayerPrefs.HasKey("1mScore1"))
			{
				PlayerPrefs.SetInt("1mScore2", PlayerPrefs.GetInt("1mScore1"));
				PlayerPrefs.SetString("1mDate2", PlayerPrefs.GetString("1mDate1"));
			}

			// Save the score and date as the top score
			PlayerPrefs.SetInt("1mScore1", score);
			PlayerPrefs.SetString("1mDate1", date);
		}
		else if (timer == 30)
		{
			// Shift the previous scores down if they exist
			if (PlayerPrefs.HasKey("30sScore4"))
			{
				PlayerPrefs.SetInt("30sScore5", PlayerPrefs.GetInt("30sScore4"));
				PlayerPrefs.SetString("30sDate5", PlayerPrefs.GetString("30sDate4"));
			}

			if (PlayerPrefs.HasKey("30sScore3"))
			{
				PlayerPrefs.SetInt("30sScore4", PlayerPrefs.GetInt("30sScore3"));
				PlayerPrefs.SetString("30sDate4", PlayerPrefs.GetString("30sDate3"));
			}

			if (PlayerPrefs.HasKey("30sScore2"))
			{
				PlayerPrefs.SetInt("30sScore3", PlayerPrefs.GetInt("30sScore2"));
				PlayerPrefs.SetString("30sDate3", PlayerPrefs.GetString("30sDate2"));
			}

			if (PlayerPrefs.HasKey("30sScore1"))
			{
				PlayerPrefs.SetInt("30sScore2", PlayerPrefs.GetInt("30sScore1"));
				PlayerPrefs.SetString("30sDate2", PlayerPrefs.GetString("30sDate1"));
			}

			// Save the score and date as the top score
			PlayerPrefs.SetInt("30sScore1", score);
			PlayerPrefs.SetString("30sDate1", date);
		}
	}
}