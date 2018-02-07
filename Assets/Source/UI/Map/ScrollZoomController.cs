using Shared.Unity;
using UnityEngine;

namespace StoryMapper
{
    public class ScrollZoomController : MonoBehaviour
    {
        public enum RateType { Constant, Scaled }

        public RateType Rate;

        public AbstractCameraZoomControl CameraZoomControl;
        public float MaxZoom;
        public float MinZoom;

        private float currentZoom = 1;

        void Update()
        {
            switch (Rate)
            {
                case RateType.Scaled:
                    currentZoom += Input.GetAxis("Mouse ScrollWheel") * currentZoom;
                    break;
                default:
                    currentZoom += Input.GetAxis("Mouse ScrollWheel");
                    break;
            }
            currentZoom = Mathf.Clamp(currentZoom, MinZoom, MaxZoom);

            CameraZoomControl.SetZoom(currentZoom);
        }
    }
}
