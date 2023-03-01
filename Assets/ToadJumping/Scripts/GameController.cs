using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject beeEnemy;
    public GameObject batEnemy;
    public GameObject ghostEnemy;
    public GameObject skullEnemy;

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
        SpawnObjectAfterSeconds(RandomSpawnEnemy(beeEnemy, 40, batEnemy, 30, ghostEnemy, 20, skullEnemy, 10), 10);
    }

    /// <summary>
    /// Random spawn enemy
    /// </summary>
    /// <param name="obj1"></param>
    /// <param name="rateObj1"></param>
    /// <param name="obj2"></param>
    /// <param name="rateObj2"></param>
    /// <param name="obj3"></param>
    /// <param name="rateObj3"></param>
    /// <param name="obj4"></param>
    /// <param name="rateObj4"></param>
    /// <returns></returns>
    public GameObject RandomSpawnEnemy(GameObject obj1, int rateObj1, GameObject obj2, int rateObj2, GameObject obj3, int rateObj3, GameObject obj4, int rateObj4)
    {
        var listGameObject = new List<GameObject>();
        for (int i = 0; i < rateObj1; i++)
        {
            listGameObject.Add(obj1);
        }
        for (int i = 0; i < rateObj2; i++)
        {
            listGameObject.Add(obj2);
        }
        for (int i = 0; i < rateObj3; i++)
        {
            listGameObject.Add(obj3);
        }
        for (int i = 0; i < rateObj4; i++)
        {
            listGameObject.Add(obj4);
        }

        int index = Random.Range(0, listGameObject.Count);

        return listGameObject[index];
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


    /// <summary>
    /// Spawn object After n Seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    private IEnumerator SpawnObjectAfterSeconds(GameObject obj, float seconds)
    {
        while (true)
        {
            Vector2 positionOfEnemy = GetPositionRandomOfEnemy(obj, 10);
            SpawnObject(obj, positionOfEnemy);
            yield return new WaitForSeconds(seconds);
        }
    }

    /// <summary>
    /// Get position random of enemy
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="seconds"></param>
    /// <returns></returns>
    private Vector2 GetPositionRandomOfEnemy(GameObject obj, float seconds)
    {
        var listVector2 = new List<Vector2>();
        listVector2.Add(new Vector2(-2, 6));
        listVector2.Add(new Vector2(0, 6));
        listVector2.Add(new Vector2(2, 6));

        int index = Random.Range(0,3);

        return listVector2[index];
    }
}
