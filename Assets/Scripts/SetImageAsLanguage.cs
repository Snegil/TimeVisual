using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetImageAsLanguage : MonoBehaviour
{
    [SerializeField]
    LanguageManager languageManager;

    [SerializeField]
    Image image;

    [Space, SerializeField]
    List<Sprite> flagsOfLanguages;

    void OnEnable()
    {
        languageManager.ChangedLanguage += ChangeLanguage;
        ChangeLanguage(languageManager.GetLanguageIndex);

    }
    void OnDisable()
    {
        languageManager.ChangedLanguage -= ChangeLanguage;
    }
    public void ChangeLanguage(int languageIndex)
    {
        Debug.Log("CHANGEFLAGIMAGE RUNS");
        image.sprite = flagsOfLanguages[languageIndex];
    }
}
