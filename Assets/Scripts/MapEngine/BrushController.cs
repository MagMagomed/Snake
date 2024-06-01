using Assets.Scripts.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MapEngine
{
    /// <summary>
    /// Класс для обраотки данных и отображения кисти, которой мы будем рисовать карту
    /// </summary>
    internal class BrushController : MonoBehaviour
    {
        [SerializeField] private BrushData _brushData;
        public void Initialize()
        {
            OnChangeBrush(_brushData.BrushState);
        }
        public BrushState BrushState { get { return _brushData.BrushState; } set { _brushData.BrushState = value; OnChangeBrush(value); } }

        private void OnChangeBrush(BrushState state)
        {
            if (state == BrushState.ObstacleElement)
            {
                _brushData.Image.color = Color.blue;
            }
            else
            {
                _brushData.Image.color = Color.green;
            }
        }
    }
}
