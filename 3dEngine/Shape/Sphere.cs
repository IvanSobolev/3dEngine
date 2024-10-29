namespace _3dEngine;

public class Sphere(Vector3 position, Vector3 rotate, float r = 1) : Shape(position, rotate)
{
    public float R = r;
    
    public override Vector2 Intersection(Vector3 ro, Vector3 rd)
    {
        Vector3 l = ro - Position;
        float a = rd * rd;
        float b = 2 * (l * rd);
        float c = l * l - R * R;
        float d = b * b - 4 * a * c;
        if (d < 0)
        { return new Vector2(-1); }

        d = (float)Math.Sqrt(d);
        float p1 = (-b - d) / (2 * a);
        float p2 = (-b + d) / (2 * a);
        return new Vector2(p1, p2);
    }
}