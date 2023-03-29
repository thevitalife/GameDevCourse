using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;


    [SerializeField]
    private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        exitButton.onClick.AddListener(Exit);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
