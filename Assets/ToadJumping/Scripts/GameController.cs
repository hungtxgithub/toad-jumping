using Assets.ToadJumping.Scripts;
using Assets.ToadJumping.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject batEnemy;
    public GameObject beeEnemy;
    public GameObject ghostEnemy;
    public GameObject skullEnemy;
    public GameObject warning;

    public GameObject title;
    public GameObject character;
    public GameObject platform;
    public GameObject goBtnWrap;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Handle click button
    /// </summary>
    public void GoBtnClick()
    {
        title.SetActive(false);
        character.SetActive(false);
        platform.SetActive(false);
        goBtnWrap.SetActive(false);

        List<GameObjectRateVM> listGameObjecRate = new() {
            new GameObjectRateVM(){GameObject = batEnemy, Rate = 4},
            new GameObjectRateVM(){GameObject = beeEnemy, Rate = 3},
            new GameObjectRateVM(){GameObject = ghostEnemy, Rate = 2},
            new GameObjectRateVM(){GameObject = skullEnemy, Rate = 1},
        };
        StartCoroutine(SpawnObjectAfterSeconds(listGameObjecRate, 10, 15));
    }

   
    /// <summary>
    /// Spawn object After n Seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    private IEnumerator SpawnObjectAfterSeconds(List<GameObjectRateVM> listObjectRate, int secondsRandomFrom, int secondsRandomTo)
    {

        while (true)
        {
            List<GameObject> listGameObject = new();

            foreach (var item1 in listObjectRate)
            {
                for (int i = 0; i < item1.Rate; i++)
                {
                    listGameObject.Add(item1.GameObject);
                }
            }

            int index = Random.Range(0, listGameObject.Count);

            GameObject obj = listGameObject[index];

            Vector2 positionOfEnemy = GetPositionRandomOfEnemy();
            Vector2 positionOfWarning = new() { x = positionOfEnemy.x, y = Constant.PositionYWarning};
            SpawnObject(obj, positionOfEnemy);
            SpawnObject(warning, positionOfWarning);
            var timeRandom = Random.Range(secondsRandomFrom, secondsRandomTo + 1);
            yield return new WaitForSeconds(timeRandom);
        }
    }


    /// <summary>
    /// Get position random of enemy
    /// </summary>
    /// <returns></returns>
    private Vector2 GetPositionRandomOfEnemy()
    {
        List<Vector2> listVector2 = Constant.LIST_POSITION_ENEMY;
        int index = Random.Range(0, 3);
        return listVector2[index];
    }


    /// <summary>
    /// Spawn object with Position x, y
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="radius"></param>
    public void SpawnObject(GameObject obj, Vector2 vector2)
    {
        Instantiate(obj, vector2, Quaternion.identity);
    }

}
