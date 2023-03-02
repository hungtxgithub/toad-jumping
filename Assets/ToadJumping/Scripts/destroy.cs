 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    private GameObject myPlat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision){
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (4 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        Destroy(collision.gameObject);
    }
}
