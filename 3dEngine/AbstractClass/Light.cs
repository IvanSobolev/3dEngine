namespace _3dEngine.AbstractClass;

public class Light (Vector3 position, float lightPower) : GameObject(position, Vector3.Zero)
{
    public float LightPower = lightPower;

    public virtual int PointBright(RenderData renderData)
    {
        Vector3 lightDir = (Position - renderData.IntersectionPoint).Norm();
        float diff = Math.Max(0, renderData.Normal * lightDir);
        return (int)(diff * LightPower);
    }
}