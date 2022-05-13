using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void PlatformMove(float x)
    {
        _rigidbody2D.velocity = new Vector2(x, _rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SoundManager.Instance.DeathSound();
            GameManager.Instance.RestartGame();
            gameObject.SetActive(false);
        }
    }
}
