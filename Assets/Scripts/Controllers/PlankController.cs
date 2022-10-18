using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class PlankController : IPlankController
    {
        private Canvas _canvas;
        private PlankView _plankView;
        private GameObject _currentPlank;
        private RectTransform _rectTransform;

        public void SetCurrentPlank(GameObject plank)
        {
            _currentPlank = plank;
            _plankView = _currentPlank.GetComponent<PlankView>();
        }
        
        public void AddCanvasToPlank()
        {
            _canvas = _currentPlank.AddComponent<Canvas>();
            _canvas.overrideSorting = true;
            _canvas.sortingOrder = 20;
        }

        public void TranslatePlank(PointerEventData eventData)
        {
            _rectTransform = _plankView.GetRectTransform();
            _rectTransform.anchoredPosition += eventData.delta; 
        }

        public void DestroyCanvas()
        {
            Object.Destroy(_canvas);
        }
        
    }
}