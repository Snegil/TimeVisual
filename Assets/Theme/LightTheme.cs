using UnityEngine;

[CreateAssetMenu(fileName = "LightTheme", menuName = "Scriptable Objects/LightTheme")]
public class LightTheme : ScriptableObject
{
    [SerializeField]
    Color menuColour;
    public Color MenuColour => menuColour;

    [SerializeField]
    Font textFont;
    public Font TextFont => textFont;

    [SerializeField]
    Color textColour;
    public Color TextColour => textColour;

    [SerializeField]
    Color iconColour;
    public Color IconColour => iconColour;
}
