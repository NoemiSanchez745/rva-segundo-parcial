using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float speed = 15;

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
