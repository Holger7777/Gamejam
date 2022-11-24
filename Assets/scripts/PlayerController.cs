using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _ridgidbody;
    private Vector2 _movementInput;
    private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _hp;

    // Start is called before the first frame update
    private void Awake()
    {
        _ridgidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _hp = 30;
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if(_hp <= 0)
        {
            Dead();
        }
        else
        {
            Alive();
        }
    }

    private void Alive()
    {
        _animator.SetBool("awake", true);
        _ridgidbody.velocity = _movementInput * _speed;
        if (_movementInput.x != 0 || _movementInput.y != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
         Debug.Log(_movementInput);
    }

    private void Dead()
    {
        _ridgidbody.velocity = new Vector2(0, 0);
        _animator.SetBool("dead", true);
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger("takeDamage");
        _hp = _hp - damage;
    }
}
