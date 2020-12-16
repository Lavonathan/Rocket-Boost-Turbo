using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code attached to game rocket ship.
/// Allows the rocket to thrust and rotate based on keyboard input.
/// </summary>
public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    private static void processInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("Thrusting");
        }

        //  Can only rotate one direction at a time.
        if(Input.GetKeyDown(KeyCode.A))
        {
            print("Rotating Left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            print("Rotating Right"); 
        }
    }
}
