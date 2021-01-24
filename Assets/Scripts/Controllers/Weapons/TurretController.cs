using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : FirearmModel
{
    public Transform target;

    public Transform turret;

    public SphereCollider targetArea;

    private void Start()
    {
        targetArea.radius = range;
    }

    private void Update()
    {
        if (target != null)
            turret.LookAt(target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        GetComponent<SphereCollider>().radius = range;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.transform;
            Shoot();
        }
    }



}
