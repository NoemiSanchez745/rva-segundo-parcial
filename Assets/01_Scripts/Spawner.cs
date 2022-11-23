using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*Cada ciertos segundos me va a crear un piso nuevo*/
    public float timer = 0;
    public float timeBtwSpawner = 2.5f;

    /*Creamos lo que son los pisos*/
    public List<GameObject> roomPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=timeBtwSpawner)
        {
            timer = 0;
            /*Instancia del objeto Piso*/ /*Llamamos a cualquiera de los pisos randomicamente suerte desde 0 hasta la cantidad de prefabs*/
            Instantiate(roomPrefab[Random.Range(0,roomPrefab.Count)], transform.position, transform.rotation);
        }
    }
}
