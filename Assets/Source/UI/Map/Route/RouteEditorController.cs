using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StoryMapper
{
    public class RouteEditorController : MonoBehaviour
    {
        public PointEditor PointEditorPrefab;
        public PointEditor PointEditorCirclePrefab;
        public RouteView RouteView;
        public Transform PointEditorContainer;

        private IMapRoute mapRoute;
        private PointEditor endPointEditor;
        private RectTransform endPointEditorTransform;
        private RectTransform canvasTransform;
        private List<PointEditor> pointEditorsList;
        private int activeCircleIndex = -1;

        void Start()
        {
            canvasTransform = GetComponentInParent<Canvas>().transform as RectTransform;
        }

        void Update()
        {
            if (mapRoute != null && mapRoute.Points.Count > 0)
            {
                for (int i = 0; i < mapRoute.Points.Count; i++)
                {
                    Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, mapRoute.Points[i]);
                    RectTransform pointTransform;
                    if (i < mapRoute.Points.Count - 1)
                    {
                        pointTransform = pointEditorsList[i].transform as RectTransform;
                    }
                    else
                    {
                        pointTransform = endPointEditor.transform as RectTransform;
                    }
                    pointTransform.anchoredPosition = screenPoint;
                }
            }
        }

        public void CreateRoute()
        {
            mapRoute = EntityDatabase.GetEntityDatabase().CreateRoute();

            createPointEditor();

            RouteView.SetRoute(mapRoute);

            destroyPointEditorsList();
            pointEditorsList = new List<PointEditor>();
        }

        public void SaveRoute()
        {
            EntityDatabase.GetEntityDatabase().SaveRoute(mapRoute, "Test");
        }

        public void LoadRoute()
        {
            mapRoute = EntityDatabase.GetEntityDatabase().LoadRoute("Test");

            createPointEditor();

            RouteView.SetRoute(mapRoute);

            if (mapRoute.Points.Count > 0)
            {
                endPointEditorTransform.position = mapRoute.Points.Last();
            }

            destroyPointEditorsList();
            pointEditorsList = new List<PointEditor>();
            for (int i = 0; i < mapRoute.Points.Count; i++)
            {
                if (i < mapRoute.Points.Count - 1)
                {
                    addPointEditorCircle(i);
                }
            }
        }

        private void createPointEditor()
        {
            if (endPointEditor == null)
            {
                endPointEditor = Object.Instantiate(PointEditorPrefab, PointEditorContainer);
                endPointEditorTransform = endPointEditor.transform as RectTransform;
                endPointEditor.OnAddPointButtonClicked += onAddPointButtonClicked;
                endPointEditor.OnRemovePointButtonClicked += onRemovePointButtonClicked;
                endPointEditor.OnDrag += onEndDrag;
            }
        }

        private PointEditor createPointEditorCircle(int index)
        {
            PointEditor pointEditorCircle = Object.Instantiate(PointEditorCirclePrefab, PointEditorContainer.Find("CircleContainer"));
            pointEditorCircle.gameObject.name = "PointEditorCircle " + index;
            pointEditorCircle.OnAddPointButtonClicked += onCircleAddPointButtonClicked;
            pointEditorCircle.OnRemovePointButtonClicked += onCircleRemovePointButtonClicked;
            pointEditorCircle.OnDrag += onCircleDrag;
            pointEditorCircle.OnClicked += onCircleClicked;

            return pointEditorCircle;
        }

        private void addPointEditorCircle(int index)
        {
            PointEditor pointEditorCircle = createPointEditorCircle(index);

            pointEditorCircle.transform.position = mapRoute.Points[index];

            pointEditorsList.Add(pointEditorCircle);
        }

        private void insertPointEditorCircle(int index)
        {
            int insertIndex = index + 1;
            PointEditor pointEditorCircle = createPointEditorCircle(insertIndex);

            pointEditorCircle.transform.position = mapRoute.Points[index];

            pointEditorsList.Insert(insertIndex, pointEditorCircle);

            pointEditorCircle.transform.SetSiblingIndex(insertIndex);
        }

        private void destroyPointEditorsList()
        {
            if (pointEditorsList != null)
            {
                for (int i = 0; i < pointEditorsList.Count; i++)
                {
                    Destroy(pointEditorsList[i].gameObject);
                }
            }
        }

        private void onAddPointButtonClicked(PointEditor pointEditor)
        {
            if (mapRoute.Points.Count == 0)
            {
                mapRoute.Points.Add(endPointEditorTransform.position);
            }
            mapRoute.Points.Add(endPointEditorTransform.position);
            RouteView.SetRoute(mapRoute);

            addPointEditorCircle(pointEditorsList.Count);
        }

        private void onRemovePointButtonClicked(PointEditor pointEditor)
        {
            if (mapRoute.Points.Count > 0)
            {
                mapRoute.Points.Remove(mapRoute.Points.Last());
                RouteView.SetRoute(mapRoute);

                endPointEditorTransform.position = mapRoute.Points.Last();

                pointEditorsList.RemoveAt(pointEditorsList.Count - 1);
            }
        }

        private void onEndDrag(Vector3 position, PointEditor pointEditor)
        {
            if (mapRoute.Points.Count > 0)
            {
                Vector3 worldPoint;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasTransform, position, Camera.main, out worldPoint);
                mapRoute.Points[mapRoute.Points.Count - 1] = worldPoint;
                RouteView.SetRoute(mapRoute);
            }
        }

        private void onCircleClicked(PointEditor pointEditor)
        {
            int index = pointEditorsList.IndexOf(pointEditor);
            if (index != activeCircleIndex)
            {
                for (int i = 0; i < pointEditorsList.Count; i++)
                {
                    pointEditorsList[i].SetButtonsVisible(false);
                }
                pointEditorsList[index].SetButtonsVisible(true);
                activeCircleIndex = index;
            }
        }

        private void onCircleAddPointButtonClicked(PointEditor pointEditor)
        {
            int index = pointEditorsList.IndexOf(pointEditor);
            mapRoute.Points.Insert(index + 1, pointEditor.transform.position);

            insertPointEditorCircle(index);

            RouteView.SetRoute(mapRoute);
        }

        private void onCircleRemovePointButtonClicked(PointEditor pointEditor)
        {

        }

        private void onCircleDrag(Vector3 position, PointEditor pointEditor)
        {
            int index = pointEditorsList.IndexOf(pointEditor);
            Vector3 worldPoint;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasTransform, position, Camera.main, out worldPoint);
            mapRoute.Points[index] = worldPoint;
            RouteView.SetRoute(mapRoute);
        }
    }
}
