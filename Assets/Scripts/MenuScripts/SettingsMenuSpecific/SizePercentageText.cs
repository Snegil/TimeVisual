using TMPro;
using UnityEngine;

public class SizePercentageText : MonoBehaviour
{
    [SerializeField]
    BorderlessWindow borderlessWindow;

    [SerializeField]
    TextMeshProUGUI text;

    bool doneOnce = false;

    void Start()
    {
        if (doneOnce) return;
        doneOnce = true;
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = (100 + (borderlessWindow.SizeIncrement - 5) * 10).ToString() + "%";
    }
}
