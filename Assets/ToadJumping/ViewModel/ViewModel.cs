using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ToadJumping.ViewModel
{
    public class GameObjectRateVM
    {
        public GameObject GameObject { get; set; }
        public int Rate { get; set; }
    }

    public class PlatformObjectVM
    {
        public GameObject GameObject { get; set; }
        public bool IsNormal { get; set; }
    }

    public class PlatformOutVM
    {
        public GameObject GameObject1 { get; set; }
        public GameObject GameObject2 { get; set; }
        public GameObject GameObject3 { get; set; }
    }

}
