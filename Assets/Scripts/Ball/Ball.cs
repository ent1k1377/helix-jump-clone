using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject _paintSplash;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            platformSegment.GetComponentInParent<Platform>().Break();         
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out MeshCollider meshCollider))
        {
            GameObject paintSplash = Instantiate(_paintSplash, collision.GetContact(0).point - new Vector3(0, 0.07f, 0), Quaternion.Euler(-90, Random.Range(0, 360), 0));
            paintSplash.transform.parent = meshCollider.transform;
            Destroy(paintSplash.gameObject, 10f);
        }
    }
}
