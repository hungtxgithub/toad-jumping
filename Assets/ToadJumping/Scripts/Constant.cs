using Assets.ToadJumping.ViewModel;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ToadJumping.Scripts
{
    public class Constant
    {
        public static readonly List<Vector2> LIST_POSITION_ENEMY = new() {
            new Vector2() { x = -2, y = 8 },
            new Vector2() { x = 2, y = 8 },
            new Vector2() { x = 2, y = 8 }
        };

        public static readonly List<Vector2> LIST_POSITION_WARNING = new() {
            new Vector2() { x = -1.9f, y = 4.4f},
            new Vector2() { x = 0, y = 4.4f },
            new Vector2() { x = 1.9f, y = 4.4f }
        };

        public const float PositionYWarning = 4f;
    }


}
