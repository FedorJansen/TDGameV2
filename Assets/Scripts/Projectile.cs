using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public delegate void Scoe();
    public static Scoe scoe;
    public GameObject target;
    private Rigidbody rb;
    public float speed;
    private float distanceToTarget;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            moveToTarget();
            distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
            if (distanceToTarget <= 0.5f)
            {
                Destroy(gameObject);
            }  
        }

    }


    public void moveToTarget() 
    {
        Vector3 dir = ((target.transform.position + target.transform.forward) - transform.position);
        rb.AddForce(dir * speed);
        
    }

    public void OnCollisionEnter(Collision other)
    {
        Destroy(target);
        scoe();
        Destroy(gameObject);
        
    }
}
