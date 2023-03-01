using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private Button pauseButton;

    [SerializeField]
    private PauseMenu pauseMenu;

    private void Awake()
    {
        pauseButton.onClick.AddListener(Pause);
    }

    public void Pause()
    {
        pauseMenu.Activate();
    }
}
