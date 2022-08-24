using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [HideInInspector]
    public bool MustPatrol;
    private bool _mustTurn;
    private Rigidbody2D _rb;
    [SerializeField]
    private Transform _groundCheckPos;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private Collider2D _bodyCollider;
    [SerializeField]
    private float _walkSpeed = 20f;
    private Animator _squashAndStretch;
    [SerializeField]
    private ParticleSystem _moveParticles;

    private AudioSource _walkingAudio;
    //[SerializeField] private AudioClip _deathAudio;
    

    private void Awake()
    {
        _walkingAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _squashAndStretch = GetComponentInChildren<Animator>();
        MustPatrol = true;
    }

    private void Update()
    {
        if(MustPatrol){
            Patrol();
        }

        if (_rb.velocity.x != 0)
        {
            _moveParticles.Play();
            if (!_walkingAudio.isPlaying)
            {
                _walkingAudio.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        if(MustPatrol){
            _mustTurn = !Physics2D.OverlapCircle(_groundCheckPos.position, 0.1f, _groundLayer);
        }
        
    }

    private void Patrol(){
        if(_mustTurn || _bodyCollider.IsTouchingLayers(_groundLayer)){
            Flip();
        }
        _rb.velocity = new Vector2(_walkSpeed * Time.fixedDeltaTime, _rb.velocity.y);
    }

    private void Flip(){
        MustPatrol = false;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        _walkSpeed *= -1;
        MustPatrol = true;

    }

    

}
