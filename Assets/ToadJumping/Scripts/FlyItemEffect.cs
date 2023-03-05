using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyItemEffect : Item
{
    Timer timer;
    public override void Effect(GameObject player)
    {
		timer.Run();
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
}
