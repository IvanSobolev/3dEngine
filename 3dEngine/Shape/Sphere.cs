using _3dEngine.AbstractClass;
using _3dEngine.Implementation;
using _3dEngine.Interfaces.modifier;

namespace _3dEngine.Shape;

public class Sphere(Vector3 position, Vector3 localRotate, float r = 1) : GameObject(position, localRotate), IDisplays
{
    public float R = r;

    public RenderData GetRenderData(Camera camera)
    {
        Vector3 ro = camera.GetRo();
        Vector3 rd = camera.GetRd();
        
        Vector3 l = (ro - Position).Rotate(localRotate);
        float a = rd * rd;
        float b = 2 * (l * rd);
        float c = l * l - R * R;

        float d = b * b - 4 * a * c;
        if (d < 0)
        { return RenderData.NoRender; }

        d = (float)Math.Sqrt(d);
        
        float intersection = (-b - d) / (2 * a);
        Vector3 intersectionPoint = camera.GetIntersectionPoint(intersection);
        Vector3 normal = intersectionPoint - Position;
        
        return new RenderData(intersection, normal, intersectionPoint);
    }
}