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

    private void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        replayButton.onClick.AddListener(Replay);
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
}
