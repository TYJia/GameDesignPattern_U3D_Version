using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightManager : MonoBehaviour
{

    public GameObject TheObj;
    public bool IsFlyweight = true;

    private List<Transform> ObjTrs;

    void Start()
    {
        ObjTrs = new List<Transform>();

    }

    void Update()
    {
        if (IsFlyweight == false)
        {
            GenerateObjsWithoutInstancing(1000);
        }
        else
        {
            GenerateObjsWithInstancing(1000);
        }
    }

    public void GenerateObjsWithInstancing(int num)
    {
        for (int i = 0; i < ObjTrs.Count; i++)
        {
            DestroyImmediate(ObjTrs[i].gameObject);
        }
        ObjTrs.Clear();
        TheObj.GetComponent<CubeBase>().ObjInstancing(num);
    }

    public void GenerateObjsWithoutInstancing(int num)
    {
        for (int i = 0; i < ObjTrs.Count; i++)
        {
            DestroyImmediate(ObjTrs[i].gameObject);
        }
        ObjTrs.Clear();
        for (int i = 0; i < num; i++)
        {
            SpecificAttributes sa = new SpecificAttributes();
            Transform tr = Instantiate(TheObj, sa.mPos, sa.mRot).transform;
            tr.GetComponent<MeshRenderer>().material.color = Color.white * ((float)i/(float)num * 0.1f + 0.95f);
            tr.localScale = sa.mScale;
            ObjTrs.Add(tr);
        }
    }
}
