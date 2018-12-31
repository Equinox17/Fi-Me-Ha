using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private const float laneLenght = 12.0f;

    //private float gravity = 0.4f;
    private float verticalvelocity;
    private float speed = 5.0f;
    public int lane = 0;

    private Vector3 moveVector;
    private CharacterController controller;

    // Use this for initialization
    void Start()
    {

        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        // 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switchLane(false);
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switchLane(true);
        }

        //where we should be later on

        Vector3 targetposition = transform.position.z * Vector3.forward;
        if (lane == -1)
            targetposition += Vector3.left * laneLenght;

        else if (lane == 1)
            targetposition += Vector3.right * laneLenght;


        // move
        moveVector = Vector3.zero;
        moveVector.x = (targetposition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        Vector3 dir = controller.velocity;
        dir.y = 0;
        transform.forward = dir;
    }

    private void switchLane(bool R_L)
    {

        lane += (R_L) ? 0 : -1;
        lane = Mathf.Clamp(lane, -1, 1);

        /* if (!R_L)
                {
                    lane --;
                    if (lane == -1)
                        lane = 0;

                }

                else
                {
                    lane--;
                    if (lane == -1)
                        lane = 0;
                }
            */
    }
}
