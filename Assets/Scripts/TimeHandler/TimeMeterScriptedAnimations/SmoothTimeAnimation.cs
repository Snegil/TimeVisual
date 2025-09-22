using UnityEngine;
using UnityEngine.UI;

public class SmoothTimeAnimation : MonoBehaviour, ITimeAnimation
{
    public void UpdateAnimation(Image image, float time, float maxTime)
    {
        image.fillAmount = time / maxTime;
    }
}