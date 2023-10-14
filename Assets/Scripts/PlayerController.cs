using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1, 30)] private float _speed = 15f;
    [SerializeField, Range(5, 50)] private float _jumpStrength = 15f;
    private Rigidbody2D _rigidbody;
    private bool _grounded = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rigidbody.velocity = new Vector2(_speed * Input.GetAxisRaw("Horizontal"), _rigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && _grounded) {
            _rigidbody.AddForce(_jumpStrength * Vector2.up, ForceMode2D.Impulse);
            _grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            _grounded = true;
        }
    }
}
