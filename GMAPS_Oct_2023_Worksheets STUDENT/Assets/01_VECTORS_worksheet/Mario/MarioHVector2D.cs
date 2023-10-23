using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir, moveDirNorm;
    private HVector2D staticPos;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staticPos = new HVector2D(-Vector2.up);
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);
        moveDir = new HVector2D(-gravityDir.y, gravityDir.x);
        moveDirNorm = moveDir;
        moveDirNorm.Normalize();

        rb.AddForce(moveDirNorm.ToUnityVector3() * force);

        gravityNorm = new HVector2D(gravityDir.x, gravityDir.y);
        gravityNorm.Normalize();
        rb.AddForce(gravityNorm.ToUnityVector3() * gravityStrength);

        float angle = staticPos.FindAngle(gravityDir);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
