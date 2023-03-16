using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : Item
{
    public override void Effect(GameObject player)
    {
        InventoryController.CoinAmount++;
    }
}