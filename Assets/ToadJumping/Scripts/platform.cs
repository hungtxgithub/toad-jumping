using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ToadJumping.Scripts;
public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformPrefab;
    private GameObject myPlat;
    private GameObject lastPlatform;

    private Item item;
    // float lastXPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 1 * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        if (item != null) Destroy(item);

        int radPlatform = 0;
        platformPrefab.GetComponent<BoxCollider2D>().enabled = true;
        platformPrefab.GetComponent<Platform>().enabled = true;
        platformPrefab.GetComponent<PlatformEffector2D>().enabled = true;
        platformPrefab.GetComponent<Animator>().enabled = true;

        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();

        float lastXPositionPlatform = gameController.lastXPosition;
        Debug.Log("x last position: " + lastXPositionPlatform);
        switch (lastXPositionPlatform)
        {
            case -2f:
                 radPlatform = Random.Range(1, 3);
                Debug.Log("radPlatform: " + radPlatform);
                if (radPlatform == 1)
                {
                    new Common().SpawnObject(platformPrefab, new Vector2(-2f, 5.5f));
                    gameController.lastXPosition = -2f;
                    Debug.Log("random dem -2 ");
                    // Debug.Log("set value  lastXPosition " + lastXPosition);
                }
                else if (radPlatform == 2)
                {
                    new Common().SpawnObject(platformPrefab, new Vector2(0, 5.5f));
                    Debug.Log("random dem 0 ");

                    gameController.lastXPosition = 0;
                    // Debug.Log("set value  lastXPosition " + lastXPosition);

                }
                break;
            case 0:
                 radPlatform = Random.Range(1, 4);
                Debug.Log("radPlatform: " + radPlatform);
                if (radPlatform == 1)
                {
                    new Common().SpawnObject(platformPrefab, new Vector2(-2f, 5.5f));
                    gameController.lastXPosition = -2f;
                    Debug.Log("random dem -2 ");
                    // Debug.Log("set value  lastXPosition " + lastXPosition);

                }
                else if (radPlatform == 2)
                {
                    new Common().SpawnObject(platformPrefab, new Vector2(0, 5.5f));
                    gameController.lastXPosition = 0;
                    Debug.Log("random dem 0 ");
                    // Debug.Log("set value  lastXPosition " + lastXPosition);


                }
                else if (radPlatform == 3)
                {
                    new Common().SpawnObject(platformPrefab, new Vector2(2f, 5.5f));
                    gameController.lastXPosition = 2f;
                    Debug.Log("random dem 2 ");
                    // Debug.Log("set value  lastXPosition " + lastXPosition);
                }
                break;
            case 2f:
                 radPlatform = Random.Range(2, 4);
                Debug.Log("radPlatform: " + radPlatform);
                if (radPlatform == 3)
                {
                    new Common().SpawnObject(platformPrefab, new Vector2(2f, 5.5f));
                    gameController.lastXPosition = 2f;
                    Debug.Log("random dem 2 ");
                    // Debug.Log("set value  lastXPosition " + lastXPosition);
                }
                else if (radPlatform == 2)
                {
                    new Common().SpawnObject(platformPrefab, new Vector2(0, 5.5f));
                    gameController.lastXPosition = 0;
                    Debug.Log("random dem 0 ");
                    // Debug.Log("set value  lastXPosition " + lastXPosition);
                }
                break;
            default:
                new Common().SpawnObject(platformPrefab, new Vector2(0, 5.5f));
                gameController.lastXPosition = 0;
                break;
                Debug.Log("set value  lastXPosition " + gameController.lastXPosition);

        }
        // if (radPlatform == 1)
        // {
        //     new Common().SpawnObject(platformPrefab, new Vector2(-2f, 5.5f));
        // }
        // if (radPlatform == 2)
        // {
        //     new Common().SpawnObject(platformPrefab, new Vector2(0, 5.5f));
        // }
        // if (radPlatform == 3)

        // {
        //     new Common().SpawnObject(platformPrefab, new Vector2(2f, 5.5f));
        // }

    }


    public void RandomStartPlatform(GameObject mainPlatform)
    {
        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
        List<int> availblePositions = new List<int>();
        // foreach (Vector2 v2 in Constant.LIST_POSITION_PLATFORM_START)
        // {
        //     lastPlatform = new Common().SpawnObjectHasReturn(mainPlatform, v2);
        //    gameController.lastXPosition = v2.x;
        // // System.Console.WriteLine("x last position: " + lastPlatform);

        // }

        for (int i = 0; i < Constant.LIST_POSITION_PLATFORM.Count; i += 3)
        {
            lastPlatform = new Common().SpawnObjectHasReturn(mainPlatform, Constant.LIST_POSITION_PLATFORM[i + 1]);
            gameController.lastXPosition = Constant.LIST_POSITION_PLATFORM[i + 1].x;
        }
        // //      radPlatform = Random.Range(1, 3);
        // //     int firstPlat = 0;
        // //     int firstPosition = -1;
        // //     for (int j = 0; j < radPlatform; j++)
        // //     {
        // //         if (firstPlat == 0)
        // //         {
        // //             switch (radPlatform)
        // //             {
        // //                 case 0:
        // //                     new Common().SpawnObject(mainPlatform, Constant.LIST_POSITION_PLATFORM[i]);
        // //                     availblePositions.Add(1);
        // //                     availblePositions.Add(2);
        // //                     firstPosition = 0;
        // //                     break;
        // //                 case 2:
        // //                     new Common().SpawnObject(mainPlatform, Constant.LIST_POSITION_PLATFORM[i + 1]);
        // //                     availblePositions.Add(1);
        // //                     availblePositions.Add(2);
        // //                     availblePositions.Add(3);
        // //                     firstPosition = 1;
        // //                     break;
        // //                 case 3:
        // //                     new Common().SpawnObject(mainPlatform, Constant.LIST_POSITION_PLATFORM[i + 2]);
        // //                     availblePositions.Add(2);
        // //                     availblePositions.Add(3);
        // //                     firstPosition = 2;
        // //                     break;
        // //             }
        // //             firstPlat++;
        // //         }
        // //         else
        // //         {
        // //             if (Random.Range(1, 10) > 5)
        // //             {

        // //                 new Common().SpawnObject(mainPlatform, Constant.LIST_POSITION_PLATFORM[i + j]);
        // //             }
        // //         }
        // //     }

        // }

    }
}
