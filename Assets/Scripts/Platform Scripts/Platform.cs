using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float MoveSpeed = 1.5f;
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

     void BreakableDeactivate()
     {
         Invoke("DeactivateGamObject", 0.3f);
     }

     void DeactivateGamObject()
     {
         SoundManager.Instance.IceBreakSound();
         gameObject.SetActive(false);
     }

     void OnTriggerEnter2D(Collider2D other)
     {
         if (other.tag == "Player")
         {
             if (IsSpike)
             {
                 other.transform.position = new Vector3(1000f, 1000f);
                 SoundManager.Instance.GameOverSound();
                 GameManager.Instance.RestartGame();
             }
         }
     }

     void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.tag == "Player")
         {
             if (IsBreakable)
             {
                 SoundManager.Instance.LandSound();
                 _animator.Play("Break");
             }

             if (IsPlatform)
             {
                 SoundManager.Instance.LandSound();
             }
         }
     }

     void OnCollisionStay2D(Collision2D other)
     {
         if (other.gameObject.tag == "Player")
         {
             if (MovingPlatformLeft)
             {
                 other.gameObject.GetComponent<Player>().PlatformMove(-1f);
             }
             if (MovingPlatformRight)
             {
                 other.gameObject.GetComponent<Player>().PlatformMove(1f);
             }
         }
     }
}
