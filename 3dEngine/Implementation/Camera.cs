using _3dEngine.AbstractClass;
using _3dEngine.Interfaces;

namespace _3dEngine.Implementation;

public class Camera(Vector3 position, Vector3 localRotate) : GameObject(position, localRotate), ICamera
{
    private Vector3 _rayStartPosition = new Vector3(-6,0,0);
    private Vector3 _rayDirection = new Vector3(6,0,0);

    public void SetRdWithUv(Vector2 uv)
    {
        _rayDirection = new Vector3(3, uv.Y, uv.X);
    }

    public Ray GetRay()
    {
        return new Ray((_rayStartPosition.Rotate(LocalRotate) + Position).Rotate(GlobalRotate),
            (_rayDirection.Rotate(LocalRotate) + Position).Rotate(GlobalRotate));
    }
}