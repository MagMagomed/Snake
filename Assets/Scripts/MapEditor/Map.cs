using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
    [CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/MapEditor", order = 1)]
    public class Map : ScriptableObject
    {
        public string Name => Guid.NewGuid().ToString();
        public BackGroundData BackGroundData { get; set; }
        public List<PointData> PointData { get; set; }
    }
}
