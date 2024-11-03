using _3dEngine.Interfaces;

namespace _3dEngine;

public class Light(Vector3 position, float lightPower = 10) : ILight
{
    public Vector3 Position = position;
    public float LightPower = lightPower;

    public int PointBright(Vector3 itPoint, Vector3 n)
    {
        Vector3 lightDir = (Position - itPoint).Norm();
        float diff = Math.Max(0, n * lightDir);
        return (int)(diff * LightPower);
    }
}