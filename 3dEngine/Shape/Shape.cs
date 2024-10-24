namespace _3dEngine;

public abstract class Shape(Vector3 position, Vector3 rotate)
{
    public Vector3 Position = position;
    public Vector3 Rotate = rotate;
    public abstract Vector2 Intersection(Vector3 ro, Vector3 rd);
}