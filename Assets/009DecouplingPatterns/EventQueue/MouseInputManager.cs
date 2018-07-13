using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    public delegate void MouseInputeHandler();
    public MouseInputeHandler OnMouseClick;
    public static MouseInputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick();
        }
    }
}
