using UnityEngine;

namespace StoryMapper
{
    public class RouteView : MonoBehaviour
    {
        public GameObject RouteLineRendererPrefab;

//        private IRoute route;

        private LineRenderer lineRenderer;

        public void SetRoute(IMapRoute mapRoute)
        {
//            this.route = route;
            if (lineRenderer == null)
            {
                GameObject routeLineRenderer = Object.Instantiate(RouteLineRendererPrefab);
                lineRenderer = routeLineRenderer.GetComponent<LineRenderer>();
            }
            
            lineRenderer.positionCount = mapRoute.Points.Count;
            lineRenderer.SetPositions(mapRoute.Points.ToArray());
        }
    }
}
