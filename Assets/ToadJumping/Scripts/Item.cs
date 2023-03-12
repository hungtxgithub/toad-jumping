using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Item : MonoBehaviour, IEffectItem
{
    public virtual void Effect(GameObject player)
    {
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("MainCharacter"))
		{
			Destroy(gameObject);
			Effect(collision.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag.Equals("MainCharacter"))
		{
			Destroy(gameObject);
			Effect(collision.gameObject);
		}
	}
}
