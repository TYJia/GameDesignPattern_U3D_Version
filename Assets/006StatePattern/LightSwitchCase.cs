using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchCase : MonoBehaviour {

    public LightState CurrentState = LightState.Off;

    private Light mLight;
    private Material mMat;

    public enum LightState
    {
        Off,
        Warm,
        White,
        WarmWhite
    }

    private void Awake()
    {
        mLight = GetComponent<Light>();
        mMat = GetComponentInChildren<Renderer>().material;
    }

    public void OnChangeState()
    {
        //状态转换
        switch (CurrentState)
        {
            case LightState.Off:
                CurrentState = LightState.Warm;
                break;
            case LightState.Warm:
                CurrentState = LightState.White;
                break;
            case LightState.White:
                CurrentState = LightState.WarmWhite;
                break;
            case LightState.WarmWhite:
                CurrentState = LightState.Off;
                break;
            default:
                CurrentState = LightState.Off;
                break;
        }
        //状态行为
        switch (CurrentState)
        {
            case LightState.Off:
                mLight.color = Color.black;
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            case LightState.Warm:
                mLight.color = new Color(0.8f, 0.5f, 0);
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            case LightState.White:
                mLight.color = new Color(0.8f, 0.8f, 0.8f);
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            case LightState.WarmWhite:
                mLight.color = new Color(1, 0.85f, 0.6f);
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
            default:
                mLight.color = Color.black;
                mMat.SetColor("_EmissionColor", mLight.color);
                break;
        }
    }
}
