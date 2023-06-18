using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xyspeed = 10;
    public float lookSpeed = 340;

    public Transform aimTarget;

    public float speed = 5;
    public float forwardSpeed = 5;
    public float moveSpeed = 5;
    public float boostSpeed = 10;
    public float reducedSpeed = 5;

    public bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;



        if (canMove)
        {
            float ver = Input.GetAxis("Vertical");
            float hor = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(hor * moveSpeed * Time.deltaTime, ver * moveSpeed * Time.deltaTime));

                

            if (Input.GetButton("Jump"))
            {
                speed = boostSpeed;
            }
            else if (Input.GetButton("Left ctrl"))
            {
                speed = reducedSpeed;
            }

            else
            {
                speed = forwardSpeed;
            }

            



        }


    }

    



       //Locks player movement in screen limits
   /* void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RotationalLook(float h, float v, float speed)
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(h, v, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed);
    }
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.position, .5f);
        Gizmos.DrawSphere(aimTarget.position, .15f);
    }
   */
}
