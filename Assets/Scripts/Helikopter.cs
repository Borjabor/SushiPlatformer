using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helikopter : MonoBehaviour
{
    
    [SerializeField] private AudioSource _audioSource;
    void OnBecameVisible()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
