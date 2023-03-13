using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : Item
{
    public override void Effect(GameObject player)
    {
        var characterController = player.GetComponent<CharacterController>();

        if (characterController != null)
        {
            characterController.AddMoreHp(1);
        }
    }
}
