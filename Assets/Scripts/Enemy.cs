using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : Entity
{
    [SerializeField]
    private ParticleSystem _deathParticles;
    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach(ContactPoint2D hitPos in other.contacts)
        {
            if(hitPos.normal.y < 0 && other.gameObject.CompareTag("Player"))
            {;
                _deathParticles.Play();
                Die(gameObject, 0.1f);
            }
        }
    }

}
