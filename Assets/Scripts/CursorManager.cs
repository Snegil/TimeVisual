using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    float cursorScaleMultiplier = 1.1f;

    public void IncreaseObjectScale(GameObject pointed)
    {
        pointed.transform.localScale = Vector3.one * cursorScaleMultiplier;
    }
    public void ResetObjectScale(GameObject pointed)
    {
        pointed.transform.localScale = Vector3.one;
    }
}
