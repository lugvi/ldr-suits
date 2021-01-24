using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Game/Player", order = 0)]
public class Player : ScriptableObject {
	public int healthPoints;

	public int energyPoints;

	public int fatigue;

	public PlayerAttributes attributes;

	public List<Item> inventory;

	public EquippableItem[] equpment;

}


[System.Serializable]
public struct PlayerAttributes
{
	public int Strength;
	public int Perception;
	public int Endurance;
	public int Agility;
	public int Metabolism;
}

