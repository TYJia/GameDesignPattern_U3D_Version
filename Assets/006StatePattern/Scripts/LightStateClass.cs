using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStateClass : MonoBehaviour
{

    public GameObject GreenLightObj;
    public GameObject YellowLightObj;
    public GameObject RedLightObj;

    private Material GreenLight;
    private Material YellowLight;
    private Material RedLight;

    private TrafficState TrafficLight;

    void Start()
    {
        GreenLight = GreenLightObj.GetComponent<Renderer>().material;
        YellowLight = YellowLightObj.GetComponent<Renderer>().material;
        RedLight = RedLightObj.GetComponent<Renderer>().material;
        SetState(new Pass());

    }

    void Update()
    {
        TrafficLight.ContinousStateBehaviour(this, GreenLight, YellowLight, RedLight);

    }

    public void SetState(TrafficState state)
    {
        TrafficLight = state;
        TrafficLight.StateStart(GreenLight, YellowLight, RedLight);
    }
}

public abstract class TrafficState
{
    public float Duration;

    public float Timer;

    public virtual void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        Timer = Time.time;
    }
    public abstract void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight);
}

public class Pass : TrafficState
{
    public Pass()
    {
        Duration = 2;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor("_EmissionColor", Color.green);
        YellowLight.SetColor("_EmissionColor", Color.black);
        RedLight.SetColor("_EmissionColor", Color.black);
    }
    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new PassBlink());
        }
    }
}

public class PassBlink : TrafficState
{
    private bool On = true;
    private float BlinkTimer = 0;

    public PassBlink()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
    }

    private static void SwitchGreen(Material GreenLight, bool open)
    {
        Color color = open ? Color.green : Color.black;
        GreenLight.SetColor("_EmissionColor", color);
    }

    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Wait());
        }
        if (Time.time > BlinkTimer + 0.2f)
        {
            On = !On;
            BlinkTimer = Time.time;
            SwitchGreen(GreenLight,On);
        }
    }
}

public class Wait : TrafficState
{
    public Wait()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor("_EmissionColor", Color.black);
        YellowLight.SetColor("_EmissionColor", Color.yellow);
        RedLight.SetColor("_EmissionColor", Color.black);
    }
    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Stop());
        }
    }
}

public class Stop : TrafficState
{
    public Stop()
    {
        Duration = 1;
    }

    public override void StateStart(Material GreenLight, Material YellowLight, Material RedLight)
    {
        base.StateStart(GreenLight, YellowLight, RedLight);
        GreenLight.SetColor("_EmissionColor", Color.black);
        YellowLight.SetColor("_EmissionColor", Color.black);
        RedLight.SetColor("_EmissionColor", Color.red);
    }
    public override void ContinousStateBehaviour(LightStateClass mLSC, Material GreenLight, Material YellowLight, Material RedLight)
    {
        if (Time.time > Timer + Duration)
        {
            mLSC.SetState(new Pass());
        }
    }
}
