using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;

    public static bool gameIsPaused = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Options() {
        // secondary canvas for different options
    }
}
