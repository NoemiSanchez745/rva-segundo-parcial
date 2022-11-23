using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    
    public GameObject player;
    private Gyroscope gyro;
    //private bool gyroEnable = false;
    //private float x, y, sensivity = 50F;
    public Transform firePoint;
    public GameObject bulletPrefab;

    //Timer
    public float timer = 0;
    public float timeBtwShoot = 0.9f;
    public bool canShoot = true;

    /*Canavas lifeBar*/
    public Image lifeBar;
    public float maxLife=500;
    float life;/*vida actual*/

    /*Recargar balas*/
    public int maxBullets = 10;
    public int bullets;/*Cada vez que disparemos aqui en bullets debemos restarle una bala*/

    /*Reload Bar*/
    public Image reloadBar;

    Inputs inputs;

    public GameObject startGame;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Player.Shoot.performed += ctx => Shoot();
        inputs.Player.Reload.performed += ctx => Reload();
    }
    void Start()
    {
        life = maxLife;
        lifeBar.fillAmount = life / maxLife;/*500/500 = 1*/
        bullets = maxBullets;
        //if (SystemInfo.supportsGyroscope)
        //{
        //    gyro = Input.gyro;
        //    gyro.enabled = true;
        //}
    }

   
    void Update()
    {
        //if (gyroEnable)
        //{
        //    x = Input.gyro.rotationRate.x;
        //    y = Input.gyro.rotationRate.y;
        //    float xFiltered = FilerGyroValue(x);
        //    transform.RotateAround(transform.position, transform.right, -xFiltered * sensivity * Time.deltaTime);
        //    float yFiltered = FilerGyroValue(y);
        //    transform.RotateAround(transform.position, transform.up, -yFiltered * sensivity * Time.deltaTime);
        //    //Walk(x);
        //    //Rotar(y);
        //}
        //Walk(transform.localEulerAngles.x);
        //Rotar(transform.localEulerAngles.y);
        checkIfCanShoot();
        //Shoot();
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

    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }

    void Shoot()
    {
        //Debug.Log("ENTRó");
        if (canShoot && bullets>0)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                canShoot = false;
                /*Con cada disparo resto una bala*/
                bullets--;
        }
    }
    
    void Reload()/*Asociar este metodo al boton y*/
    {
        Debug.Log("Entró");
        /*Cuando presionda Y que recargue las balas*/
        bullets = maxBullets;
    }

    void checkIfCanShoot()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer>=timeBtwShoot)
            {
                timer = 0;
                canShoot = true;
            }
            /*Reload*/
            reloadBar.fillAmount = timer / timeBtwShoot;
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

    /*Cada que el Player reciba daño*/
    public void TakeDamge(float damage)
    {

        life -= damage;
        lifeBar.fillAmount = life / maxLife;/*500/500 = 1*/
        Time.timeScale = 0;
        //startGame.SetActive(true);
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro al triger");
        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            Debug.Log("Se detectó daño");
            //Player p = other.gameObject.GetComponent<Player>();
            /*Una vez colisionado con el Player debemos hacerle daño*/
            //p.TakeDamge(50f);
            TakeDamge(5f);
            /*Una vez colisionado y causado daño la bala se destruye*/
            //Destroy(other.gameObject);
            /*Recordad que el Object Player debe tener el tag Player en la interfaz*/
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Entro al triger");
    //    if (other.tag=="BulletEnemy")
    //    {
    //        Debug.Log("Se detectó daño");
    //        //Player p = other.gameObject.GetComponent<Player>();
    //        /*Una vez colisionado con el Player debemos hacerle daño*/
    //        //p.TakeDamge(50f);
    //        //TakeDamge(50f);
    //        /*Una vez colisionado y causado daño la bala se destruye*/
    //        //Destroy(other.gameObject);
    //        /*Recordad que el Object Player debe tener el tag Player en la interfaz*/
    //    }
    //}
}
