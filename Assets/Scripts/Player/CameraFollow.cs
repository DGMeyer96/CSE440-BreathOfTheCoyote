using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerController pC;
    public Transform Player;
    private Vector2 md;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 offset2;
    public float rotatespeed = 5f;

    void FixedUpdate()
    {

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("RotateCam") > 0 || pC.isfalling)
        {
            
            Vector3 desiredPosition = Player.TransformPoint(offset);//move cam
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(Player);
            
            Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));//move players rotation with cam
            md += mc;
            //Player.transform.localRotation = Quaternion.AngleAxis(-md.y, Vector3.right);
            Player.localRotation = Quaternion.AngleAxis(md.x, Vector3.up);
            
            offset2 = offset;//set nonmoving cam to moving cam start offset
        }
        else
        {
            Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));//move players rotation with cam
            Quaternion camTurnAngle = Quaternion.Euler(mc);

            offset2 = camTurnAngle * offset2;

            Vector3 desiredPosition = Player.TransformPoint(offset2);            //move cam not palyer
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(Player);

        }
        

    }
}
