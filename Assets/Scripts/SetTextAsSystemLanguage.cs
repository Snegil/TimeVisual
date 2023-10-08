using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextAsSystemLanguage : MonoBehaviour
{
    [SerializeField]
    LanguageManager languageManager;

    [SerializeField]
    TextMeshProUGUI text;

    [Space, SerializeField]
    List<string> textLines;

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
        Debug.Log("CHANGELANGUAGE RUNS");
        text.text = textLines[languageIndex];
    }
}
