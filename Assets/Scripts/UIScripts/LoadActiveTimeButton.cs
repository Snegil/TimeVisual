using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadActiveTimeButton : MonoBehaviour
{
    [SerializeField]
    List<Toggle> toggles = new();
    [SerializeField]
    List<GameObject> timeButtons = new();

    void Start()
    {
        if (!PlayerPrefs.HasKey("ActiveTimeButton")) return;
        Debug.Log(PlayerPrefs.GetInt("ActiveTimeButton"));
        for (int i = 0; i < toggles.Count; i++)
        {
            if (i == PlayerPrefs.GetInt("ActiveTimeButton"))
            {
                toggles[i].isOn = true;
                timeButtons[i].SetActive(true);
            }
            else
            {
                toggles[i].isOn = false;
                timeButtons[i].SetActive(false);
            }
        }
    }
}
