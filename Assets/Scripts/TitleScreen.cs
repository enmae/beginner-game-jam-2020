using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Resume() {
        // to make canvas visible
    }

    public void Options() {
        // secondary canvas for different options
    }
}
