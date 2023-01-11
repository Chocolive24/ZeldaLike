using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private SignalSender _playerKeySignal;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Key"))
        {
            CatchKey(col);
            _player.NbrKey.AddValue(1);
            _playerKeySignal.Raise();
        }
        
        if (col.gameObject.CompareTag("TpPoint"))
        {
            var myTp = col.GetComponent<TpController>().TpPoint.transform.position;
            transform.position = myTp;
        }
        
        if (col.gameObject.CompareTag("ResetSlab"))
        {
            col.GetComponent<ResetSlab>().Activate();
        }

        if (col.gameObject.CompareTag("Chest"))
        {
            col.GetComponent<Chest>().OpenTheChest();
            _player.PlayerSound.TreasureSound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("NoAuraZone") && _player.SwordAuraPower)
        {
            _player.SetCanFireAura(false);
        }
        
        if (col.gameObject.CompareTag("Ice") && 
            _player.Velocity != Vector2.zero)
        {
            _player.SetState(PlayerState.SLIDE);
            _player.SetInput(false);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ice"))
        {
            _player.SetState(PlayerState.WALK);
            _player.SetInput(true);
        }
        
        if (col.gameObject.CompareTag("NoAuraZone") && _player.SwordAuraPower)
        {
            _player.SetCanFireAura(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Door"))
        {
            Doors door = col.gameObject.GetComponent<Doors>();

            if (door != null && _player.NbrKey.RunTimeValue >= door.NbrLock)
            {
                door.OpenTheDoors();
                _player.NbrKey.SubstractValue(door.NbrLock);
                _playerKeySignal.Raise();
            }
        }
        
        if ((col.gameObject.CompareTag("Walls") || 
            col.gameObject.CompareTag("Switch") || 
            col.gameObject.CompareTag("Block")) &&
            _player.CurrentState == PlayerState.SLIDE)
        {
            _player.SetState(PlayerState.WALK);
            _player.SetVelocity(Vector2.zero);
            _player.SetInput(true);
        }
        
        if (col.gameObject.CompareTag("TriggerWall"))
        {
            _player.SetState(PlayerState.WALK);
            _player.SetVelocity(Vector2.zero);
            _player.SetInput(true);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block") &&
            _player.CurrentState == PlayerState.SLIDE)
        {
            _player.SetState(PlayerState.WALK);
            _player.SetInput(true);
        }
    }
    
    private void CatchKey(Collider2D col)
    {
        Key key = col.gameObject.GetComponent<Key>();
        
        _player.PlayerSound.KeySound.Play();
        
        if (key != null)
        {
            key.DestroySelf();
        }
    }
}
