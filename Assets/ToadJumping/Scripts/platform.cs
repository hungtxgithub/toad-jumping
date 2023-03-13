using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ToadJumping.Scripts;
using System.Linq;
using Assets.ToadJumping.ViewModel;

public class Platform : MonoBehaviour
{
    private static Platform instance;
    public static Platform Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<Platform>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 1 * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        //Common.Instance.SpawnObject(GameController.Instance.mainPlatform1, new Vector2(0, 6.25f));
        Destroy(gameObject);
    }


    public void RandomStartPlatform(List<PlatformObjectVM> listPlatform)
    {
        float posY = -4;
        var listLastPlatform = new List<PlatformOutVM>();
        for (int i = 0; i < Constant.RowOfPlatform; i++)
        {
            int numberItemInRow = Random.Range(1, 4);
            List<GameObject> gameObjects =
                listPlatform.Where(x => x.IsNormal == true).Select(x => x.GameObject).ToList();

            for (int j = 0; j < numberItemInRow - 1; j++)
                gameObjects.Add(listPlatform[Random.Range(0, listPlatform.Count)].GameObject);

            gameObjects = gameObjects.OrderBy(x => System.Guid.NewGuid()).ToList();

            float posX = -2;
            for (int j = 0; j < numberItemInRow; j++)
            {
                Common.Instance.SpawnObject(gameObjects[j], new Vector2(posX, posY));
                posX += 2;
            }
            posY += 1.25f;
        }
    }

}
