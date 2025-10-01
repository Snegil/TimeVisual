using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnValue : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites = new Sprite[4];
    [SerializeField]
    Image image;

    public void ChangeSprite(float value)
    {
        if (value >= 0)
        {
            image.sprite = sprites[3];
        }
        else if (value >= -15f)
        {
            image.sprite = sprites[2];
        }
        else if (value >= -35f)
        {
            image.sprite = sprites[1];
        }
        else if (value <= -35f)
        {
            image.sprite = sprites[0];
        }
    }
}
