namespace _3dEngine;

public static class Operation
{
    public static float Length(this Vector2 v) => (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
    public static float Length(this Vector3 v) => (float)Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
    public static Vector3 Norm(this Vector3 v) => v / v.Length();
}