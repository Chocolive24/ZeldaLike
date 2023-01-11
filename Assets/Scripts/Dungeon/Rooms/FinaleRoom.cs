using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleRoom : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private float _textDuration = 5f;
    
    [SerializeField] private AudioSource _BgMusic;
    private AudioSource _vicroryMusic;

    // Start is called before the first frame update
    void Start()
    {
        _vicroryMusic = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _vicroryMusic.Pause();
            _BgMusic.Play();
        }
        
    }

    public void Activate()
    {
        StartCoroutine(TextCoroutine());
        _BgMusic.Pause();
        _vicroryMusic.Play();
    }
    
    private IEnumerator TextCoroutine()
    {
        _text.SetActive(true);
        yield return new WaitForSeconds(_textDuration);
        _text.SetActive(false);
    }
}
