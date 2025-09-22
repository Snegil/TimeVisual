using UnityEngine;

[CreateAssetMenu(fileName = "DarkTheme", menuName = "Scriptable Objects/DarkTheme")]
public class DarkTheme : ScriptableObject
{
    [SerializeField]
    Color menuColour;
    public Color MenuColour => menuColour;
    [SerializeField]
    Font textFont;
    public Font TextFont => textFont;
    [SerializeField]
    Color iconColour;
    public Color IconColour => iconColour;
}
