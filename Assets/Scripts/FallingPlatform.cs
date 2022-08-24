using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : Entity
{
    private bool _isFalling = false;
    [SerializeField]
    private GameObject _platesParent;
    [SerializeField]
    private GameObject _plateWhole;
    [SerializeField]
    private GameObject _plateBroken;
    
    private AudioSource _audioSource;
    [SerializeField] 
    private AudioClip _shatter;
    

    private void Awake()
    {
        _plateWhole.SetActive(true);
        _plateBroken.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
    }

    /*private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && !_isFalling){
            Invoke("Fall", 0.5f);
            StartCoroutine(Remove());
        }
        
    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (ContactPoint2D hitPos in other.contacts)
        {
            if (hitPos.normal.y <= 0 && other.gameObject.CompareTag("Player") && !_isFalling)
            {
                Invoke("Fall", 0.5f);
                StartCoroutine(Remove());
            }
        }
    }

    private void Fall(){
        _isFalling = true;
        _rb.isKinematic = false;
    }

    private IEnumerator Remove(){
        _plateWhole.SetActive(false);
        _plateBroken.SetActive(true);
        _audioSource.Play();
        yield return new WaitForSeconds(2f);
        _rb.isKinematic = true;
        _isFalling = false;
        _platesParent.SetActive(false);
        _plateWhole.SetActive(true);
        _plateBroken.SetActive(false);   
    }

    
}
