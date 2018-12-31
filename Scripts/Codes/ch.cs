using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch : MonoBehaviour {

    private CapsuleCollider OB;
//    private Transform OB2;
    /*  public float riseSpeed = 0.0005f;
      private float gravity = 0.0f;
      public bool rising;
      private Vector3 moveVector;



      // public Transform Floordt;

      */

    public Transform startPos, endPos;
    public Transform player;
    public float StoppingDistance = 5;
    public bool repeatable = false;
    public float speed = 1.0f;
    public float duration = 3.0f;

    float startTime, totalDistance;


    // Use this for initialization
    IEnumerator Start()
    {

        //OB2 = GameObject.FindGameObjectWithTag("Obsticle").transform;
        //OB = GetComponent<CapsuleCollider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        startTime = Time.time;
        totalDistance = Vector3.Distance(startPos.position, endPos.position);
        while (repeatable)
        {
            yield return RepeatLerp(startPos.position, endPos.position, duration);
            yield return RepeatLerp(endPos.position, startPos.position, duration);
        }


    }

    // Update is called once per frame
    void Update()
    {


        /*
        if (OB.transform.position.y < OB2.position.y)
        {



            gravity = -0.0002f;
            gravity += riseSpeed * Time.deltaTime;

            rising = true;
        }
        else
        {

            gravity += riseSpeed;

        }

        //X - Left and Right
        moveVector.x = 0;

        //Y - Up and Down
        moveVector.y += gravity;

        //Z - Forward and Backward
        moveVector.z = 0;


        OB.transform.position=(moveVector * Time.deltaTime);
        */
        if (Vector3.Distance(transform.position, player.position) < StoppingDistance)
        {
            if (!repeatable)
            {
                float currentDuration = (Time.time - startTime) * speed;
                float journeyFraction = currentDuration / totalDistance;
                this.transform.position = Vector3.Lerp(startPos.position, endPos.position, journeyFraction);
            }
        }

    }


    //  void OnTriggerEnter(Collider col)
    //{

    //  col.gameObject.SendMessage("Floor", null,
    // SendMessageOptions.DontRequireReceiver);
    //}



    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
       
            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                this.transform.position = Vector3.Lerp(a, b, i);
                yield return null;
            }

        
    }
}
