using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button replayButton;

    [SerializeField]
    private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        replayButton.onClick.AddListener(Replay);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Deactivate();
    }

    public void Replay()
    {
        Deactivate();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        Deactivate();
    }
}
