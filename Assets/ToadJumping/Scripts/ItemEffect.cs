using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEffect : MonoBehaviour, IEffectItem
{
    public virtual void Effect(GameObject player)
    {
    }

    public virtual void DestroyThisItem()
    {
        // Get transform component in parent
        var transFromInParent = gameObject.transform.parent;
        // Destroy parent game object
        Destroy(transform.parent);
    }

    public virtual void OnPlayerEatItem(GameObject player)
    {
        DestroyThisItem();
        Effect(player);
    }
}
