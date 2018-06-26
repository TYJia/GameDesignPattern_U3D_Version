using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{

    public GameObject Ball;

    void Start()
    {
        Invoke("EmitBall", 1f);
    }

    void EmitBall()
    {
        GameObject go = Instantiate(Ball);
        go.GetComponent<Rigidbody>().velocity = Vector3.up * 2f;
        Invoke("EmitBall", Random.Range(0.5f, 1.5f));
        if (Radio.Instance.OnEmitEvent != null)
        {
            Radio.Instance.OnEmitEvent(go.transform);
        }
    }
}
