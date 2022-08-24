using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRespawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _fallingPlatform;
    private Vector2 _startingPos;

    private void Awake()
    {
        _startingPos = _fallingPlatform.transform.position;
    }

    private void Update()
    {
        if(_fallingPlatform.activeSelf == false){
            _fallingPlatform.transform.position = _startingPos;
            StartCoroutine(Respawn());
        }
    }
    
    private IEnumerator Respawn(){
        yield return new WaitForSeconds(1.5f);
        _fallingPlatform.SetActive(true);
    }
}
