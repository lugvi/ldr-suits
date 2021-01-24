using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Game/Consumable Item", order = 0)]
public class ConsumableItem : Item {


	public override void Use()
	{
		Debug.Log("Ate " + this.ItemName);
	}
}
