﻿using Assets.ToadJumping.Scripts;
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
        /// Handle event gameObject out camera
        /// </summary>
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// Random enemy
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
            StartCoroutine(SpawnEnemyAfterSeconds(listGameObjecRate, 10, 15));
        }


        /// <summary>
        /// Spawn enemy After n Seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        private IEnumerator SpawnEnemyAfterSeconds(List<GameObjectRateVM> listObjectRate, int secondsRandomFrom, int secondsRandomTo)
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
                gameObject.AddComponent<Common>().SpawnObject(obj, positionOfEnemy);
                gameObject.AddComponent<Common>().SpawnObject(gameController.warning, positionOfWarning);
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

    }
}