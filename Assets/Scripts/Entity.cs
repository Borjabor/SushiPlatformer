using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D _rb;

    void Start()
    {       
        _rb = GetComponent<Rigidbody2D>();       

    }

    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _currentHealth;

    [SerializeField]
    private int _damageValue;

    public void TakeDamage(int damage){
        _currentHealth -= damage;
    }

    public void Die(Object obj, float time){
        Destroy(obj, time);
    }



}
