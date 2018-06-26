using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject Bullet;


    private void Start()
    {
        AddObserver();
    }

    private void AddObserver()
    {
        Radio.Instance.OnEmitEvent += Shoot;
    }

    private void Shoot(Transform target)
    {
        GameObject go = Instantiate(Bullet, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody>().velocity = (target.position - transform.position).normalized * 30f;
    }
}
