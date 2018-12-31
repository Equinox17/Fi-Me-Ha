using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour {

    public Rigidbody rb;
    public Collider cs = new BoxCollider();
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>("Obstilce");
        OnTriggerEnter(cs);
    }

    private Rigidbody GetComponent<rb>(string v)
    {
        v = "Obstilce";
        // rb = GetComponent<Rigidbody>(v);
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider fl)
    {
        if (fl.gameObject.name.Equals("Player"))
        {
            rb.isKinematic = false;
        }

    }

}
