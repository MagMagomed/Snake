using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    internal class InputViewController : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private Canvas _canvas;
        private void Start ()
        {
            _canvas.worldCamera = Camera.main;
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.sortingLayerID = SortingLayer.GetLayerValueFromName("Front");
        }

    }
}
