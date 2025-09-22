using UnityEngine;
using UnityEngine.UI;

public class LoadAlwaysOnTopPref : MonoBehaviour
{
    [SerializeField]
    GameObject checkmark;

    void Start()
    {
        if (PlayerPrefs.HasKey("AlwaysOnTop"))
        {
            bool isAlwaysOnTop = PlayerPrefs.GetInt("AlwaysOnTop") == 1 ? true : false;
            checkmark.SetActive(isAlwaysOnTop);
        }
    }
}
