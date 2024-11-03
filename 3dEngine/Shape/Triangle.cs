namespace _3dEngine;

public class Triangle
{
    public Vector3[] Vertex;
    public Vector3 Normal;

    
    public Triangle(Vector3[] vertex, Vector3 normal)
    {
        Vertex = vertex;
        Normal = normal;
    }
    
    public Triangle(Vector3[] vertex)
    {
        Vertex = vertex;
        Vector3 E1 = vertex[1] - vertex[0];
        Vector3 E2 = vertex[2] - vertex[0];
        Normal = -Operation.Cross(E1, E2).Norm();
    }

    public float Intersection(Vector3 ro, Vector3 rd, Vector3 position, Vector3 rotation)
    {
        var v0 = (Vertex[0].Rotate(rotation) + position);
        var v1 = (Vertex[1].Rotate(rotation) + position);
        var v2 = (Vertex[2].Rotate(rotation) + position);
        Vector3 E1 = v1 - v0;
        Vector3 E2 = v2 - v0;
        Vector3 P = Operation.Cross(rd, E2);
        float det = E1 * P;
        if (Math.Abs(det) < 1e-6) return -1;
        float invDet = 1.0f / det;
        Vector3 T = ro - v0;
        float u = T * P * invDet;
        if(u < 0 || u > 1) return -1;
        Vector3 Q = Operation.Cross(T, E1);
        float v = rd * Q * invDet;
        if(v < 0 || u + v > 1) return -1;
        float t = E2 * Q * invDet;
        if(t < 0) return -1;
        return t;
    }

    public Vector3 GetNormal(Vector3 rotation)
    {
        return Normal.Rotate(rotation);
    }
}