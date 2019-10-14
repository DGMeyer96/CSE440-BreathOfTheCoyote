using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera mainCamera;
    private float speed = 0f;
    private float direction = 0f;
    private Vector2 input;
    private Vector3 targetDirection;
    private Quaternion freeRotation;
    public float turnSpeed = 10f;
    private float turnSpeedMultiplier;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        speed = Mathf.Abs(moveHorizontal) + Mathf.Abs(Input.GetAxis("Vertical"));

        speed = Mathf.Clamp(speed, 0f, 1f);
        direction = 0f;

        UpdateTargetDirection();

        if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Vector3 lookDirection = targetDirection.normalized;
            freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
            var diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
            var eulerY = transform.eulerAngles.y;

            if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
            var euler = new Vector3(0, eulerY, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
        }
    }

    public virtual void UpdateTargetDirection()
    {
        turnSpeedMultiplier = 0.2f;
        var forward = transform.TransformDirection(Vector3.forward);
        forward.y = 0;

        //get the right-facing direction of the referenceTransform
        var right = transform.TransformDirection(Vector3.right);
        targetDirection = input.x * right + Mathf.Abs(input.y) * forward;
    }
}
