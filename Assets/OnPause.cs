using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPause : MonoBehaviour
{
    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            // The app was paused, so the user probably swiped it away from the recent apps list.
            // Go back to the home scene here.
            SceneManager.LoadScene("HomeScene");
        }
    }
}
