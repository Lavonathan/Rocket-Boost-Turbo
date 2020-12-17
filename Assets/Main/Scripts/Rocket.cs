using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code attached to game rocket ship.
/// Allows the rocket to thrust and rotate based on keyboard input.
/// </summary>
public class Rocket : MonoBehaviour
{
    //  Get a reference to the RigidBody of the rocket.
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //  Get the reference of the rigid body. 
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
        
    }

    /// <summary>
    /// Process the input pressed.
    /// Determine whether the ship is thrusting, or rotating left or right.
    /// </summary>
    private void processInput()
    {
        //  Thrusting the rocket.
        if(Input.GetKey(KeyCode.Space))
        {
            //  Relative force is needed so that the ship can rotate and thrust in different directions.
            rigidBody.AddRelativeForce(Vector3.up);
        }

        //  Can only rotate one direction at a time.
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
