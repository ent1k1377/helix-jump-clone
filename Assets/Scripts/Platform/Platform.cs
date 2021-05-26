using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float _bounceForce = 50;
    private float _bounceRadius = 50;

    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}
