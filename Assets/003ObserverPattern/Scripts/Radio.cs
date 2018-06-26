using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

    public delegate void EmitHandler(Transform target);
    public EmitHandler OnEmitEvent;
    public static Radio Instance;

    void Awake()
    {
        Instance = this;
    }
}
