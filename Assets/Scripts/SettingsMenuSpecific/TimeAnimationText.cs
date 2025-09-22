using System;
using TMPro;
using UnityEngine;

public class TimeAnimationText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    TimeDisplayManager timeDisplayManager;

    void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        text.text = Enum.GetName(typeof(EnumAnimationTypes), timeDisplayManager.Index);
    }
}
