using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    
    private float _time = 0.0f;
    [SerializeField] private float interpolationPeriod = 2.0f;
    
    private AudioSource _flameSound;
    private bool _canPlaySound = true;
    private bool _isPlayerInRoom = false;
    
    public AudioSource FlameSound
    {
        get { return _flameSound; }
    }
    
    public void SetPlayerInRoom(bool isPlayerInRoom)
    {
        _isPlayerInRoom = isPlayerInRoom;
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _flameSound = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        _time += Time.deltaTime;

        if ((_isPlayerInRoom && _canPlaySound) && !_flameSound.isPlaying)
        {
            _flameSound.Play();
        }

        if (!_canPlaySound || !_isPlayerInRoom)
        {
            _flameSound.Pause();
        }

        if (_time >= interpolationPeriod)
        {
            _time = 0.0f;
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
            _boxCollider2D.enabled = !_boxCollider2D.enabled;
            _canPlaySound = !_canPlaySound;
        }
    }
}
