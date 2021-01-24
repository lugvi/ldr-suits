using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton
    public static PlayerManager instance;
    private void Awake() {instance = this;}
    #endregion

    public Player player;




    public void AddToInventory(Item item)
    {
        player.inventory.Add(item);
    }

    public void EquipItem(EquippableItem item)
    {
       player.equpment[(int)item.slot] = item;
    }

    public void UseItem(ConsumableItem item)
    {
        player.inventory.Remove(item);
        Debug.Log("Ate " + item.ItemName);
    }
}
