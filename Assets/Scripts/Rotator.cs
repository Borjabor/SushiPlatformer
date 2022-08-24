using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
	private ParticleSystem _moveParticles;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 1000f, 0f) * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        _moveParticles.Play();
        
    }
}
