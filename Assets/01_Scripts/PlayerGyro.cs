using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGyro : MonoBehaviour
{
    public float x;
    public float y;
    public bool gyroEnabled = true;
    float sensivity = 50f;
    Gyroscope gyro;

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            //Abilita el giroscopiods
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            x = Input.gyro.rotationRate.x;
            y = Input.gyro.rotationRate.y;
            float xFilterd = FilterGyroValue(x);
            transform.RotateAround(transform.position, transform.right, -xFilterd * sensivity * Time.deltaTime);

            float yFilterd = FilterGyroValue(y);
            transform.RotateAround(transform.position, transform.up, -yFilterd * sensivity * Time.deltaTime);
        }
    }

    float FilterGyroValue(float axis)
    {
        if (axis < 0.1f || axis > 0.1f)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
}
