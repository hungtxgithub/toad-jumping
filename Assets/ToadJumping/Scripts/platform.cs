using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ToadJumping.Scripts;
public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformPrefab;
    private GameObject myPlat;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
            myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-2f, 2f), 4 + Random.Range(0.5f, 0.8f)), Quaternion.identity);

        }
    }
    // private void OnCollisionEnter2D(Collision2D collision) {
    //     // if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y<=0){
    //     //     collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 6f);
    //     // }


    //     if (collision.gameObject.tag == "MainCharacter")
    //     {
    //          Debug.Log("The player collided with this object.");
    //     }
    // }
}
