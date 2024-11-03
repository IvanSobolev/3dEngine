namespace _3dEngine;

public class Sphere(Vector3 position, Vector3 rotate, float r = 1) : Shape(position, rotate)
{
    public float R = r;
    private Vector3 _lastNormal = new Vector3();
    
    public override Vector3 ItPoint(Vector3 ro, Vector3 rd)
    {
        float intersection = Intersection(ro, rd);
        Vector3 itPoint = ro + rd * intersection;
        _lastNormal = intersection > -1 ?  itPoint - Position : Vector3.Zero;
        return itPoint;
    }

    public override Vector3 LastPointNormal()
    {
        return _lastNormal;
    }

    private float SolvingQuadraticEquation(float a, float b, float c)
    {
        float d = b * b - 4 * a * c;
        if (d < 0)
        { return -1; }

        d = (float)Math.Sqrt(d);
        float answer = (-b - d) / (2 * a);
        
        return answer;
    }

    private float Intersection(Vector3 ro, Vector3 rd)
    {
        Vector3 l = ro - Position;
        float a = rd * rd;
        float b = 2 * (l * rd);
        float c = l * l - R * R;

        return SolvingQuadraticEquation(a, b, c);
    }
}