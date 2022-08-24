using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Entity
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            //Die();
        }
    }
}
