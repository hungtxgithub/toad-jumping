using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointItemEffect : MonoBehaviour, IEffectItem
{

    public void Effect(GameObject player)
    {
        print("+ 1HP");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Effect(gameObject);
    }

}
