using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7;
    //public GameObject explosion;

    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro al triger de Enemy");
        if (other.tag == "Enemy")
        {
            Debug.Log("Se detectó daño del Player al enemigo");
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamge(500f);
            Destroy(other.gameObject);
        }
    }



}
