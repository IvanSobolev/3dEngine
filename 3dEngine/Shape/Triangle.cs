using _3dEngine.AbstractClass;
using _3dEngine.Implementation;
using _3dEngine.Interfaces.modifier;

namespace _3dEngine.Shape;

public class Triangle(Vector3[] vertex, Vector3 normal, Vector3 position = default, Vector3 localRotation = default) : GameObject (position, localRotation), IDisplays
{
    private readonly Vector3[] _vertex = vertex;
    private Vector3 _normal = normal;

    public Triangle(Vector3[] vertex) : this(vertex, default)
    {
        Vector3 E1 = _vertex[1] - _vertex[0];
        Vector3 E2 = _vertex[2] - _vertex[0];
        _normal = -Vector3.Cross(E1, E2).Norm();
    }

    public RenderData GetRenderData(Ray ray)
    {
        var v0 = (_vertex[0].Rotate(LocalRotate) + Position).Rotate(GlobalRotate);
        var v1 = (_vertex[1].Rotate(LocalRotate) + Position).Rotate(GlobalRotate);
        var v2 = (_vertex[2].Rotate(LocalRotate) + Position).Rotate(GlobalRotate);
        
        Vector3 E1 = v1 - v0;
        Vector3 E2 = v2 - v0;
        Vector3 P = Vector3.Cross(ray.RayDirection, E2);
        float det = E1 * P;
        if (Math.Abs(det) < 1e-6) return RenderData.NoRender;
        float invDet = 1.0f / det;
        Vector3 T = ray.RayStart - v0;
        float u = T * P * invDet;
        if(u < 0 || u > 1) return RenderData.NoRender;
        Vector3 Q = Vector3.Cross(T, E1);
        float v = ray.RayDirection * Q * invDet;
        if(v < 0 || u + v > 1) return RenderData.NoRender;
        float intersection = E2 * Q * invDet;
        if(intersection < 0) return RenderData.NoRender;
        
        var normal = _normal.Rotate(LocalRotate).Rotate(GlobalRotate).Norm();
        var intersectionPoint = ray.GetIntersectionPoint(intersection);
        
        return new RenderData(intersection, normal, intersectionPoint);
    }
}