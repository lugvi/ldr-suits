using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunController : FirearmModel
{

    public float minBarrelSpinSpeed;
    public float maxBarrelSpinSpeed;

    float currentBarrelSpinSpeed;

    public float spinAcceleration;

    public Transform barrels;

    GameplayControls controls;

    private void OnEnable()
    {
        controls = InputManager.instance.gc;
        controls.Gameplay.Fire.performed += (c) => OnFire();
        controls.Gameplay.Fire.canceled += (c) => OnStopFire();
    }

    private void OnDisable()
    {
        controls.Gameplay.Fire.performed -= (c) => OnFire();
        controls.Gameplay.Fire.canceled -= (c) => OnStopFire();
    }

    IEnumerator AutoFire()
    {
        while (firing)
        {
            if (currentBarrelSpinSpeed > minBarrelSpinSpeed)
            {
                //how many times per frame should the gun shoot
                for (int i = 0; i < Mathf.Max(1, Mathf.Round(Time.deltaTime * shotsPerSecond)); i++)
                {
                    Shoot();
                }

                yield return new WaitForSeconds(1 / shotsPerSecond);
            }
            else
                yield return null;


        }

    }

    IEnumerator SpinUp()
    {
        while (firing)
        {
            if (currentBarrelSpinSpeed < maxBarrelSpinSpeed)
            {
                currentBarrelSpinSpeed += spinAcceleration * Time.deltaTime;
            }
            barrels.Rotate(Vector3.up, currentBarrelSpinSpeed);

            yield return null;
        }
    }


    IEnumerator SpinDown()
    {
        while (currentBarrelSpinSpeed > 0)
        {
            currentBarrelSpinSpeed -= spinAcceleration * Time.deltaTime;
            barrels.Rotate(Vector3.up, currentBarrelSpinSpeed);
            yield return null;
        }

    }
    override protected void OnFire()
    {

        base.OnFire();
        StopAllCoroutines();
        StartCoroutine(SpinUp());
        StartCoroutine(AutoFire());
    }

    override protected void OnStopFire()
    {
        base.OnStopFire();
        StopAllCoroutines();
        StartCoroutine(SpinDown());
    }

}
