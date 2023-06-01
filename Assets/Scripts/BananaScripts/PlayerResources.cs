using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public GameObject[] playerModels;
    public GameObject[] playerCollisions;
    public int health = 5;

    public Transform gunR;
    public Transform gunL;
    public GameObject bullet;
    public float fireRate = 0.5f;
    public bool canFire = true;

    public int shots;

    public float shurikenLeftAngle = 91f;
    public float shurikenRightAngle = 89f;

    public PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCollisions[0].SetActive(false);
        playerCollisions[1].SetActive(false);

        for (int i = 0; i < playerModels.Length; i++)
        {
            playerModels[i].SetActive(false);
        }
        playerModels[5].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            StartCoroutine("Shoot");
        }
    }

    public IEnumerator Shoot()
    {
        
        if(shots < 1)
        {
            Instantiate(bullet, gunL.position, Quaternion.Euler(0f, shurikenLeftAngle, 0f));
            canFire = false;
            shots++;
        }

        else if(shots > 0)
        {
            Instantiate(bullet, gunR.position, Quaternion.Euler(0f, shurikenRightAngle, 0f));
            canFire = false;
            shots = 0;
        }
        
        yield return new WaitForSeconds(fireRate);
        canFire = true;
        

    }

    public void Damage(int damage)
    {
        if(health>0 && health<=1)
        {
            playerMovement.canMove = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().freezeRotation = false;
            //playerCollisions[0].SetActive(true);
            //playerCollisions[1].SetActive(true);
        }

        health -= damage;

        

        for (int i = 0; i < playerModels.Length; i++)
        {
            playerModels[i].SetActive(false);
        }
        playerModels[health].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Damage(1);
        }

        if (other.gameObject.name == "LevelEnd")
        {
            Camera.main.GetComponent<LevelManager>().ChangeLevel(0);
        }
    }

   


}
