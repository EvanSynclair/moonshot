using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    float clubForce = 5000f;
    Vector3 dir;
    public Transform target;

    private void Start()
    {
        dir = target.transform.position - transform.position;
        dir = dir.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.AddForce(dir * clubForce);
        }
    }
}
