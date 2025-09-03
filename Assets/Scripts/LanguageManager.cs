using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public delegate void LanguageChanged(int languageIndex);
    public event LanguageChanged ChangedLanguage;

    // 0 == Eng, 1 == Swe
    int languageIndex = 0;

    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Swedish) languageIndex = 1;
        if (Application.systemLanguage == SystemLanguage.Dutch) languageIndex = 2;

        if (PlayerPrefs.HasKey("LanguageIndex"))
        {
            languageIndex = PlayerPrefs.GetInt("LanguageIndex");
        }

        ChangedLanguage?.Invoke(languageIndex);
    }
    public void ChangeLanguage(int languageindex)
    {
        languageIndex = languageindex;
        PlayerPrefs.SetInt("LanguageIndex", languageindex);
        ChangedLanguage?.Invoke(languageindex);
    }
    public int GetLanguageIndex
    {
        get { return languageIndex; }
    }
}