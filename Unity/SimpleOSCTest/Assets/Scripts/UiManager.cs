using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject ingameUI;
    public GameObject optionsScreen;
    public GameObject game;
    public GameObject pauseMenuFirstSelected, optionsMenuFirstSelected;

    private AudioListener audioListener;
    private Toggle soundToggle;
    private bool running = true;
    static bool soundEnabled = true;

    void Start()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        soundToggle = GameObject.Find("SoundToggle").GetComponent<Toggle>();
        soundToggle.isOn = soundEnabled;
        audioListener = GameObject.Find("MainCamera").GetComponent<AudioListener>();
        audioListener.enabled = soundEnabled;
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && running)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Cancel") && !running)
        {
            if (pauseScreen && pauseScreen.activeSelf)
            {
                ResumeGame();
            }
            else if (optionsScreen && optionsScreen.activeSelf)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        running = false;
        pauseScreen.SetActive(true);
        ingameUI.SetActive(false);
        game.SetActive(false);
        optionsScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseMenuFirstSelected);
    }

    public void ResumeGame()
    {
        running = true;
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
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

    public void openOptionsIngame()
    {
        optionsScreen.SetActive(true);
        running = false;
        pauseScreen.SetActive(false);
        ingameUI.SetActive(false);
        game.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsMenuFirstSelected);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void toggleSound()
    {
        if (soundEnabled)
        {
            soundEnabled = false;
            audioListener.enabled = false;
            soundToggle.isOn = false;
        }
        else
        {
            soundEnabled = true;
            audioListener.enabled = true;
            soundToggle.isOn = true;
        }
    }
}
