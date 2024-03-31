using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject confirmQuitPanel;
    [SerializeField] GameObject musicPanel;
    [SerializeField] GameObject howToPlayPanel;
    [SerializeField] GameObject settingButton;

    void Start()
    {
        settingPanel.SetActive(false);
        confirmQuitPanel.SetActive(false);
        musicPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }

     public void ShowSettingPanel()
    {
        Time.timeScale = 0;
        settingPanel.SetActive(true);
        settingButton.SetActive(false);
    }

    public void MusicSetting()
    {
        musicPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void HowToPlay()
    {
        howToPlayPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        confirmQuitPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void ReallyQuitGame()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }

    public void NoIdontQuitGame()
    {
        settingPanel.SetActive(true);
        confirmQuitPanel.SetActive(false);
        musicPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        settingPanel.SetActive(false);
        settingButton.SetActive(true);
    }
}
