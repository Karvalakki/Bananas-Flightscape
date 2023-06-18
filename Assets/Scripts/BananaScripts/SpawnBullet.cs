using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public float bulletSpeed = 20;
    public float destroyTime = 5;
    public GameObject splashEffect;
    public GameObject appleHalf1;
    public GameObject appleHalf2;
    
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameManager>();
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * -bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            //print("Shot");
            Instantiate(splashEffect, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z-2 ), other.transform.rotation);
            GameObject half1 = Instantiate(appleHalf1, other.transform.position, other.transform.rotation);
            half1.GetComponent<Rigidbody>().AddForce(Vector3.right*-50);
            GameObject half2 = Instantiate(appleHalf2, other.transform.position, other.transform.rotation);
            half2.GetComponent<Rigidbody>().AddForce(Vector3.right * 50);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gm.AddScore();
        }

        

    }
}
