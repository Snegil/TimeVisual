using UnityEngine;

public class SaveActiveTimeButton : MonoBehaviour
{
    [SerializeField]
    int index;
    
    public void SaveActiveButton(bool val)
    {
        if (!val) return;
        PlayerPrefs.SetInt("ActiveTimeButton", index);
        Debug.Log("Saved Active Time Button: " + index);
    }
}
