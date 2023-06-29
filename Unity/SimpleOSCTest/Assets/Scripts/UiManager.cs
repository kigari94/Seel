using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject ingameUI;
    public GameObject game;

    private bool running = true;

    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && running)
        {
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.Escape) && !running) {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        running = false;
        pauseScreen.SetActive(true);
        ingameUI.SetActive(false);
        game.SetActive(false);
    }

    public void ResumeGame()
    {
        running = true;
        pauseScreen.SetActive(false);
        ingameUI.SetActive(true);
        game.SetActive(true);
    }

    public void initGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void openOptionsPage()
    {
        SceneManager.LoadScene(2);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
