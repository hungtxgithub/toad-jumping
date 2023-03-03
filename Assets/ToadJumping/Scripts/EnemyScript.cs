using Assets.ToadJumping.Scripts;
using Assets.ToadJumping.ViewModel;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.ToadJumping.Scripts
{
    public class EnemyScript : MonoBehaviour
    {

        /// <summary>
        /// Handle click button
        /// </summary>
        public void RandomEnemy()
        {
            GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();

            List<GameObjectRateVM> listGameObjecRate = new() {
                new GameObjectRateVM(){GameObject = gameController.batEnemy, Rate = 4},
                new GameObjectRateVM(){GameObject = gameController.beeEnemy, Rate = 3},
                new GameObjectRateVM(){GameObject = gameController.ghostEnemy, Rate = 2},
                new GameObjectRateVM(){GameObject = gameController.skullEnemy, Rate = 1}
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
            GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
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
                Vector2 positionOfWarning = new() { x = positionOfEnemy.x, y = Constant.PositionYWarning };
                SpawnObject(obj, positionOfEnemy);
                SpawnObject(gameController.warning, positionOfWarning);
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
}
