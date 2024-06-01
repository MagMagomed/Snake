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
    /// Данные по кисти, которой мы рисуем карту
    /// </summary>
    [Serializable]
    public class BrushData
    {
        [SerializeField] public Image Image;
        [SerializeField] public BrushState BrushState;
    }
}
