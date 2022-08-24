using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeAttenuation : MonoBehaviour
{
    [SerializeField] 
    private Transform _listenerTransform;
    private AudioSource _audioSource;
    [SerializeField]
    private float _minDist = 1f;
    [SerializeField]
    private float _maxDist = 20f;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        SetVolume();
    }
    
    private void SetVolume()
    {
        float dist = Vector3.Distance(transform.position, _listenerTransform.position);
 
        if(dist < _minDist)
        {
            _audioSource.volume = 1;
        }
        else if(dist > _maxDist)
        {
            _audioSource.volume = 0;
        }
        else
        {
            _audioSource.volume = 1 - ((dist - _minDist) / (_maxDist - _minDist));
        }
    }
}
