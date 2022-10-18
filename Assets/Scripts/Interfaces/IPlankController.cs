using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public interface IPlankController
    {
        public void SetCurrentPlank(GameObject plank);
        public void AddCanvasToPlank();
        public void TranslatePlank(PointerEventData eventData);
        public void DestroyCanvas();
    }
}