using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyItemEffect : Item
{
    public override void Effect(GameObject player)
    {
        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.Fly();
    }
}
