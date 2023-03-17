using Assets.ToadJumping.Scripts;
using System.Collections;
using UnityEngine;

public class WarningScript : MonoBehaviour
{
    private static WarningScript instance;
    public static WarningScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<WarningScript>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

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
