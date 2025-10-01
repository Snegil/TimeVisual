using TMPro;
using UnityEngine;

public class VersionText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Version: " + Application.version;
    }    
}
