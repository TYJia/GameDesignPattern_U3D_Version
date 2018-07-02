using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{

    public string SpeakerName;
    public float GapTime = 1;
    private int index = 1;

    void Start()
    {
        InvokeRepeating("Speak", 0, GapTime);
    }

    void Speak()
    {
        string content = "I'm " + SpeakerName + ". (Index : " + index + ")";
        Debug.Log(content);
        TimeLogger.Instance.WhiteLog(content);
        index++;
    }
}
