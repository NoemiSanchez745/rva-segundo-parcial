using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    private Gyroscope gyro;
    private bool gyroEnable = false;
    private float x, y, sensivity = 50F;
    public Transform firePoint;
    public GameObject bulletPrefab;
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

   
    void Update()
    {
        if (gyroEnable)
        {
            x = Input.gyro.rotationRate.x;
            y = Input.gyro.rotationRate.y;
            float xFiltered = FilerGyroValue(x);
            transform.RotateAround(transform.position, transform.right, -xFiltered * sensivity * Time.deltaTime);
            float yFiltered = FilerGyroValue(y);
            transform.RotateAround(transform.position, transform.up, -yFiltered * sensivity * Time.deltaTime);
            Walk(x);
            Rotar(y);
        }
        Walk(transform.localEulerAngles.x);
        Rotar(transform.localEulerAngles.y);
        Shoot();
    }
    private float FilerGyroValue(float axis)
    {
        if (axis < -0.1f || axis > 0.1f)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void Walk(float x2)
    {
        if (x2 >= 20f && x2 <= 50f)
        {
            player.transform.Translate(0, 0, 1f * Time.deltaTime);
        }
    }
    private void Rotar(float x2)
    {
        if (x2 >= 345f && x2 <= 355f)
        {
            float rotationTime = 5f;
            player.transform.Rotate(Vector3.down * (rotationTime * Time.deltaTime));
        }
        else if (x2 >= 5f && x2 <= 15f)
        {
            float rotationTime = 5f;
            player.transform.Rotate(Vector3.up * (rotationTime * Time.deltaTime));
        }
    }
}
