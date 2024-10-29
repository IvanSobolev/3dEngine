using _3dEngine.Interfaces;

namespace _3dEngine;

public class LightBase(Vector3 position, float lightPower = 10) : ILight
{
    public Vector3 Position = position;
    public float LightPower = lightPower;

    public int PointBright(Vector3 itPoint)
    {
        Vector3 n = itPoint.Norm();
        float diff = n * Position;
        return (int)(diff * LightPower);
    }
}