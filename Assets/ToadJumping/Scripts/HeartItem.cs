using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : Item
{
    public override void Effect(GameObject player)
    {
        print("+ 1HP");
    }
}
