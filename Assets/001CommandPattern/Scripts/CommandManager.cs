using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{

    public Avatar TheAvatar;

    private Stack<Command> mCommandStack;
    private float mCallBackTime;
    public bool IsRun = true;

    // Use this for initialization
    void Start()
    {
        mCommandStack = new Stack<Command>();
        mCallBackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRun)
        {
            Control();
        }
        else
        {
            RunCallBack();
        }

    }

    private void RunCallBack()
    {
        mCallBackTime -= Time.deltaTime;
        if (mCommandStack.Count > 0 && mCallBackTime < mCommandStack.Peek().TheTime)
        {
            mCommandStack.Pop().undo(TheAvatar);
        }
    }

    private Command InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return new CommandMove(new Vector3(0, Time.deltaTime, 0), mCallBackTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            return new CommandMove(new Vector3(0, -Time.deltaTime, 0), mCallBackTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            return new CommandMove(new Vector3(-Time.deltaTime, 0, 0), mCallBackTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            return new CommandMove(new Vector3(Time.deltaTime, 0, 0), mCallBackTime);
        }
        return null;
    }

    private void Control()
    {
        mCallBackTime += Time.deltaTime;
        Command cmd = InputHandler();
        if (cmd != null)
        {
            mCommandStack.Push(cmd);
            cmd.execute(TheAvatar);
        }
    }
}
