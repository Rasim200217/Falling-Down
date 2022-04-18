using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float SpeedScroll = 0.3f;

    private MeshRenderer _meshRenderer;
    
    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = _meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * SpeedScroll;

        _meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
