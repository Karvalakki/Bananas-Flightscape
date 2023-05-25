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
        Instantiate(bullet, gunL.position, gunL.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        Instantiate(bullet, gunR.position, gunR.rotation);
        canFire = false;
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
    }

   


}
