using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Game Mode")]
    public bool twinstick = false;
    public bool mouseaim = false;
    public bool classic = false;


    [Header ("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;

    [Header("Shooting")]
    public Transform gun;
    public GameObject bullet;
    public float fireRate = 0.5f;
    public bool canFire = true;


    // Start is called before the first frame update
    void Start()
    {
        if(twinstick)
        {
            gun.GetComponent<TwinStickAimScript>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;
        }

        else if(classic)
        {
            gun.GetComponent<TwinStickAimScript>().enabled = false;
            gun.GetComponent<GunScript>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // This is for moving the player
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        float dep = Input.GetAxis("Depth");


        transform.Translate(new Vector3(hor * playerSpeed * Time.deltaTime, ver * playerSpeed * Time.deltaTime, dep * playerSpeed * Time.deltaTime));

        //This is for shooting

        if(!twinstick && Input.GetButton("Fire1") && canFire)
        {
            StartCoroutine("Shoot");
        }


    }

    public IEnumerator Shoot()
    {
        Instantiate(bullet, gun.position, gun.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }


}
