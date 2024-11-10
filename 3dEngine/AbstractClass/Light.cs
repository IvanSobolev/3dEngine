using _3dEngine.Implementation;
using _3dEngine.Interfaces;
using _3dEngine.Interfaces.modifier;

namespace _3dEngine.AbstractClass;

public class Light (Vector3 position, float lightPower) : GameObject(position, Vector3.Zero)
{
    public float LightPower = lightPower;
    private readonly IDisplaysManager _displaysManager = new DisplaysManager();

    public virtual int PointBright(RenderData renderData)
    {
        Vector3 lightDir = (Position - renderData.IntersectionPoint).Norm();
        float diff = Math.Max(0, renderData.Normal * lightDir);
        return (int)(diff * LightPower);
    }
    public virtual int PointBright(RenderData renderData, List<IDisplays> objs)
    {
        Vector3 lightDir = (Position - renderData.IntersectionPoint).Norm();
        bool isShadow = false;
        Ray ray = new Ray(Position, renderData.IntersectionPoint);
        _displaysManager.FindAllRenderData(ray, objs);
        var d = _displaysManager.GetNearbyRenderData();
        
        if ((Position - d.IntersectionPoint).Length() < (Position - renderData.IntersectionPoint).Length() - 0.1f) 
        { 
            isShadow = true;
        }

        if (isShadow)
        {
            return 0;
        }
        float diff = Math.Max(0, renderData.Normal * lightDir);
        return (int)(diff * LightPower);
    }
}