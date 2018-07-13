using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctTree : MonoBehaviour
{
    public TreeNode TheTree;
    [Range(1, 1000)]
    public int MaxNum = 2;
    private float Extents = 0.01f;
    public bool Show = true;
    private bool mShow;
    private Dictionary<Transform, TreeNode> trDic;

    public GameObject SpaceBoxPrefab;

    private void Update()
    {
        if (Show != mShow)
        {
            mShow = Show;
            SpaceBoxPrefab.SetActive(Show);
            ShowBox(TheTree, Show);
        }
    }

    private void ShowBox(TreeNode theTree, bool show)
    {
        theTree.SpaceBox.gameObject.SetActive(show);
        if (theTree.Children != null)
        {
            for (int i = 0; i < 8; i++)
            {
                ShowBox(theTree.Children[i], show);
            }
        }
    }

    public class TreeNode
    {
        public TreeNode Parent = null;
        public TreeNode[] Children;
        public Transform SpaceBox;
        public Bounds BoxBounds;
        public List<Transform> Objs;
        public Vector3 BorderMin, BorderMax;
        public TreeNode()
        {
            Objs = new List<Transform>();
        }
        public TreeNode(TreeNode parent)
        {
            Objs = new List<Transform>();
            Parent = parent;
        }
        public void GenerateChildren()
        {
            Children = new TreeNode[8];
            for (int i = 0; i < 8; i++)
            {
                Children[i] = new TreeNode(this);
            }
        }

    }

    private void Awake()
    {
        TheTree = new TreeNode();
        trDic = new Dictionary<Transform, TreeNode>();
        SpaceBoxPrefab.SetActive(Show);
    }

    public void UpdateTree(List<Transform> objs)
    {
        for (int i = 0; i < objs.Count; i++)
        {
            UpdateObj(objs[i]);
        }
    }

    private void UpdateObj(Transform tr)
    {
        if (!trDic[tr].BoxBounds.Contains(tr.position))
        {
            trDic[tr].Objs.Remove(tr);
            FindInParent(trDic[tr], tr);
        }
    }

    private void FindInParent(TreeNode tn, Transform tr)
    {
        if (tn.Parent != null)
        {
            if (tn.Parent.BoxBounds.Contains(tr.position))
            {
                trDic[tr] = tn.Parent;
                FindInChildren(tn.Parent, tr);
            }
            else
            {
                tn.Parent.Objs.Remove(tr);
                FindInParent(tn.Parent, tr);
            }
        }
        else
        {
            TheTree.Objs.Add(tr);
            trDic[tr] = TheTree;
        }
    }

    private void FindInChildren(TreeNode tn, Transform tr)
    {
        if (tn.Children != null)
        {
            for (int i = 0; i < 8; i++)
            {
                if (tn.Children[i].BoxBounds.Contains(tr.position))
                {
                    if (!tn.Children[i].Objs.Contains(tr))
                    {
                        tn.Children[i].Objs.Add(tr);
                    }
                    trDic[tr] = tn.Children[i];
                    FindInChildren(tn.Children[i], tr);
                }
            }
        }
    }

    void NodeInit(TreeNode tn, Transform spaceBox, List<Transform> objs)
    {
        tn.SpaceBox = spaceBox;
        tn.BoxBounds.center = spaceBox.position;
        tn.BoxBounds.extents = spaceBox.lossyScale;
        tn.BorderMin = spaceBox.position - spaceBox.lossyScale * 0.5f;
        tn.BorderMax = spaceBox.position + spaceBox.lossyScale * 0.5f;

        for (int i = 0; i < objs.Count; i++)
        {
            if (tn.BoxBounds.Contains(objs[i].position))
            {
                tn.Objs.Add(objs[i]);
                if (trDic.ContainsKey(objs[i]))
                {
                    trDic[objs[i]] = tn;
                }
                else
                {
                    trDic.Add(objs[i], tn);
                }
                //objs.Remove(objs[i]);
                //i--;
            }
        }
    }

    public void GenerateTree(List<Transform> objs)
    {
        GenerateRoot(objs);
        CutSpace(TheTree);
    }

    public Transform FindCloset(Transform tr)
    {
        return FindCloset(trDic[tr], tr);
    }

    private Transform FindCloset(TreeNode treeNode, Transform tr)
    {
        TreeNode tn = TheTree;
        if (treeNode.Parent != null)
        {
            tn = treeNode.Parent;
        }
        float min = float.MaxValue;
        Transform closet = tr;
        for (int j = 0; j < tn.Objs.Count; j++)
        {
            if (tr != tn.Objs[j])
            {
                float dis = Vector3.Distance(tr.position, tn.Objs[j].position);
                if (dis < min)
                {
                    min = dis;
                    closet = tn.Objs[j];
                }
            }
        }
        return (closet);
    }

    private void CutSpace(TreeNode theTree)
    {
        if (theTree.Objs.Count > MaxNum)
        {
            Vector3 borderMin, borderMax;
            Vector3 halfBorder = (theTree.BorderMax - theTree.BorderMin) * 0.5f;

            theTree.GenerateChildren();

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        int index = x * 4 + y * 2 + z;

                        //Debug.Log(index);

                        Transform spaceBox = Instantiate(SpaceBoxPrefab).transform;

                        borderMin.x = theTree.BorderMin.x + halfBorder.x * x;
                        borderMin.y = theTree.BorderMin.y + halfBorder.y * y;
                        borderMin.z = theTree.BorderMin.z + halfBorder.z * z;
                        borderMax.x = theTree.BorderMax.x - halfBorder.x * (1 - x);
                        borderMax.y = theTree.BorderMax.y - halfBorder.y * (1 - y);
                        borderMax.z = theTree.BorderMax.z - halfBorder.z * (1 - z);


                        spaceBox.position = (borderMin + borderMax) * 0.5f;
                        spaceBox.localScale = borderMax - borderMin;

                        spaceBox.SetParent(theTree.SpaceBox);

                        NodeInit(theTree.Children[index], spaceBox, theTree.Objs);
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                CutSpace(theTree.Children[i]);
            }
        }
    }

    private void GenerateRoot(List<Transform> objs)
    {
        Vector3 borderMin, borderMax;

        if (objs.Count > 0)
        {
            borderMin = borderMax = objs[0].position;
            for (int i = 1; i < objs.Count; i++)
            {
                borderMin.x = Min(objs[i].position.x - Extents, borderMin.x);
                borderMin.y = Min(objs[i].position.y - Extents, borderMin.y);
                borderMin.z = Min(objs[i].position.z - Extents, borderMin.z);
                borderMax.x = Max(objs[i].position.x + Extents, borderMax.x);
                borderMax.y = Max(objs[i].position.y + Extents, borderMax.y);
                borderMax.z = Max(objs[i].position.z + Extents, borderMax.z);
            }
            Transform spaceBox = Instantiate(SpaceBoxPrefab).transform;
            if (borderMin != borderMax)
            {
                spaceBox.position = (borderMin + borderMax) * 0.5f;
                spaceBox.localScale = borderMax - borderMin;
            }
            else
            {
                spaceBox.position = borderMin;
                spaceBox.localScale = Vector3.one * 2;
            }
            spaceBox.SetParent(transform);
            NodeInit(TheTree, spaceBox, objs);
        }
    }

    private static float Min(float a, float b)
    {
        return a < b ? a : b;
    }

    private static float Max(float a, float b)
    {
        return a > b ? a : b;
    }
}
