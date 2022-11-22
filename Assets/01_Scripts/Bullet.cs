using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 5;
    public float timeToDestroy = 10;
    public GameObject explosion;

    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
