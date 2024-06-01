using Assets.Scripts.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MapEditor
{
    /// <summary>
    /// Контролирует отображение и обработку данных точки
    /// </summary>
    internal class PointController : MonoBehaviour
    {
        [SerializeField] private BrushController _brushController;
        [SerializeField] private Image _image;
        [SerializeField] private PointData _pointData;
        public void Initialize(BrushController brushController)
        {
            _pointData = new PointData();
            _brushController = brushController;
            ChangeColor();
        }
        public void OnClick()
        {
            ChangeState();
            ChangeColor();
        }
        public PointData GetPointData() { return _pointData; }
        private void ChangeState() { _pointData.CurrentState = _brushController.BrushState; }
        private void ChangeColor()
        {
            if(_pointData.CurrentState == BrushState.ObstacleElement)
            {
                _image.color = Color.blue;
            }
            if(_pointData.CurrentState == BrushState.BackgroundElement)
            {
                _image.color = Color.green;
            }
        }
    }
}
