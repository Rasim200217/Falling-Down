using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float MoveSpeed = 2f;

    private float _screenWith;

    public Player Player;
    
 

    void Awake()
    {
        _rigidbody2D = Player.GetComponent<Rigidbody2D>();
        _screenWith = Screen.width;
    }


    void Update()
    {
        //Move();

        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > _screenWith /2)
            {
                Move(MoveSpeed);
            }
            if (Input.GetTouch(i).position.x < _screenWith / 2)
            {
                Move(-MoveSpeed);
            }

            ++i;
        }

    }

    /*void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            _rigidbody2D.velocity = new Vector2(MoveSpeed, _rigidbody2D.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            _rigidbody2D.velocity = new Vector2(-MoveSpeed, _rigidbody2D.velocity.y);
        }

    }*/
    
    void Move(float move)
    {
        //_rigidbody2D.AddForce(new Vector2(hor * MoveSpeed * Time.deltaTime, 0));
        _rigidbody2D.velocity = new Vector2(move, _rigidbody2D.velocity.y);
    
    }

    private void FixedUpdate()
    {
        #if UNITY_EDITOR
        Move(Input.GetAxis("Horizontal"));
        #endif
    }

    
}

