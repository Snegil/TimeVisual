using UnityEngine;

public class ToggleCheckmark : MonoBehaviour
{
    public void ToggleActive(GameObject checkmark)
    {
        checkmark.SetActive(!checkmark.activeSelf);
    }
}
