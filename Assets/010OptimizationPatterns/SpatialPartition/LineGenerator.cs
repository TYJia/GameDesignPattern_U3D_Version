using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public bool UseOctTree = true;
    public bool Animated = false;
    private OctTree OT;
    public GameObject Point;
    public int PointNum = 1000;
    public float SpaceScale = 1;

    private List<Transform> mPointList;
    private List<LineRenderer> mLineList;

    // Use this for initialization
    void Start()
    {
        mPointList = new List<Transform>();
        mLineList = new List<LineRenderer>();
        OT = FindObjectOfType<OctTree>();
        for (int i = 0; i < PointNum; i++)
        {
            mPointList.Add(GameObject.Instantiate(Point, new Vector3(RandomValue(SpaceScale), 
                                                                    RandomValue(SpaceScale), 
                                                                    RandomValue(SpaceScale)), Quaternion.identity).transform);
            mLineList.Add(mPointList[i].GetComponent<LineRenderer>());
        }
        OT.GenerateTree(mPointList);
    }

    private float RandomValue(float value)
    {
        return Random.Range(-value, value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Animated)
        {
            for (int i = 0; i < PointNum; i++)
            {
                mPointList[i].position += new Vector3(RandomValue(SpaceScale / 100),
                                                    RandomValue(SpaceScale / 100),
                                                    RandomValue(SpaceScale / 100));

            }
        }

        if (UseOctTree)
        {
            OctTreeMethod();
        }
        else
        {
            CommonMethod();
        }
    }

    private void OctTreeMethod()
    {
        if (Animated)
        {
            OT.UpdateTree(mPointList);
        }
        for (int i = 0; i < PointNum; i++)
        {
            mLineList[i].SetPosition(0, mPointList[i].position);
            mLineList[i].SetPosition(1, OT.FindCloset(mPointList[i]).position);
        }
    }

    private void CommonMethod()
    {
        for (int i = 0; i < PointNum; i++)
        {
            float min = float.MaxValue;
            Vector3 closet = Vector3.zero;
            for (int j = 0; j < PointNum; j++)
            {
                if (i != j)
                {
                    float dis = Vector3.Distance(mPointList[i].position, mPointList[j].position);
                    if (dis < min)
                    {
                        min = dis;
                        closet = mPointList[j].position;
                    }
                }
            }
            mLineList[i].SetPosition(0, mPointList[i].position);
            mLineList[i].SetPosition(1, closet);
        }
    }
}
