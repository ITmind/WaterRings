using UnityEngine;
using System.Collections;

public class ParticleForceByColision : MonoBehaviour
{

    private float _radius;
    void Start()
    {
        _radius = GetComponent<SphereCollider>().radius;
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up));
        if (Physics.SphereCast(transform.position, _radius, transform.TransformDirection(Vector3.up), out hit))
        {
            var rig = hit.transform.GetComponent<Rigidbody>();
            if (rig != null)
            {
                var direction = rig.position - transform.position;
                rig.AddForceAtPosition(direction*100,hit.point);
                Debug.Log("set force");
            }
        }
    }
}
