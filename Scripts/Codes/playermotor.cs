using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    public float speed = 10.0f;
    private float gravity = 0.0f;
    private float fallSpeed = 10.0f;

    //private float animeDuration = 3.0f;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        // Moves ball along the X and rotates on the z to simulate rolling
        //transform.Translate(5, 0, 0);


        //  if (Time.time < animeDuration)
        // {
        //   controller.Move(Vector3.forward * speed * Time.deltaTime);
        // return;
        //}

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            gravity = -0.5f;
        }
        else
        {

            gravity -= fallSpeed * Time.deltaTime;

        }

        //X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;// * Time.deltaTime;

        //Y - Up and Down
        moveVector.y = gravity;

        //Z - Forward and Backward
        moveVector.z = speed;



        // transform.Rotate(0,0,0 , Space.Self);

        // transform.Rotate(3, 2, 1);
        //   transform.Rotate(10, 5, 5);

        controller.Move(moveVector * Time.deltaTime);

        Vector3 dirx = controller.velocity;
        dirx.x = 1.5f;
        Vector3 diry = controller.velocity;
        diry.y = 0;
        Vector3 dirz = controller.velocity;
        dirz.x = 0;

        transform.Rotate(dirz);
        transform.Rotate(dirx);
        transform.Rotate(diry);

        //Vector3 diry = controller.velocity;
        //diry.y = 0;
        //transform.forward = diry;

    }

    public void modSpeed(float speedModifier)
    {

        speed = 10.0f + speedModifier;

    }

}
