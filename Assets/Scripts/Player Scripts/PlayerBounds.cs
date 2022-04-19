using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    public float MinX = -2.6f, MaxX = 2.6f, MinY = -5.6f;

    private bool _outOfBounds;
    
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > MaxX)
            temp.x = MaxX;

        if (temp.x < MinX)
            temp.x = MinX;

        transform.position = temp;

        if (temp.y <= MinY)
        {
            if (!_outOfBounds)
            {
                _outOfBounds = true;
            }
        }
    }
}
