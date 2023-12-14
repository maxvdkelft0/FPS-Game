using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        // Attach the button click event to the PlayButtonClick method
        playButton.onClick.AddListener(PlayButtonClick);
    }

    void PlayButtonClick()
    {
        // Load the scene named "FPS-1"
        SceneManager.LoadScene("FPS-1");
    }

}
