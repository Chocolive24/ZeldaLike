using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameRoom : MonoBehaviour
{
    private Vector3 _respawnPoint;
    [SerializeField] private Transform _respawnTransform;
    [SerializeField] private PlayerController _player;
    
    [SerializeField] private Flame[] _flames;
    
    // Start is called before the first frame update
    void Start()
    {
        _respawnPoint = _respawnTransform.position;
        _player.SetRespawnPointPos(_respawnPoint);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        _player.SetRespawnPointPos(_respawnPoint);
        
        if (col.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _flames.Length; i++)
            {
                _flames[i].SetPlayerInRoom(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _flames.Length; i++)
            {
                _flames[i].SetPlayerInRoom(false);
            }
        }
    }
}
