using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region singleton
    public static UIManager instance;
    private void Awake() { instance = this; }
    #endregion


    public GameObject InteractionInfoDisplay;

    public TMP_Text InteractableInfo;

    public UIItemController inventoryItemPrefab;

    public Transform inventoryItemContainer;

    public GameObject inventoryUi;

    PlayerManager pm;



    private void Start()
    {
        pm = PlayerManager.instance;
    }


    public void DisplayInteractionInfo(IInteractable obj)
    {
        InteractionInfoDisplay.SetActive(true);
        InteractableInfo.text = obj.objName;
    }

    public void ClearInteractionInfo()
    {
        InteractionInfoDisplay.SetActive(false);
    }

    public void OpenInventory()
    {
        if (inventoryUi.activeInHierarchy)
        {
            inventoryUi.SetActive(false);
        }

        else
        {
            ExtensionMethods.ClearChildren(inventoryItemContainer);
            inventoryUi.SetActive(true);
            foreach (Item i in pm.player.inventory)
            {
                UIItemController item = Instantiate(inventoryItemPrefab, inventoryItemContainer);
                item.itemName.text = i.ItemName;
                if (i.GetType() == typeof(EquippableItem))
                    item.equipButton.onClick.AddListener(() => i.Equip());
                if (i.GetType() == typeof(ConsumableItem))
                {
                    item.useButton.onClick.AddListener(() =>
                    {
                        pm.UseItem((ConsumableItem)i);
                        Destroy(item.gameObject);
                    });
                }

                item.infoButton.onClick.AddListener(() => Debug.Log("this is " + i.ItemName));
            }
        }
    }


}
