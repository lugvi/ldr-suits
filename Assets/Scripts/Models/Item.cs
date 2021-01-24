using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item  : ScriptableObject{

public string ItemName;
public float weight;

public virtual void Equip(){}
public virtual void Use(){}
}
