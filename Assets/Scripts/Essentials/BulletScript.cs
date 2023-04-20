using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float destroyTime = 5f;

    // Start is called before the first frame update
    void Start()
    {   //destroys bullet after certain time
        Destroy(gameObject,destroyTime);
    }

    // Update is called once per frame
    void Update()
        //Moves bullet     
    {   
        transform.Translate(Vector3.forward*bulletSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }



}
