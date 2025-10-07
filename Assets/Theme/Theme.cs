using UnityEngine;

[CreateAssetMenu(fileName = "ThemePreset", menuName = "Scriptable Objects/Theme")]
public class Theme : ScriptableObject
{
    [SerializeField]
    Color topBarColour;
    public Color TopBarColour => topBarColour;

    [SerializeField]
    Color backgroundColour;
    public Color BackgroundColour => backgroundColour;

    [SerializeField]
    Color textColour;
    public Color TextColour => textColour;

    [SerializeField]
    Color iconColour;
    public Color IconColour => iconColour;

    [Space, SerializeField, Header("For sliders")]
    Color fillColour;
    public Color FillColour => fillColour;
    [SerializeField]
    Color backgroundFillColour;
    public Color BackgroundFillColour => backgroundFillColour;

    [SerializeField]
    Color toggleButtons;
    public Color ToggleButtons => toggleButtons;
}