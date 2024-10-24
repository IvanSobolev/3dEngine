namespace _3dEngine;

public class Square(Vector3 position, Vector3 angle, float a, float b) : Shape(position, angle)
{
    public float A = a;
    public float B = b;
    
    public override Vector2 Intersection(Vector3 ro, Vector3 rd)
    {
        //pos.X >= -a / 2 && pos.X <= a / 2 && pos.Y >= -b/2 && pos.Y <= b/2;
        throw new NotImplementedException();
    }
}