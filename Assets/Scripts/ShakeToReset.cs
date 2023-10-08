using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShakeToReset : MonoBehaviour
{
    float xcontext;
    float ycontext;

    [Space, SerializeField, Header("Tolerance for accelerometer")]
    float tolerance;

    [Space, SerializeField]
    float timer;
    float setTimer;

    [Space, SerializeField]
    TimeHandler timeHandler;
    
    void Start()
    {
        if (Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
        }
        setTimer = timer;    
    }
    void Update()
    {
    }
    public void ShakingDevice(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector3>());
        
        xcontext = Mathf.Abs(context.ReadValue<Vector3>().x);
        ycontext = Mathf.Abs(context.ReadValue<Vector3>().y);

        if (xcontext > tolerance || ycontext > tolerance)
        {
            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timeHandler.ResetTime();
                timer = setTimer;
            }

        }
    }
}
