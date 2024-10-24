namespace _3dEngine;

public class Circle(Vector3 position, Vector3 angle, float radius = 1) : Shape(position, angle)
{
    public float Radius = radius;

    public override Vector2 Intersection(Vector3 ro, Vector3 rd)
    {
        throw new NotImplementedException();
    }
}