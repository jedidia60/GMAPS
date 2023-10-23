using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        // Set the rb variable to the object's RigidBody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get the direction for where the gravitational force is to be applied on
        gravityDir = (planet.position - transform.position);

        // Set the direction to move the character based on the input given
        moveDir = new Vector3();
        moveDir = moveDir.normalized * -1f;

        // Add force to the RigidBody2D to move the character in the specified direction and the speed specified in force
        rb.AddForce(moveDir * force);

        // Normalize the direction of the gravity
        // Apply the gravitational force by adding force to the RigidBody2D with gravityStrength in the direction given by gravityNorm
        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        // Calculate the angle needed to rotate the character as they move around the planet
        float angle = Vector3.SignedAngle(transform.position, moveDir, Vector3.forward);

        // Slowly rotate the character by the angle calculated
        rb.MoveRotation(Quaternion.Euler(angle, 0, 0));
    }
}


