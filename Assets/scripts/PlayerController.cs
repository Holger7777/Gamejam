using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _ridgidbody;
    private Vector2 _movementInput;
    private Animator _animator;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashCooldown;
    private bool _dashReady;
    private float _speed;
    private float _hp;
    private float _maxHealth = 100;
    [SerializeField] GameObject _wand;

    //Public HP variables with a get for private variables for the Healthbar
    public float HP {get {return _hp;}}
    public float MaxHealth {get {return _maxHealth;}}

    private void Awake()
    {
        _ridgidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _hp = _maxHealth;
        _speed = _walkSpeed;
        _dashReady = true;
    }

    private void Start()
    {
        _animator.SetBool("awake", true);
    }

    private void FixedUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerSleep") ||
            _animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerWake"))
        {
            return;
        }
        
        if(_hp <= 0)
        {
            Dead();
        }
        else
        {
            Alive();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Alive()
    {
        _ridgidbody.velocity = _movementInput * _speed;
        if (_movementInput.x != 0 || _movementInput.y != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        if(_movementInput.x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (_movementInput.x > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }

    private void Dash()
    {
        _animator.SetTrigger("dash");
        _speed = _dashSpeed;
        //_ridgidbody.isKinematic = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        _dashReady = false;
        StartCoroutine(DashCooldown());
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(.5f);
        _speed = _walkSpeed;
        //_ridgidbody.isKinematic = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(_dashCooldown);
        _dashReady = true;
    }

    private void Dead()
    {
        Destroy(_wand);
        _ridgidbody.velocity = new Vector2(0, 0);
        _animator.SetBool("dead", true);
        FindObjectOfType<UIManager>().GameOver();
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger("takeDamage");
        _hp = _hp - damage;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
         Debug.Log(_movementInput);
    }

    private void OnDash(InputValue inputValue)
    {
        if(_dashReady)
        {
            Debug.Log("dash");
            Dash();
        }
    }
}
