using UnityEngine;
using UnityEngine.UI;

public class SmoothTimeAnimation : MonoBehaviour, ITimeAnimation
{
    public void UpdateAnimation(Image image, float time, float maxTime)
    {
        image.fillAmount = time / maxTime;
    }

    public void UpdateFillAmount(Image[] images, float value, float maxTime)
    {
        throw new System.NotImplementedException();
    }
}