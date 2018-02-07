using UnityEngine;
using UnityEngine.UI;

namespace StoryMapper
{
    public class LocationMarker : MonoBehaviour
    {
        [SerializeField] Text nameText = null;
        
        private IMapLocation mapLocation;
        public IMapLocation MapLocation
        {
            get
            {
                return mapLocation;
            }
            set
            {
                mapLocation = value;
                nameText.text = mapLocation.Location.Name;
                Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, mapLocation.Position);
                rectTransform.anchoredPosition = screenPoint;
            }
        }

        private RectTransform rectTransform;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            if (mapLocation != null)
            {
                Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, mapLocation.Position);
                rectTransform.anchoredPosition = screenPoint;
            }
        }
    }
}
