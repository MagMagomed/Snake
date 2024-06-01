using Assets.Scripts.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MapEditor
{
    /// <summary>
    /// Основные данные точки
    /// </summary>
    [Serializable]
    public class PointData
    {
        /// <summary>
        /// Положение за которое отвечает точка (не хранит в себе положение самой точки)
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// Состояние за которое отвечает точка
        /// </summary>
        public BrushState CurrentState;
    }
}
