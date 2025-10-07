using UnityEngine;

public interface ITheme
{
    public Color TopBarColour { get; }
    public Color BackgroundColour { get; }
    public Color DarkerBackgroundColour{ get; }
    public Color TextColour { get; }
    public Color IconColour { get; }
    public Color[] TimeButtonColours { get; }
    public Color FillColour { get; }
    public Color DarkerFillColour { get; }
}