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
 

    }


    public void RandomStartPlatform(GameObject mainPlatform)
    {
        List<int> availblePositions = new List<int>();
        foreach (Vector2 v2 in Constant.LIST_POSITION_PLATFORM_START)
        {
            lastPlatform = new Common().SpawnObjectHasReturn(mainPlatform, v2);
        }

        // for (int i = 0; i < Constant.LIST_POSITION_PLATFORM.Count; i += 3)
        // {
        //     new Common().SpawnObject(mainPlatform, Constant.LIST_POSITION_PLATFORM[i+1]);

        // //     int radPlatform = Random.Range(1, 3);
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
