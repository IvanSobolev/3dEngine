namespace _3dEngine;

public static class Operation
{
    public static float Length(this Vector2 v) => (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
    public static float Length(this Vector3 v) => (float)Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
    public static Vector3 Norm(this Vector3 v) => v / v.Length();
    public static Vector3 Cross(Vector3 a, Vector3 b)
    {
        return new Vector3(
            a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X
        );
    }
}