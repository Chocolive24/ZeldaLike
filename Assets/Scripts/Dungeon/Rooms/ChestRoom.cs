using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRoom : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private Chest _chest;
    [SerializeField] private GameObject _void;

    [SerializeField] private GameObject _text;
    [SerializeField] private float _textDuration = 5f;
    
    public void Activate()
    {
        StartCoroutine(TextCoroutine());
        _void.SetActive(true);
        _player.SetAuraPower(true);
        _player.SetCanFireAura(true);
        _chest.DestroySelf();
    }
    
    private IEnumerator TextCoroutine()
    {
        _text.SetActive(true);
        yield return new WaitForSeconds(_textDuration);
        _text.SetActive(false);
    }
}
