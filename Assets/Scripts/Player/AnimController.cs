using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private Animator _animator;
    
    private Vector2 _moveInput;
    private static readonly int ATTACKING = Animator.StringToHash("attacking");
    private static readonly int MOVE_X = Animator.StringToHash("moveX");
    private static readonly int MOVE_Y = Animator.StringToHash("moveY");
    private static readonly int MOVING = Animator.StringToHash("moving");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_moveInput != Vector2.zero) // make the player look in the last direction he went
        {
            _animator.SetFloat(MOVE_X, _moveInput.x);
            _animator.SetFloat(MOVE_Y, _moveInput.y);
        }
    }

    public void HandleMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        
        if (ctx.started)
        {
            _animator.SetBool(MOVING, true);
        }

        if (ctx.canceled)
        {
            _animator.SetBool(MOVING, false);
        }
    }

    public void HandleShoot(InputAction.CallbackContext ctx)
    {
       
    }

    public IEnumerator AttackCoroutine()
    {
        _player.SetState(PlayerState.ATTACK);
        _animator.SetBool(ATTACKING, true);
        yield return null;
        
        _animator.SetBool(ATTACKING, false);
        yield return new WaitForSeconds(.3f);
        _player.SetState(PlayerState.WALK);
    }
}

