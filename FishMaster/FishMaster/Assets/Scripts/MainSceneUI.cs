using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneUI : MonoBehaviour 
{
    public Toggle muteToogle;
    public GameObject settingPanel;

    void Start()
    {
        muteToogle.isOn = !AudioManager.Instance.IsMute;
    }
    public void SwitchMute(bool isOn)
    {
        AudioManager.Instance.SwitchMuteState(isOn);
    }

    public void OnBackButtonDown()
    {
        PlayerPrefs.SetInt("gold", GameController._Instance.gold);
        PlayerPrefs.SetInt("lv", GameController._Instance.lv);
        PlayerPrefs.SetFloat("scd", GameController._Instance.smallTimer);
        PlayerPrefs.SetFloat("bcd", GameController._Instance.bigTimer);
        PlayerPrefs.SetInt("exp", GameController._Instance.exp);
        int temp=(AudioManager.Instance.IsMute==false)?0:1;
        PlayerPrefs.SetInt("mute", temp);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void OnSettingButtonDown()
    {
        settingPanel.SetActive(true);
    }

    public void OnCloseButtonDown()
    {
        settingPanel.SetActive(false);
    }

}
