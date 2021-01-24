using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableObject : MonoBehaviour, IInteractable
{



    public DropTable dropTable;
    // public List<Item> RequiredItems;

    public string objectName;
    public string objName { get => objectName; }

    public bool Lootable;

    public void Interact()
    {
    }

}
