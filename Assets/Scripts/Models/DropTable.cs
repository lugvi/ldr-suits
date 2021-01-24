using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DropTable", menuName = "Game/DropTable", order = 0)]
public class DropTable : ScriptableObject
{


    public List<WeightedItem> items;

    public int dropChanceSum;
    private void OnEnable()
    {
		dropChanceSum = 0;
        foreach (var item in items)
        {
            dropChanceSum += item.dropChance;
        }
    }
    public Item GetItem()
    {

        int rnd = Random.Range(0, dropChanceSum);

        foreach (var item in items)
        {
            if (rnd < item.dropChance)
                return item.item;
            else
            {
                rnd -= item.dropChance;
            }
        }
        return null;

    }

}

[System.Serializable]
public class WeightedItem
{
    public int dropChance;
    public Item item;
}