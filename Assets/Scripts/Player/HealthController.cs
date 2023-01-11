using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private SignalSender _playerHealthSignal;
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _deathTime;
    
    public void TakeDamage(float damage)
    {
        _player.CurrentHealth.SubstractValue(damage);
        _player.PlayerSound.DamageSound.Play();

        if (_player.CurrentHealth.RunTimeValue > 0)
        {
            _playerHealthSignal.Raise();
        }
        else
        {
            _player.SetVelocity(Vector2.zero);
            StartCoroutine(DeathCoroutine());
        }
    }

    private IEnumerator DeathCoroutine()
    {
        _playerHealthSignal.Raise();
        _player.transform.position = _player.RespawnPointPos;
        _player.SetInput(false);
        _player.SetState(PlayerState.WAIT);
        yield return new WaitForSeconds(_deathTime);
        
        _player.CurrentHealth.SetValue(6);
        _playerHealthSignal.Raise();
        _player.SetInput(true);
        _player.SetState(PlayerState.WALK);
    }
}
