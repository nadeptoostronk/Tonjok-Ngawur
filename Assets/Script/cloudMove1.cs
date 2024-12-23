using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove1 : MonoBehaviour
{
     // Kecepatan gerakan objek
    public float speed = 2.0f;

    // Jarak maksimal gerakan ke atas dan ke bawah dari posisi awal
    public float maxDistance = 2.0f;

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        // Menyimpan posisi awal objek
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Cek arah gerakan
        if (movingUp)
        {
            // Gerakan ke atas
            transform.position += Vector3.up * speed * Time.deltaTime;
            
            // Cek jika mencapai batas atas
            if (transform.position.y >= startPosition.y + maxDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            // Gerakan ke bawah
            transform.position += Vector3.down * speed * Time.deltaTime;

            // Cek jika mencapai batas bawah
            if (transform.position.y <= startPosition.y - maxDistance)
            {
                movingUp = true;
            }
        }
    }
}
