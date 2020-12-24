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

    //  The rotation multiplier variable.
    [SerializeField]float rotationMultiplier = 100f;

    //  The rate of thrust
    [SerializeField]float thrustMultiplier = 1200f;

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
        //  Rotate the ship according to user input.
        Rotate();
       
        //  Thrusting the rocket according to user input.
        Thrust();

    }

    /// <summary>
    /// Used when the rocket collides into something solid.
    /// </summary>
    /// <param name="collision">The thing collided into.</param>
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // Do nothing
                print("O.K.");
                break;
            case "Fuel":
                print("Fuel Up!");
                break;
            default:
                //  Lose the game.
                print("YOU LOSE");
                break;
        }
    }

    /// <summary>
    /// Used when the rocket passes through a trigger object.
    /// </summary>
    /// <param name="trigger">The trigger passed through</param>
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Fuel"))
        {
            print("Fuel Up!!!");
        }
    }

    /// <summary>
    /// Determine whether the ship is to rotate left or right.
    /// </summary>
    private void Rotate()
    {
        //  Take manual control of rotation.
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ 
            | RigidbodyConstraints.FreezeRotationX 
            | RigidbodyConstraints.FreezeRotationY 
            | RigidbodyConstraints.FreezeRotationZ;

        //  The rotation each frame.
        float rotationPerFrame = rotationMultiplier * Time.deltaTime;

        //  Can only rotate one direction at a time.
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationPerFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationPerFrame);
        }

        //  Resume physics rotation.
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ 
                                | RigidbodyConstraints.FreezeRotationX 
                                | RigidbodyConstraints.FreezeRotationY;

    }

    //  Handles the rockets propulsion.
    private void Thrust()
    {
        //  Thrust per frame.
        float thrustPerFrame = thrustMultiplier * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            //  Relative force is needed so that the ship can rotate and thrust in different directions.
            rigidBody.AddRelativeForce(Vector3.up * thrustPerFrame);

            //  Play the thruster sound. Only play it if it isn't already playing.
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            //  Stop the thruster sound when no longer thrusting.
            audioSource.Stop();
        }
    }
}
