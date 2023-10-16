using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CollapsiblePlatform : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(CollapsePlatform), 0.5f);
            Invoke(nameof(DestroyPlatform), 1.2f);
        }
    }

    private void CollapsePlatform()
    {
        rb = this.AddComponent<Rigidbody2D>();
    }

    private void DestroyPlatform()
    {
        this.gameObject.SetActive(false);
    }
}
