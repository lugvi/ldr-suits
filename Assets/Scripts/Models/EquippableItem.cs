using UnityEngine;

[CreateAssetMenu(fileName = "Equippable Item", menuName = "Game/Equippable Item", order = 0)]


public class EquippableItem : Item
{

    public EquipmentSlot slot;

    public float damage;
    public float durability;
    public PlayerAttributes attributeModifiers;


    public override void Equip()
    {
        PlayerManager.instance.EquipItem(this); 
    }



}

public enum EquipmentSlot
{
    Head, Body, Hands, Legs,count
}