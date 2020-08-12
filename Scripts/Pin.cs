using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Pin : MonoBehaviour
{
    private bool isPinned = false;
    
   public Rigidbody2D rb;
   public float speed = 20f;

    void Update()
   {
       if (!isPinned)
       {
           rb.MovePosition(rb.position + speed* Time.deltaTime*Vector2.up);
       }
   }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Rotator")
        {
            transform.SetParent(col.transform);
            float rand = UnityEngine.Random.Range(0.8f, 1.5f);
            if (UnityEngine.Random.Range(0, 10)%2 == 0)
            {
                rand *= -1f;
            } 
            col.GetComponent<Rotator>().speed *= rand;
           Score.pinCount++;
            isPinned = true;
        }

        if (col.tag == "Pin")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
