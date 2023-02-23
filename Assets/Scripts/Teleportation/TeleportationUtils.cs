using UnityEngine;

namespace Teleportation
{
    public static class TeleportationUtils
    {
        public static Vector3 FurthestPoint(Vector3[] points, float maxRadius)
        {
            // search params
            float dAngle = 10f;
            float dRadius = .1f;
            //
            float maxDistance = 0f;
            Vector3 maxPoint = Vector3.zero;
            for (float angle = 0; angle < 360; angle += dAngle)
            {
                for (float relativeRadius = 0; relativeRadius < 1f; relativeRadius += dRadius)
                {
                    float radius = maxRadius * relativeRadius;
                    float radianAngle = Mathf.Deg2Rad * angle;
                    float cos = Mathf.Cos(radianAngle);
                    float sin = Mathf.Sin(radianAngle);
                    Vector3 point = new Vector3(cos, 0f, sin) * radius;
                    float distance = OverallDistance(points, point);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        maxPoint = point;
                    }
                }
            }

            return maxPoint;
        }

        private static float OverallDistance(Vector3[] points, Vector3 point)
        {
            float overalllDistance = 0f;
            foreach (var p in points)
            {
                overalllDistance += Vector3.Distance(p, point);
            }

            return overalllDistance;
        }
    }
}