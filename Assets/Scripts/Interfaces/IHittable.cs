
using UnityEngine;
public interface IHittable
{

    void OnHit(RaycastHit hit,float damage = 0);
}