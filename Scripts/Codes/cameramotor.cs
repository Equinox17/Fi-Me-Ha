using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramotor : MonoBehaviour {

    private Transform lookAtPlayer;
    private Vector3 cmOffset;
    private Vector3 mVector;
    //  private float transition = 0.0f;
    // private float animeDuration = 3.0f;
    // private  Vector3 animeOffset = new Vector3 (0, 5, 5);

    // Use this for initialization
    void Start()
    {

        lookAtPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        cmOffset = transform.position - lookAtPlayer.position;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = lookAtPlayer.position + cmOffset;




    }
}
