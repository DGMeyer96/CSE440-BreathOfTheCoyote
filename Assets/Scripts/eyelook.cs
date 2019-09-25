using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyelook : MonoBehaviour
{
    private Vector2 md;

    private Transform body;

    void Start()
    {
        body = this.transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md += mc;

        this.transform.localRotation = Quaternion.AngleAxis(-md.y, Vector3.right);

        body.localRotation = Quaternion.AngleAxis(md.x, Vector3.up);

    }
}
