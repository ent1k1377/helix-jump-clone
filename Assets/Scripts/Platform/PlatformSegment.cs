using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    public void Bounce(float force, Vector3 centre, float radius)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddExplosionForce(force, centre, radius);
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            Destroy(rigidbody.gameObject, 10f);
        }
    }
}
