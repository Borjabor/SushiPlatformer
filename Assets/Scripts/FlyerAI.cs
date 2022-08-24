using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyerAI : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    

    [SerializeField]
    private float _speed = 30f;
    [SerializeField]
    private float _nexWaypointDistance = 3f;

    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachedEndOfPath = false;

    private Seeker _seeker;
    private Rigidbody2D _rb;

    private bool _playerDetected = false;

    void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }


    void FixedUpdate()
    {
        if(_path == null){
            return;
        }

        if(_currentWaypoint >= _path.vectorPath.Count){
            _reachedEndOfPath = true;
            return;
        }else{
            _reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * (_speed * Time.deltaTime);

        _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

        if(distance < _nexWaypointDistance){
            _currentWaypoint++;
        }

        if (_rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    void OnPathComplete(Path p){
        if(!p.error){
            _path = p;
            _currentWaypoint = 0;
        }
    }

    void UpdatePath(){
        if (_playerDetected)
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            _playerDetected = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            _playerDetected = false;
        }
    }
    
    
}
