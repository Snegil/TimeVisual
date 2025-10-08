using UnityEngine;
using UnityEngine.UI;

public class ChangeIconOnClick : MonoBehaviour
{
    [SerializeField]
    Sprite sprite0;
    [SerializeField]
    Sprite sprite1;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeIcon()
    {
        if (image.sprite == sprite0)
        {
            image.sprite = sprite1;
            return;
        }

        image.sprite = sprite0;
    }
}
