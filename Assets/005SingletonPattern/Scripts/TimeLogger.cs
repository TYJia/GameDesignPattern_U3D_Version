using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeLogger : MonoBehaviour
{

    public static TimeLogger Instance;
    private StreamWriter mSW;

    void Awake()
    {
        Instance = this;
        LoggerInit(Application.dataPath + "\\005SingletonPattern\\Log.txt");
    }

    void LoggerInit(string path)
    {
        if (mSW == null)
        {
            mSW = new StreamWriter(path);
        }
    }

    public void WhiteLog(string info)
    {
        mSW.Write(DateTime.Now + ": " + info + "\n");
    }

    private void OnEnable()
    {
        LoggerInit(Application.dataPath + "\\005SingletonPattern\\Log.txt");
    }

    private void OnDisable()
    {
        mSW.Close();
    }
}
