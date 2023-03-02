using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItemEffect : MonoBehaviour, IEffectItem
{
    public void Effect(GameObject player)
    {
        print("+ 1HP");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            Destroy(gameObject);
            Effect(collision.gameObject);
        }
    }

}
