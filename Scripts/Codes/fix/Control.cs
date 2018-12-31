using UnityEngine;

public class Control : MonoBehaviour {

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();


	}
    	
	// Update is called once per frame
	void Update () {

      FixUpdate();
	}

    // Update for physics stuff
    void FixUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(move * 5);
    }

    
}
