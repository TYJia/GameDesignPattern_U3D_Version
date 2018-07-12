using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour
{
    public GameObject PosIndicator;
    private Queue<Transform> mDestinationQueue;
    private Transform Destination;
    public float Speed = 1;

    void Start()
    {
        MouseInputManager.Instance.OnMouseClick += AddDestination;
        mDestinationQueue = new Queue<Transform>();
    }

    private void AddDestination()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 destination = ray.GetPoint(10);
        GameObject desIndi = GameObject.Instantiate(PosIndicator, destination, Quaternion.identity);
        mDestinationQueue.Enqueue(desIndi.transform);
    }

    void Update()
    {
        if (Destination == null && mDestinationQueue.Count > 0)
        {
            Destination = mDestinationQueue.Dequeue();
        }
        if (Destination != null)
        {
            float distance = Vector3.Distance(transform.position, Destination.position);
            transform.position = Vector3.Lerp(transform.position, Destination.position,Mathf.Clamp01(Time.deltaTime * Speed / distance));
            if (distance < 0.01f)
            {
                Destroy(Destination.gameObject);
            }
        }
    }
}

