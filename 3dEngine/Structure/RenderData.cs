namespace _3dEngine;

public struct RenderData(float intersection = -1, Vector3 normal = default, Vector3 intersectionPoint = default)
{
    public float Intersection = intersection;
    public Vector3 Normal = normal;
    public Vector3 IntersectionPoint = intersectionPoint;
    public static RenderData NoRender = new RenderData(-1, Vector3.Zero, Vector3.Zero);
}