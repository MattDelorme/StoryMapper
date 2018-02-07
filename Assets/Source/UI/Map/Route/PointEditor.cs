using System;
using Shared;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StoryMapper
{
    public class PointEditor : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PointEditor> OnAddPointButtonClicked;
        public event Action<PointEditor> OnRemovePointButtonClicked;
        public event Action<Vector3, PointEditor> OnDrag;
        public event Action<PointEditor> OnClicked;

        public GameObject ButtonsContainer;

        private DragHandler dragHandler;

        void Start()
        {
            dragHandler = GetComponent<DragHandler>();
            dragHandler.OnDragEvent += onDragEvent;
        }

        public void SetButtonsVisible(bool isVisible)
        {
            ButtonsContainer.SetActive(isVisible);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked.Dispatch(this);
        }

        private void onDragEvent(Vector3 position)
        {
            OnDrag.Dispatch(position, this);
        }

        public void AddPointButtonClicked()
        {
            OnAddPointButtonClicked.Dispatch(this);
        }

        public void RemovePointButtonClicked()
        {
            OnRemovePointButtonClicked.Dispatch(this);
        }
    }
}
