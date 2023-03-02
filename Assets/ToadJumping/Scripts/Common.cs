using Assets.ToadJumping.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ToadJumping.Scripts
{
    public class Common: MonoBehaviour
    {
        
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
