using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    [SerializeField]
    Theme[] themes;

    bool lightTheme = true;

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
    void Start()
    {
        ApplyTheme();
    }

    public void ApplyTheme()
    {
        int index = lightTheme ? 0 : 1;

        if (themes[index] == null)
        {
            Debug.LogWarning("THEMES AT INDEX: " + index + " IS NULL");
            return;
        }


        for (int i = 0; i < topBarObjects.Count; i++)
        {
            if (topBarObjects[i] == null) return;

            topBarObjects[i].color = themes[index].TopBarColour;
        }
        for (int i = 0; i < backgrounds.Count; i++)
        {
            if (backgrounds[i] == null) return;

            backgrounds[i].color = themes[index].BackgroundColour;
        }
        for (int i = 0; i < icons.Count; i++)
        {
            if (icons[i] == null) return;

            icons[i].color = themes[index].IconColour;
        }
        for (int i = 0; i < textColour.Count; i++)
        {
            if (textColour[i] == null) return;
            textColour[i].color = themes[index].TextColour;
        }
        for (int i = 0; i < sliderFill.Count; i++)
        {
            if (sliderFill[i] == null) return;

            sliderFill[i].color = themes[index].FillColour;

            if (sliderFillBackground[i] == null) return;

            sliderFillBackground[i].color = themes[index].BackgroundFillColour;
        }        
        for (int i = 0; i < toggleButtons.Count; i++)
        {
            toggleButtons[i].color = themes[index].ToggleButtons;
        }
    }

    public void ChangeIndex()
    {
        lightTheme = !lightTheme;
    }
}
