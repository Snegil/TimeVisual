using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    [SerializeField]
    float timer;
    float setTimer;

    Light myLight;

    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Light();
            timer = setTimer;
        }
    }
    void Light()
    {
        float value = Mathf.LerpUnclamped(1, 5, 0.01f);
        myLight.intensity = value;
    }
}
