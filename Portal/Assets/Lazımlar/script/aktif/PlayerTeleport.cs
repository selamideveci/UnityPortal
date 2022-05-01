using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public bool renkDegisebilir;
    public bool renkDegis;

    public Collider2D ackapa;

    [SerializeField] private GameObject[] siyahlar;
    [SerializeField] private GameObject[] beyazlar;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ackapa = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (renkDegisebilir)
            {
                if (!renkDegis)
                {
                    _spriteRenderer.color = Color.black;
                    renkDegis = !renkDegis;
                    SiyahZeminleriAc();
                }
                else
                {
                    _spriteRenderer.color = Color.white;
                    renkDegis = !renkDegis;
                    BeyazZeminleriAc();
                }
            }
        }
    }

    

    private void SiyahZeminleriAc()
    {
        foreach (var item in siyahlar)
        {
            item.SetActive(true);
            
        }

        foreach (var item in beyazlar)
        {
            item.SetActive(false);
            
        }
    }

    private void BeyazZeminleriAc()
    {
        for (int i = 0; i < beyazlar.Length; i++)
        {
            beyazlar[i].SetActive(true);
            
        }

        for (int i = 0; i < siyahlar.Length; i++)
        {
            siyahlar[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("teleport"))
        {
            renkDegisebilir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("teleport"))
        {
            renkDegisebilir = false;
        }
    }
}
