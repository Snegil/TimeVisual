using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    private void Awake()
    {
        SetTextWithButton();
    }
    public void SetTextWithButton()
    {
        this.text.text = Application.systemLanguage.ToString();
    }
}
