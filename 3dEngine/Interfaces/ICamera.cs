namespace _3dEngine.Interfaces;

public interface ICamera
{
    public void SetRdWithUv(Vector2 uv);
    public Ray GetRay();
}