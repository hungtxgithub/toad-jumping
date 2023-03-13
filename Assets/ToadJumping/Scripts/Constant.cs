using Assets.ToadJumping.ViewModel;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ToadJumping.Scripts
{
    public class Constant
    {
        public static readonly List<Vector2> LIST_POSITION_ENEMY = new() {
            new Vector2() { x = -1.87f, y = 6 },
            new Vector2() { x = 0, y = 6 },
            new Vector2() { x = 1.87f, y = 6 }
        };

        public static readonly List<Vector2> LIST_POSITION_WARNING = new() {
            new Vector2() { x = -1.9f, y = 4.4f},
            new Vector2() { x = 0, y = 4.4f },
            new Vector2() { x = 1.9f, y = 4.4f }
        };

        public const int RowOfPlatform = 8;

        public const float PositionYWarning = 4f;
        public static readonly List<Vector2> LIST_POSITION_PLATFORM = new()
        {
            new Vector2() { x = -2f, y =-2 },
            new Vector2() { x = 0f, y =-2 },
            new Vector2() { x = 2f, y =-2 },
            new Vector2() { x = -2f, y = -0.5f },
            new Vector2() { x = 0f, y = -0.5f },
            new Vector2() { x = 2f, y = -0.5f },
            new Vector2() { x = -2f, y = 1f },
            new Vector2() { x = 0f, y = 1f },
            new Vector2() { x = 2f, y = 1f },
            new Vector2() { x = -2f, y = 2.5f },
            new Vector2() { x = 0f, y = 2.5f },
            new Vector2() { x = 2f, y = 2.5f },
            new Vector2() { x = -2f, y = 4f },
            new Vector2() { x = 0f, y = 4f },
            new Vector2() { x = 2f, y = 4f },
            new Vector2() { x = -2f, y = 5.5f },
            new Vector2() { x = 0f, y = 5.5f },
            new Vector2() { x = 2f, y = 5.5f },
             new Vector2() { x = -2f, y =7 },
            new Vector2() { x = 0f, y = 7 },
            new Vector2() { x = 2f, y = 7 }
        };

          public static readonly List<Vector2> LIST_POSITION_PLATFORM_START = new()
        {
            new Vector2() { x = -2f, y =-2 },
            new Vector2() { x = 0f, y = -0.5f },
            new Vector2() { x = 0f, y = 1f },
            new Vector2() { x = 2f, y = 1f },
            new Vector2() { x = -2f, y = 2.5f },
            new Vector2() { x = -2f, y = 4f },
            new Vector2() { x = 0f, y = 4f },
            new Vector2() { x = 2f, y = 5.5f },
            new Vector2() { x = 0f, y = 7 },
            new Vector2() { x = 2f, y = 7 }
        };
    }


}
