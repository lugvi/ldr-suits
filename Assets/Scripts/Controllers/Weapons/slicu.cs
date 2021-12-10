using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slicu : MonoBehaviour
{
    public Transform p;

    public GameObject target;


    private void Awake()
    {
        InputManager.instance.gc.Gameplay.Reload.performed += (_) => slicccc();
    }

    Vector3 transformedNormal;
    Vector3 transformedStartingPoint;
    void slicccc()
    {
        Plane plane = new Plane();

        plane.SetNormalAndPosition(
                transformedNormal,
                transformedStartingPoint);

        var direction = Vector3.Dot(Vector3.up, transformedNormal);

        //Flip the plane so that we always know which side the positive mesh is on
        if (direction < 0)
        {
            plane = plane.flipped;
        }

        GameObject[] slices = Slicer.Slice(plane, target.gameObject);
        Destroy(target.gameObject);
    }
    private void Update()
    {
        Vector3 normal = p.up;

        //Transform the normal so that it is aligned with the object we are slicing's transform.
        transformedNormal = ((Vector3)(target.transform.localToWorldMatrix.transpose * normal)).normalized;


        //Get the enter position relative to the object we're cutting's local transform
        transformedStartingPoint = target.gameObject.transform.InverseTransformPoint(target.transform.position);

        Debug.DrawRay(transformedStartingPoint, transformedNormal, Color.red);
        Debug.DrawRay(transformedStartingPoint + Vector3.right * 0.1f, normal, Color.blue);

        // Debug.DrawRay(target.transform.position, p.up, Color.blue);
        // Debug.DrawRay(target.transform.position + Vector3.right * 0.1f, normal, Color.blue);
     
    }
}
