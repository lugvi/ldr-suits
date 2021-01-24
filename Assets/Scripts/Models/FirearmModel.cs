using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmModel : MonoBehaviour
{
    public Transform bulletSpawnPoint;

    public LayerMask hittableLayer;

    internal bool firing;

    public float accuracy;

    public float range;

    public float damage;

    public float shotsPerSecond;

    public bool canPierce;

    public int pierceAmount;

    public ParticleSystem muzzleFlashParticle;




    protected void Shoot()
    {
        Vector3 offset = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0) / accuracy;
        Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward + offset);
        if (!muzzleFlashParticle.isPlaying)
            muzzleFlashParticle.Play();

        Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 0.1f);
        if (canPierce)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, range, hittableLayer);
            if (hits.Length > 0)
            {
                for (int i = 0; i < pierceAmount; i++)
                {
                    var hittable = hits[i].collider.GetComponent<IHittable>();
                    if (hittable != null)
                        hittable.OnHit(damage: damage, hit: hits[i]);
                }
            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, hittableLayer))
            {
                var hittable = hit.collider.GetComponent<IHittable>();
                if (hittable != null)
                    hittable.OnHit(damage: damage, hit: hit);
            }

        }
    }

    virtual protected void OnFire()
    {
        firing = true;
    }

    virtual protected void OnStopFire()
    {
        firing = false;
        muzzleFlashParticle.Stop();
    }
}
