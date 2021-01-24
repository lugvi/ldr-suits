using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TerrainController : MonoBehaviour, IHittable
{
    public ParticleSystem hitParticle;
    public Terrain terrain;
    public TerrainCollider terrainCollider;

    public TerrainData terrainData;

    public ParticleSystem[] particles;

    public List<float> textureValues;

    public void OnHit(RaycastHit hit, float damage = 0)
    {
        SpawnParticle(hit);
    }

    void SetTextureValues(Vector2Int hitpos)
    {
        float[,,] alphaMaps = terrain.terrainData.GetAlphamaps(hitpos.x, hitpos.y, 1, 1);
        textureValues[0] = alphaMaps[0, 0, 0];
        textureValues[1] = alphaMaps[0, 0, 1];
        textureValues[2] = alphaMaps[0, 0, 2];
        textureValues[3] = alphaMaps[0, 0, 3];
        textureValues[4] = alphaMaps[0, 0, 4];
        textureValues[5] = alphaMaps[0, 0, 5];
        //index of particle to instantiate
        // textureValues.IndexOf(textureValues.Max());

    }


    void SpawnParticle(RaycastHit hit)
    {
        Instantiate(particles[0], hit.point, Quaternion.LookRotation(hit.normal));
    }
    Vector2Int GetHitPosition(Vector3 hitPoint)
    {
        Vector3 terrainPosition = hitPoint - terrain.transform.position;

        Vector3 mapPosition = new Vector3
        (terrainPosition.x / terrain.terrainData.size.x, 0,
        terrainPosition.z / terrain.terrainData.size.z);

        float xCoord = mapPosition.x * terrain.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * terrain.terrainData.alphamapHeight;

        return new Vector2Int((int)xCoord, (int)zCoord);
    }


}
