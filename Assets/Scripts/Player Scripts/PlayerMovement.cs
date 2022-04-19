using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float MoveSpeed = 2f;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            _rigidbody2D.velocity = new Vector2(MoveSpeed, _rigidbody2D.velocity.y);
        }
        
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            _rigidbody2D.velocity = new Vector2(-MoveSpeed, _rigidbody2D.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        _rigidbody2D.velocity = new Vector2(x, _rigidbody2D.velocity.y);
    }
}
