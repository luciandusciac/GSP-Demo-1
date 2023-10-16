using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class JetPack : MonoBehaviour
{

    private float fuel = 100f;
    private float currentFuel;
    private float jetForce = 10f;
    private float burnRate = 20f;

    private Rigidbody2D rb;
    public Slider fuelSlider;

    private bool isFlying;
    private bool jetpackOn = false;

    public ParticleSystem jetFire;
    // Start is called before the first frame update
    void Start()
    {
        currentFuel = fuel;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = currentFuel / fuel;
        isFlying = Input.GetKey(KeyCode.Space);
        CheckFuel();
    }

    private void FixedUpdate()
    {
        Fly();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.transform.SetParent(collision.transform);
            this.transform.localPosition = new Vector3((float)0.0309999995, (float)0.0140000004, 0);
            jetpackOn = true;
            fuelSlider.gameObject.SetActive(true);
        }
        
    }

    private void Fly()
    {
        if (jetpackOn && isFlying)
        {
            rb.AddForce(transform.rotation * Vector2.up * jetForce);
            currentFuel -= burnRate * Time.deltaTime;
            rb.gravityScale = 0;
            jetFire.Play();
        }
        else if(jetpackOn && !isFlying)
        {
            rb.gravityScale = 1f;
            jetFire.Stop();
        }
    }

    private void CheckFuel()
    {
        if(currentFuel < 1)
        {
            this.gameObject.SetActive(false);
            fuelSlider.gameObject.SetActive(false);
            jetpackOn = false;
            rb.gravityScale = 1;
        }
    }
}
