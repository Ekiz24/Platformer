using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject confirmQuitPanel;

    void Start()
    {
        settingPanel.SetActive(false);
        confirmQuitPanel.SetActive(false);
    }

     public void ShowSettingPanel()
    {
        Time.timeScale = 0;
        settingPanel.SetActive(true);
    }

    public void MusicSetting()
    {

    }

    public void HowToPlay()
    {

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
        confirmQuitPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        settingPanel.SetActive(false);
    }
}
