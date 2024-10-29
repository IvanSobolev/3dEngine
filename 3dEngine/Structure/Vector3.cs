namespace _3dEngine;

public struct Vector3(float x, float y, float z)
{
    public float X = x;
    public float Y = y;
    public float Z = z;

    public Vector3(float x, Vector2 a) : this(x, a.X, a.Y) { }
    public Vector3(Vector2 a, float z) : this(a.X, a.Y, z) { }
    public Vector3(float a) : this(a, a, a) { }
    public Vector3() : this(0, 0, 0) { }

    public static readonly Vector3 Zero = new Vector3();
    
    public static Vector3 operator +(Vector3 a, Vector3 b) 
    {  return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
    public static Vector3 operator +(Vector3 a, Vector2 b) 
    {  return new Vector3(a.X + b.X, a.Y + b.Y, a.Z); }
    public static Vector3 operator +(Vector3 a, int b) 
    {  return new Vector3(a.X + b, a.Y + b, a.Z + b); }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {  return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
    public static Vector3 operator -(Vector3 a, int b)
    { return new Vector3(a.X - b, a.Y - b, a.Z - a.Z);}
    public static Vector3 operator -(Vector3 a)
    {  return new Vector3(-a.X, -a.Y, -a.Z); }

    public static float operator *(Vector3 a, Vector3 b)
    { return a.X * b.X + a.Y * b.Y + a.Z * b.Z; }
    public static Vector3 operator *(Vector3 a, float b)
    {  return new Vector3(a.X * b, a.Y * b, a.Z * b); }
    
    public static Vector3 operator /(Vector3 a, Vector3 b) 
    {  return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z); }
    public static Vector3 operator /(Vector3 a, float b)
    {  return new Vector3(a.X / b, a.Y / b, a.Z / b); }
    
    
}