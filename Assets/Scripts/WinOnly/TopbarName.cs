using TMPro;
using UnityEngine;

public class TopbarName : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = Application.productName;
    }
}
