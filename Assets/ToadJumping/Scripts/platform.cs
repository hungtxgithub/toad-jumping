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
        platformPrefab.GetComponent<BoxCollider2D>().enabled = true;
        platformPrefab.GetComponent<Platform>().enabled = true;
        platformPrefab.GetComponent<PlatformEffector2D>().enabled = true;
        platformPrefab.GetComponent<Animator>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        // if (gameObject.transform.position.y <= -5)
        // {
        //   Destroy(gameObject);
        //myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-2f, 2f), 10 + Random.Range(0.5f, 0.8f)), Quaternion.identity);

        // }
        transform.Translate(Vector3.down * 1 * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);

        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-2f, 2f), 10 + Random.Range(0.5f, 0.8f)), Quaternion.identity);

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
