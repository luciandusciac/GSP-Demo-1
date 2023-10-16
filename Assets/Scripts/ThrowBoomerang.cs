using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ThrowBoomerang : MonoBehaviour
{

    public Transform boomerangOrigin;
    public Transform boomerangRange;
    public GameObject boomerangPrefab;
    public float boomerangSpeed = 10;
    private bool isFlipped;
    private bool boomerangThrown;  //prevents boomerang from being thrown multiple times if already thrown
    public GameObject player;
    private Transform bmr;
   
    void Start()
    {
        
    }

    void Update()
    {
        IsFlipped();

        if (Input.GetKeyDown(KeyCode.F) && !boomerangThrown)
        {
            boomerangThrown = true;
            //create new boomerang object
            var boomerang = Instantiate(boomerangPrefab, boomerangOrigin.position, boomerangOrigin.rotation);
            bmr = GameObject.FindGameObjectWithTag("Boomerang").transform;
            if (isFlipped)
            {
                boomerang.GetComponent<Rigidbody2D>().velocity = -boomerangOrigin.right * boomerangSpeed;
            }
            else if(!isFlipped)
            {
                boomerang.GetComponent<Rigidbody2D>().velocity = boomerangOrigin.right * boomerangSpeed;
            }
        }
        
        bmr.Rotate(0, 0, 50 * Time.deltaTime * 20);
  
    }

    private void IsFlipped()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isFlipped = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
           isFlipped= true;
        }
    }

    private void isThrown()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            boomerangThrown = true;
        }
    }



    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boomerang"))
        {
            Destroy(collision.gameObject);
            boomerangThrown = false;
        }

    }

}
