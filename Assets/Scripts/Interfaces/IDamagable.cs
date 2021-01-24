using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable: IHittable
{
    void OnDamageTaken(float damage);

    void OnDeath();


}
