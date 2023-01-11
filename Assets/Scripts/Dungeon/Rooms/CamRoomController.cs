using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class CamRoomController : MonoBehaviour
{
    [SerializeField] private GameObject virtualCamera;
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _doorTimeSkip = 1f;
    [SerializeField] private float _changingRoomSpeed = 2f;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            virtualCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
            StartCoroutine(ChangingRoom());
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            virtualCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }
    
    private IEnumerator ChangingRoom()
    {
        // disable inputs during cam changing room.
        _player.SetInput(false);
        _player.SetVelocity(_player.Direction * _changingRoomSpeed);
        _player.SetState(PlayerState.WAIT);
        
        yield return new WaitForSeconds(_doorTimeSkip);
        _player.SetVelocity(Vector2.zero);
        _player.SetInput(true);
        _player.SetState(PlayerState.WALK);
    }
}
