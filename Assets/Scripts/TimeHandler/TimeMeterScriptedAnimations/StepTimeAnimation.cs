using UnityEngine;
using UnityEngine.UI;

public class StepTimeAnimation : MonoBehaviour, ITimeAnimation
{
    public void UpdateAnimation(Image image, float time, float maxTime)
    {
        float[] thresholds = { 0.75f, 0.5f, 0.25f, 0f };
        float[] fillAmounts = { 1f, 0.75f, 0.5f, 0.25f, 0f };

        //UpdateFillAmount(image, time, maxTime);

        for (int i = 0; i < thresholds.Length; i++)
        {
            if (time > maxTime * thresholds[i])
            {
                image.fillAmount = fillAmounts[i];

                return;
            }
        }
        image.fillAmount = fillAmounts[^1];
    }

    /* public void UpdateFillAmount(Image images, float time, float maxTime)
    {
        float[] thresholds = { 0.75f, 0.5f, 0.25f, 0f };
        float[] fillAmounts = { 1f, 0.75f, 0.5f, 0.25f, 0f };

        for (int i = images.Length; i > 0 ; i--)
        {
            if (time > maxTime * thresholds[i - 1])
            {
                images[i - 1].fillAmount = fillAmounts[i];
                return;
            }
        }
    } */
}
