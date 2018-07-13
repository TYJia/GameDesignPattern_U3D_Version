using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool {

    public List<GameObject> ActiveObjs;
    public List<GameObject> InactiveObjs;

    public ObjPool()
    {
        ActiveObjs = new List<GameObject>();
        InactiveObjs = new List<GameObject>();
    }

    public void AddObj(GameObject obj)
    {
        ActiveObjs.Add(obj);
    }

    public object GetObj()
    {
        if (InactiveObjs.Count > 0)
        {
            GameObject obj = InactiveObjs[0];
            ActiveObjs.Add(obj);
            InactiveObjs.Remove(obj);
            obj.SetActive(true);
            return obj;
        }
        return null;
    }

    public bool DisableObj(GameObject obj)
    {
        if (ActiveObjs.Contains(obj))
        {
            obj.SetActive(false);
            ActiveObjs.Remove(obj);
            InactiveObjs.Add(obj);
            return true;
        }
        return false;
    }

    public bool RemoveObj(GameObject obj)
    {
        if (ActiveObjs.Contains(obj))
        {
            ActiveObjs.Remove(obj);
            GameObject.Destroy(obj);
            return true;
        }
        else if (InactiveObjs.Contains(obj))
        {
            InactiveObjs.Remove(obj);
            GameObject.Destroy(obj);
            return true;
        }
        return false;
    }

    public void CleanPool()
    {
        for (int i = 0; i < ActiveObjs.Count; i++)
        {
            GameObject.Destroy(ActiveObjs[i]);
        }
        for (int i = 0; i < ActiveObjs.Count; i++)
        {
            GameObject.Destroy(InactiveObjs[i]);
        }
        ActiveObjs = new List<GameObject>();
        InactiveObjs = new List<GameObject>();
    }
}
