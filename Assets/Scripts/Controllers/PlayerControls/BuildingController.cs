using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public GameObject buildingPrefab;

    GameObject buildingPrefabInstance;

    public InputManager input;
    private void OnEnable()
    {
        input = InputManager.instance;
        input.gc.Gameplay.Fire.performed += (_) => PlaceBuilding();

    }
    private void OnDisable()
    {

        input.gc.Gameplay.Fire.performed -= (_) => PlaceBuilding();
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.ViewportToWorldPoint(Vector3.one / 2), Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, 60f))
        {
            if (buildingPrefabInstance == null)
            {
                buildingPrefabInstance = Instantiate(buildingPrefab, hit.point, Quaternion.identity);
            }
            buildingPrefabInstance.transform.position = hit.point;
            buildingPrefabInstance.transform.up = hit.normal;
            if (Vector3.Angle(buildingPrefabInstance.transform.up, Vector3.up) > 5)
            {
                var renderers = buildingPrefabInstance.GetComponentsInChildren<MeshRenderer>();
                renderers[0].material.color = Color.red;
                renderers[1].material.color = Color.red;
            }
            else
            {
                var renderers = buildingPrefabInstance.GetComponentsInChildren<MeshRenderer>();
                renderers[0].material.color = Color.green;
                renderers[1].material.color = Color.green;
            }
        }
    }

    void PlaceBuilding()
    {
        buildingPrefabInstance = null;
    }



}
