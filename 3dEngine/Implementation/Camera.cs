using _3dEngine.AbstractClass;
using _3dEngine.Interfaces;

namespace _3dEngine.Implementation;

public class Camera(Vector3 position, Vector3 localRotate) : GameObject(position, localRotate), ICamera
{
    private Vector3 _rayStartPosition = new Vector3(-6,0,0);
    private Vector3 _rayDirection = Vector3.Zero;

    public void SetRdWithUv(Vector2 uv)
    {
        _rayDirection = new Vector3(3, uv.Y, uv.X);
    }

    public Vector3 GetRd()
    {
        return (_rayDirection.Rotate(LocalRotate) + Position).Rotate(GlobalRotate);
    }

    public Vector3 GetRo()
    {
        return (_rayStartPosition.Rotate(LocalRotate) + Position).Rotate(GlobalRotate);
    }

    public Vector3 GetIntersectionPoint(float intersection)
    {
        return GetRo() + GetRd() * intersection;
    }
}