using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuExample : MonoBehaviour {

    GameObject panel;

	void Awake () {
        // Get panel object
        panel = transform.Find("PauseMenuPanel").gameObject;
        if (panel == null) {
            Debug.LogError("PauseMenuPanel object not found.");
            return;
        }

        panel.SetActive(false); // Hide menu on start
	}

    // Call from inspector button
    public void ResumeGame () {
        SumPause.Status = false; // Set pause status to false
    }
    public void quitGame()
    {
        Application.Quit(); // Set pause status to false
    }

    // Add/Remove the event listeners
    void OnEnable() {
        SumPause.pauseEvent += OnPause;
    }

    void OnDisable() {
        SumPause.pauseEvent -= OnPause;
    }
    void restart()
    {
        Constants.dead = false;
        Application.LoadLevel(Application.loadedLevel);
    }
    /// <summary>What to do when the pause button is pressed.</summary>
    /// <param name="paused">New pause state</param>
    void OnPause(bool paused) {
        if (paused) {
            // This is what we want do when the game is paused
            panel.SetActive(true); // Show menu
            if (Constants.dead)
            {
                
                GameObject.FindGameObjectWithTag("Resume").GetComponent<Text>().text = "Restart";
                GameObject.FindGameObjectWithTag("Resume").transform.parent.gameObject.GetComponent<Button>().onClick.AddListener(restart);
                int curScore = SumScore.Score;
                GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "SCORE: " + curScore;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Resume").GetComponent<Text>().text = "Resume";
                GameObject.FindGameObjectWithTag("Resume").transform.parent.gameObject.GetComponent<Button>().onClick.AddListener(ResumeGame);
                int curScore = SumScore.Score;
                GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "SCORE: " + curScore;
            }
        }
        else {
            // This is what we want to do when the game is resumed
            panel.SetActive(false); // Hide menu
        }
    }

}
