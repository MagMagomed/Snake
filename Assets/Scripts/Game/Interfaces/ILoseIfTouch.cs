using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Interfaces
{
    internal interface ILoseIfTouch
    {
        public bool ComparePosition(Vector3 position1, Vector3 position2);
        public void Lose();
    }
}
