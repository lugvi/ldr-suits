using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform directionalLight;

    public float planetSpinSpeed;

    private void LateUpdate()
    {
        directionalLight.Rotate(Vector3.right, planetSpinSpeed * Time.deltaTime);
    }
}
