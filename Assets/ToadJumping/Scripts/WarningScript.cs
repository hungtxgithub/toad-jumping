using Assets.ToadJumping.Scripts;
using System.Collections;
using UnityEngine;

public class WarningScript : MonoBehaviour
{
    /// <summary>
    /// Handling collision events between two passing objects
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
