using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    //public float speed = 7;

    //public float timeToDestroy = 10;
    //public GameObject explosion;

    //public Transform firePoint;
    //public GameObject bulletE//nemyPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    /*Creamos una referencia al script del Player si es que hemos colisionado con él*/
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Entro al triger");
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Detectó daño");
    //        //Player p = other.gameObject.GetComponent<Player>();
    //        /*Una vez colisionado con el Player debemos hacerle daño*/
    //        //p.TakeDamge(50f);
    //        /*Una vez colisionado y causado daño la bala se destruye*/
    //        //Destroy(gameObject);
    //        /*Recordad que el Object Player debe tener el tag Player en la interfaz*/
    //    }
    //}
}
