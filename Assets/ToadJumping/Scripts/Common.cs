﻿using Assets.ToadJumping.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ToadJumping.Scripts
{
    public class Common : MonoBehaviour
    {
        private static Common instance;
        public static Common Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<Common>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// Spawn object with Position x, y
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public void SpawnObject(GameObject obj, Vector2 vector2 = new Vector2())
        {
            Instantiate(obj, vector2, Quaternion.identity);
        }


        public GameObject SpawnObjectHasReturn(GameObject obj, Vector2 vector2 = new Vector2())
        {
            GameObject newObj = Instantiate(obj, vector2, Quaternion.identity);
            return newObj;
        }
        /// <summary>
        /// Destroy object After n Seconds
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public IEnumerator DestroyObjectAfterSeconds(GameObject obj, float seconds)
        {
            int count = 0;
            while (count == 0)
            {
                var a = new WaitForSeconds(seconds);
                yield return new WaitForSeconds(seconds);
                Destroy(obj);
                count++;
            }
        }

        public void DestroyWithTag(string destroyTag)
        {
            GameObject[] destroyObject;
            destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
            foreach (GameObject oneObject in destroyObject)
                Destroy(oneObject);
        }
    }
}
