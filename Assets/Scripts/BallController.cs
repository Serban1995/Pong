using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{

    public GameObject sparkVFX;

    public float speed;

    private Vector3 direction;
    private Rigidbody rigidbody;

    private bool stopped = true;
    
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        direction = new Vector3(0.5f, 0f, 0.5f);
        
        ChooseDirection();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(stopped)
            return;

        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;
        
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
            hit = true;
        }

        if (other.CompareTag("Racket"))
        {
            direction.x = -direction.x;
            hit = true;
        }

        if (hit)
        {
          GameObject sparks = Instantiate(sparkVFX, transform.position, transform.rotation);
          Destroy(sparks, 4f);
        }
    }

    private void ChooseDirection()
    {
        float signX = Math.Sign(Random.Range(-1f, 1f));
        float signZ = Math.Sign(Random.Range(-1f, 1f));
        
        direction = new Vector3(0.5f * signX, 0f, 0.5f * signZ);
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Go()
    {
        stopped = false;
    }
}
