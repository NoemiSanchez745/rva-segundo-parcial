using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    public Transform firePointEnemy;
    float bulletSpeed = 2000;
    float timer = 0;
    public GameObject sootSound;
    public GameObject efectExplosion;
    Transform target;
    float rotationSpeed=6f;
    float timeToSpawn = 1;
    public GameObject bulletPrefab;
    Rigidbody rb;

    /*Canavas lifeBar Enemigo*/
    public Image lifeBarEnemy;
    public float maxLifeEnemy = 500;
    public float lifeEnemy;/*vida actual*/
    private void Awake()
    {
        
    }
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        lifeEnemy = maxLifeEnemy;
        lifeBarEnemy.fillAmount = lifeEnemy / maxLifeEnemy;/*500/500 = 1*/
    }
    
    void Update()
    {
        float distancia;
        distancia = Vector3.Distance(target.transform.position, transform.position);/*cALCULANDO distancia entr enemigo*/
        if (distancia<25)
        {
            //this.gameObject.transform.rotation=Quaternion.Slerp(this.gameObject.transform.rotation,Quaternion.LookRotation(target.position-this.transform.position),rotationSpeed*Time.deltaTime);
            
            if (timer<timeToSpawn)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Instantiate(sootSound);
                GameObject bullet = Instantiate(bulletPrefab,firePointEnemy.position,firePointEnemy.rotation) as GameObject;
                rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * bulletSpeed);
                timer = 0;
            }
        }
        
    }
    public void TakeDamge(float damage)
    {
        lifeEnemy -= damage;
        lifeBarEnemy.fillAmount = lifeEnemy / maxLifeEnemy;/*500/500 = 1*/
    }
    private void OnDestroy()
    {
        Instantiate(efectExplosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro al triger de Enemy");
        if (other.tag=="Bullet")
        {
            Debug.Log("Se detectó daño del Player al enemigo");
            //TakeDamge(500f);
            //Destroy(other.gameObject);
        }
    }
}
