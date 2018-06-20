using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBase : MonoBehaviour
{

    private MeshRenderer mMR;
    private MeshFilter mMF;
    private Mesh mSharedMesh;
    private Material mSharedMaterial;
    private Matrix4x4[] TransInfos;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        mMR = GetComponent<MeshRenderer>();
        mMF = GetComponent<MeshFilter>();
        mSharedMaterial = mMR.sharedMaterial;
        mSharedMesh = mMF.sharedMesh;
    }

    internal void ObjInstancing(int num)
    {
        TransInfos = new Matrix4x4[num];
        for (int i = 0; i < num; i++)
        {
            SpecificAttributes sa = new SpecificAttributes();
            TransInfos[i] = sa.TransMatrix;
        }
        Graphics.DrawMeshInstanced(mSharedMesh, 0, mSharedMaterial, TransInfos);
    }
}
