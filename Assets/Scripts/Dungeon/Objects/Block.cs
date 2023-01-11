using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Vector3 _spawnPoint;
    private Rigidbody2D _rb;
    private AudioSource _slideSound;
    private bool _isSliding;
    
    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        _slideSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity != Vector2.zero && !_slideSound.isPlaying)
        {
            _slideSound.Play();
        }
    }
    
    public void ResestPos()
    {
        transform.position = _spawnPoint;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ice"))
        {
            _rb.drag = 0;
        }
    }
}
