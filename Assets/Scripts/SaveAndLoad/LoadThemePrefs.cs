using UnityEngine;

public class LoadThemePrefs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("ThemeManager").GetComponent<ThemeManager>().DarkMode)
        {
            GetComponent<ChangeIconOnClick>().ChangeIcon();
        }

        
    }
}
