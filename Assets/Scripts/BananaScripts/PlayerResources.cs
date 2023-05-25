using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public GameObject[] playerModels;
    public int health = 5;

    public Transform gunR;
    public Transform gunL;
    public GameObject bullet;
    public float fireRate = 0.5f;
    public bool canFire = true;

    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < playerModels.Length; i++)
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
