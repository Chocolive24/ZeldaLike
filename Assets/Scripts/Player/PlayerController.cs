using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    WALK,
    ATTACK,
    SLIDE,
    WAIT,
    DAMAGE
}
public class PlayerController : MonoBehaviour
{
    private PlayerState _currentState;
    private PlayerInput _input;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 5f;
    private Vector2 _moveValue;
    private Vector2 _direction;
    [SerializeField] private AnimController _animController;
    
    [SerializeField] private GameObject _swordAuraPrefab;
    private bool _swordAuraPower = false;
    private bool _canFireAura = false;
    
    [SerializeField] private FloatValue _currentHealth;
    [SerializeField] private FloatValue _nbrKey;
    
    private Vector3 _respawnPointPos;

    [SerializeField] private PlayerSound playerSound;

    // Getters
    // ----------------------------------------------------------------------------------------
    public PlayerState CurrentState { get { return _currentState; } }
    public Vector2 Velocity { get { return _rb.velocity; } }
    public float Speed { get { return _speed; } }
    public Vector2 Direction { get { return _direction; } }
    public bool SwordAuraPower { get { return _swordAuraPower; } }
    public FloatValue CurrentHealth { get { return _currentHealth; } }
    public FloatValue NbrKey { get { return _nbrKey; } }
    public Vector3 RespawnPointPos { get { return _respawnPointPos; } }
    public PlayerSound PlayerSound { get { return playerSound; } }
    
    // Setters
    // ----------------------------------------------------------------------------------------
    
    public void SetState(PlayerState newState) { _currentState = newState;}
    public void SetInput(bool input) { _input.enabled = input;}
    public void SetVelocity(Vector2 newVel) { _rb.velocity = newVel;}
    public void SetAuraPower(bool auraPower) { _swordAuraPower = auraPower;}
    public void SetCanFireAura(bool canFireAura) { _canFireAura = canFireAura;}
    public void SetRespawnPointPos(Vector3 newPos) { _respawnPointPos = newPos;}
    
    // ----------------------------------------------------------------------------------------
    
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_currentState == PlayerState.ATTACK && _currentState != PlayerState.DAMAGE)
        {
            StartCoroutine(_animController.AttackCoroutine());
        }
        
        else if (_currentState == PlayerState.WALK && _currentState != PlayerState.DAMAGE)
        {
            _rb.velocity = _moveValue * _speed;
        }
        
        else if (_currentState == PlayerState.SLIDE)
        {
            _rb.velocity = _direction * _speed;
        }
        
        if (_rb.velocity == Vector2.zero && _currentState != PlayerState.WAIT)
        {
            _input.enabled = true;
            _currentState = PlayerState.WALK;
        }
    }

    public void HandleMove(InputAction.CallbackContext ctx)
    {
        _moveValue = ctx.ReadValue<Vector2>();

        // Change the direction in which the player looks
        ChangeDirection();

        if (_currentState != PlayerState.SLIDE && _currentState != PlayerState.WAIT)
        {
            _currentState = PlayerState.WALK;
        }
    }

    public void HandleAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started && _currentState != PlayerState.ATTACK)
        {
            _currentState = PlayerState.ATTACK;
            playerSound.SwordSound.Play();

            if (_swordAuraPower && _canFireAura)
            {
                GameObject swordAuraInst = Instantiate(_swordAuraPrefab, transform.position, Quaternion.identity);
                SwordAura swordAura = swordAuraInst.GetComponent<SwordAura>();
                swordAura.AddVelocity(_direction);
            }
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            _currentState = PlayerState.WALK;
        }
    }
    
    private void ChangeDirection()
    {
        if (_moveValue.y < 0)
        {
            _direction = Vector2.down;
            _moveValue.x = 0;
        }
        if (_moveValue.y > 0)
        {
            _direction = Vector2.up;
            _moveValue.x = 0;
        }
        if (_moveValue.x > 0)
        {
            _direction = Vector2.right;
            _moveValue.y = 0;
        }
        if (_moveValue.x < 0)
        {
            _direction = Vector2.left;
            _moveValue.y = 0;
        }
    }
}
