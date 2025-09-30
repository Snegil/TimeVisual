using UnityEngine.UI;

// Interface for the timemeter animations
public interface ITimeAnimation
{
    void UpdateAnimation(Image image, float time, float maxTime);
    //void UpdateFillAmount(Image image, float time, float maxTime);
}
