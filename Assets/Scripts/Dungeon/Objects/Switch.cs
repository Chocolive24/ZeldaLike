using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject _blueWalls;
    [SerializeField] private GameObject _redWalls;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _blueSprite;
    [SerializeField] private Sprite _redSprite;
    
    private bool _isTriggerded = false;

    [SerializeField] private SwitchSound _switchSound;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Attack")&& !_isTriggerded)
        {
            ActivateSwitch();
            _isTriggerded = true;
        }
        else if (col.gameObject.CompareTag("SwordAura") && !_isTriggerded)
        {
            ActivateSwitch();
            _isTriggerded = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Attack") || 
            col.gameObject.CompareTag("SwordAura"))
        {
            _isTriggerded = false;
        }
    }

    public void ActivateSwitch()
    {
        if (_spriteRenderer.sprite == _blueSprite)
        {
            _spriteRenderer.sprite = _redSprite;
            _blueWalls.SetActive(false);
            _redWalls.SetActive(true);
            _switchSound.SwitchOnSound.Play();
        }
        else if (_spriteRenderer.sprite == _redSprite)
        {
            _spriteRenderer.sprite = _blueSprite;
            _redWalls.SetActive(false);
            _blueWalls.SetActive(true);
            _switchSound.SwitchOffSound.Play();
        }
    }
}
