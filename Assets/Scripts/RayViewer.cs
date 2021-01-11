using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50f;

    private Camera fpsCam;

    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        // Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f, 0));

        Vector3 lineOrigin = new Vector3(0, 0, -1.0f);
        // Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
        Debug.DrawRay(lineOrigin, transform.forward * weaponRange, Color.green);
    }
}
