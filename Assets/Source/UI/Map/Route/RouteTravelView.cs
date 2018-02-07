using System;
using System.Collections.Generic;
using UnityEngine;

namespace StoryMapper
{
    public class RouteTravelView : MonoBehaviour
    {
        [SerializeField] CharacterAsset characterAsset;
        [SerializeField] MapRouteAsset mapRouteAsset;

        [Range(0, 1)]
        [SerializeField] float normalized;

        private RectTransform rectTransform;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
          
            getEvents(characterAsset);
        }

        void Update()
        {
            if (mapRouteAsset != null)
            {
                SetPosition(mapRouteAsset, normalized);
            }
        }

        private void getEvents(ICharacter character)
        {
            foreach (var characterEvent in character.GetEvents())
            {
                Debug.Log(characterEvent.Name);
            }
        }

        public void SetPosition(IMapRoute mapRoute, float normalizedTravelDistance)
        {
            if (normalizedTravelDistance < 0 || normalizedTravelDistance > 1)
            {
                throw new ArgumentOutOfRangeException("normalizedTravelDistance must be between 0 and 1. Value was " + normalizedTravelDistance);
            }

            if (mapRoute.Points != null && mapRoute.Points.Count > 1)
            {
                float totalLength = 0;
                List<float> segmentLengths = new List<float>();
                for (int i = 0; i < mapRoute.Points.Count - 1; i++)
                {
                    Vector3 segmentDistance = mapRoute.Points[i + 1] - mapRoute.Points[i];
                    segmentLengths.Add(segmentDistance.magnitude);
                    totalLength += segmentDistance.magnitude;
                }

                float totalTravelDistance = totalLength * normalizedTravelDistance;

                for (int i = 0; i < segmentLengths.Count; i++)
                {
                    if (totalTravelDistance > segmentLengths[i])
                    {
                        totalTravelDistance -= segmentLengths[i];
                    }
                    else
                    {
                        float normalizedSegmentDistance = totalTravelDistance / segmentLengths[i];
                        Vector3 segmentDistance = mapRoute.Points[i + 1] - mapRoute.Points[i];
                        Vector3 position = mapRoute.Points[i] + segmentDistance * normalizedSegmentDistance;

                        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, position);
                        rectTransform.anchoredPosition = screenPoint;
                        break;
                    }
                }
            }
        }
    }
}
