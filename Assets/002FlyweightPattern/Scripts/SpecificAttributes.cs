using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpecificAttributes
{
    public Matrix4x4 TransMatrix;
    internal Vector3 mPos;
    internal Vector3 mScale;
    internal Quaternion mRot;
    public SpecificAttributes()
    {
        mPos = UnityEngine.Random.insideUnitSphere * 10;
        mRot = Quaternion.LookRotation(UnityEngine.Random.insideUnitSphere);
        mScale = Vector3.one * UnityEngine.Random.Range(1, 3);
        TransMatrix = Matrix4x4.TRS(mPos, mRot, mScale);
    }
}
