using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Boomerang : MonoBehaviour
{

    [SerializeField]
    public Transform target;

    public float speed = 500f;
    public float rotSpeed = 200000f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("BoomerangRange"))
        {
            
           Vector2 direction = (Vector2)target.position - rb.position;
           direction.Normalize();

           float rotAmount = Vector3.Cross(direction, transform.right).z;

           rb.angularVelocity = rotAmount * rotSpeed;

           rb.velocity = direction * 20;
            //rb.velocity *= -1;

        }
        
    }

}
