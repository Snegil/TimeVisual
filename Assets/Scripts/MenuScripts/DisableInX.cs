using UnityEngine;

public class DisableInX : MonoBehaviour
{
    [SerializeField, Header("Disable in X seconds")]
    float disableTimer = 5f;
    float timer;

    void OnEnable()
    {
        timer = disableTimer;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
