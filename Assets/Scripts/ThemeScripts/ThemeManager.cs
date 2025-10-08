using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    [SerializeField]
    Theme[] themes;

    bool darkMode = false;
    public bool DarkMode => darkMode;

    [Space]
    [Space, Header("Objects to change the colour of")]

    [SerializeField]
    List<Image> topBarObjects;

    [SerializeField]
    List<Image> backgrounds;
    [SerializeField]
    List<Image> icons;
    [SerializeField]
    List<TextMeshProUGUI> textColour;
    [SerializeField]
    List<Image> sliderFill;
    [SerializeField]
    List<Image> sliderFillBackground;
    [SerializeField]
    List<Image> toggleButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (PlayerPrefs.HasKey("Theme"))
        {
            darkMode = PlayerPrefs.GetInt("Theme") == 1;
        }

        ApplyTheme();
    }

    public void ApplyTheme()
    {
        // If darkmode is true, set index to 1.
        int index = darkMode ? 1 : 0;

        if (themes[index] == null)
        {
            Debug.LogWarning("THEMES AT INDEX: " + index + " IS NULL");
            return;
        }

        ImageListColourChange(topBarObjects, themes[index].TopBarColour);
        ImageListColourChange(backgrounds, themes[index].BackgroundColour);
        ImageListColourChange(icons, themes[index].IconColour);
        ImageListColourChange(sliderFill, themes[index].FillColour);
        ImageListColourChange(sliderFillBackground, themes[index].BackgroundFillColour);
        ImageListColourChange(toggleButtons, themes[index].ToggleButtons);

        for (int i = 0; i < textColour.Count; i++)
        {
            if (textColour[i] == null) return;
            textColour[i].color = themes[index].TextColour;
        }
    }

    void ImageListColourChange(List<Image> images, Color color)
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = color;
        }
    }

    public void ToggleThemes()
    {
        darkMode = !darkMode;

        ApplyTheme();
    }
    public void SaveThemePrefs()
    {
        PlayerPrefs.SetInt("Theme", darkMode ? 1 : 0);
    }
}
