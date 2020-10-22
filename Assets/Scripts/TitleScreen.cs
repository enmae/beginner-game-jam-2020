using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;
    public GameObject gameOverMenuUI;
    public Text scoreText;

    public static bool gameIsPaused = false;
    public static bool optionsAreShowing = false;
    public static bool pauseIsHidden = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused && !optionsAreShowing) {
                Resume();
            } else if (gameIsPaused && optionsAreShowing) {
                LoadOptions();
            } else if (gameIsPaused && pauseIsHidden && !optionsAreShowing) {
                QuitOptions();
            } else {
                Pause();
            }
        }
    }

    public void Play() {
        SceneManager.LoadScene("Game");
    }

    public void Replay() {
        Time.timeScale = 1;
        gameOverMenuUI.SetActive(false);
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        optionMenuUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        optionsAreShowing = false;
    }

    public void LoadOptions() {
        // secondary canvas for different options
        optionMenuUI.SetActive(true);
        optionsAreShowing = true;
        pauseIsHidden = true;
        pauseMenuUI.SetActive(false);
    }

    public void QuitOptions() {
        optionsAreShowing = false;
        pauseIsHidden = false;
        optionMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverMenuUI.SetActive(true);
        float score = GameObject.Find("Player").GetComponent<Transform>().position.x / 10;
        scoreText.text = "Score: " + ((int)score).ToString();
    }
}
