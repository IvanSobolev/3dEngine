namespace _3dEngine.Interfaces;

public interface ICamera
{
    public void SetRdWithUv(Vector2 uv);
    public Vector3 GetRd();
    public Vector3 GetRo();
    public Vector3 GetIntersectionPoint(float intersection);
}