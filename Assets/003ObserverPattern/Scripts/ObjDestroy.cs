using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Invoke("DestroyThis",3f);
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
