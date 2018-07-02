using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    private string mName;
    private Vector3 mScale;

    void Start()
    {
        ReadRandomNameAndScale(Application.dataPath + "\\004PrototypePattern\\Dragons.txt");
        Invoke("DestroyThis", 10f);
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void ReadRandomNameAndScale(string path)
    {
        StreamReader sr = new StreamReader(path);
        string line;
        int target = Random.Range(0, 6) * 4;
        Debug.Log(target);
        int i = 0;
        while ((line = sr.ReadLine()) != null)
        {
            if (i == target)
            {
                mName = line;
                mScale.x = float.Parse(sr.ReadLine());
                mScale.y = float.Parse(sr.ReadLine());
                mScale.z = float.Parse(sr.ReadLine());
                break;
            }
            i++;
        }
        transform.localScale = mScale;
        name = mName;
    }

    void Update()
    {
        transform.Translate(-Time.deltaTime * Vector3.up * 2);
    }
}
