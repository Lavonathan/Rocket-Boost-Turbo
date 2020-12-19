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

    //  Declare the audio source variable.
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //  Get the reference of the rigid body. 
        rigidBody = GetComponent<Rigidbody>();

        //  get the reference to the audio source.
        audioSource = GetComponent<AudioSource>();
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
            
            //  Play the thruster sound. Only play it if it isn't already playing.
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            //  Stop the thruster sound when no longer thrusting.
            audioSource.Stop();
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
