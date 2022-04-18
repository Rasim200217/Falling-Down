using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float MoveSpeed = 2f;
    public float BoundY = 6f;

    public bool MovingPlatformLeft, MovingPlatformRight, IsBreakable, IsSpike, IsPlatform;

    private Animator _animator;

     void Awake()
    {
        if (IsBreakable)
            _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
    }

     void Move()
    {
        Vector2 temp = transform.position;
        temp.y += MoveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= BoundY)
            gameObject.SetActive(false);
        
    }
}
