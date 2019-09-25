using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyelook : MonoBehaviour
{
    private Vector2 md;

    private Transform Player;

    void Start()
    {
        Player = this.transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md += mc;

        this.transform.localRotation = Quaternion.AngleAxis(-md.y, Vector3.right);

        Player.localRotation = Quaternion.AngleAxis(md.x, Vector3.up);

    }
}
