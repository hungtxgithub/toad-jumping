using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyItemEffect : MonoBehaviour, IEffectItem
{
    Timer timer;
    public void Effect(GameObject player)
    {
        var rd2D = player.GetComponent<Rigidbody2D>();
        if (rd2D != null)
        {
            rd2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer();
        timer.Duration = 3;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.Finished)
        {
            var player = GameObject.FindWithTag("PlayerTag");
            var rd2D = player.GetComponent<Rigidbody2D>();
            rd2D.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("PlayerTag"))
        {
            Effect(collision.gameObject);
        }
    }
}
