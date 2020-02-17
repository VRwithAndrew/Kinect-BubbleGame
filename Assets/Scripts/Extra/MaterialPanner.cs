using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPanner : MonoBehaviour
{
    private MeshRenderer mMeshRenderer = null;
    private Vector2 mOffset = Vector2.zero;

    void Awake()
    {
        mMeshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        mOffset.x += 0.075f * Time.deltaTime;
        mMeshRenderer.material.SetTextureOffset("_MainTex", mOffset);
    }
}
