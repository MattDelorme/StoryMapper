using UnityEngine;
using UnityEngine.EventSystems;

namespace StoryMapper
{
    public class DragPanController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform DragObject;
        public float Speed;

        private Vector3 startPosition;
        private Vector3 startMouseWorldPosition;
        private RectTransform canvasTransform;
        private Vector3 target;

        void Start()
        {
            canvasTransform = GetComponentInParent<Canvas>().transform as RectTransform;
            target = DragObject.position;
        }

        void LateUpdate()
        {
            DragObject.position = target;
//            float maxDistanceDelta = Speed * Time.deltaTime;
//            DragObject.position = Vector3.MoveTowards(DragObject.position, target, maxDistanceDelta);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = DragObject.position;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasTransform, Input.mousePosition, Camera.main, out startMouseWorldPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 mouseWorldPosition;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasTransform, Input.mousePosition, Camera.main, out mouseWorldPosition);

            var delta = startMouseWorldPosition - mouseWorldPosition;
            target = startPosition + delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}
