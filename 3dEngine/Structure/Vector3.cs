using System.Reflection.Metadata.Ecma335;

namespace _3dEngine;

public class Vector3(float x, float y, float z)
{
    public float X = x;
    public float Y = y;
    public float Z = z;

    public Vector3(float x, Vector2 a) : this(x, a.X, a.Y) { }
    public Vector3(Vector2 a, float z) : this(a.X, a.Y, z) { }
    public Vector3(float a) : this(a, a, a) { }
    public Vector3() : this(0, 0, 0) { }

    public static readonly Vector3 Zero = new Vector3();
    private static Vector3 _returnVector3 = new Vector3();
    
    public static Vector3 operator +(Vector3 a, Vector3 b) 
    { _returnVector3.X = a.X + b.X; _returnVector3.Y = a.Y + b.Y; _returnVector3.Z = a.Z + b.Z; return _returnVector3; }
    public static Vector3 operator +(Vector3 a, Vector2 b) 
    { _returnVector3.X = a.X + b.X; _returnVector3.Y = a.Y + b.Y; _returnVector3.Z = a.Z; return _returnVector3; }
    public static Vector3 operator +(Vector3 a, int b) 
    { _returnVector3.X = a.X + b; _returnVector3.Y = a.Y + b; _returnVector3.Z = a.Z + b; return _returnVector3; }
    
    public static Vector3 operator -(Vector3 a, Vector3 b)
    { _returnVector3.X = a.X - b.X; _returnVector3.Y = a.Y - b.Y; _returnVector3.Z = a.Z - b.Z; return _returnVector3; }
    public static Vector3 operator -(Vector3 a, int b)
    { _returnVector3.X = a.X - b; _returnVector3.Y = a.Y - b; _returnVector3.Z = a.Z - b; return _returnVector3; }

    
    public static float operator *(Vector3 a, Vector3 b)
    { return a.X * b.X + a.Y * b.Y + a.Z * b.Z; }
    public static Vector3 operator *(Vector3 a, float b)
    { _returnVector3.X = a.X * b; _returnVector3.Y = a.Y * b; _returnVector3.Z = a.Z * b; return _returnVector3; }
    
    public static Vector3 operator /(Vector3 a, Vector3 b) 
    { _returnVector3.X = a.X / b.X; _returnVector3.Y = a.Y / b.Y; _returnVector3.Z = a.Z / b.Z; return _returnVector3; }
    public static Vector3 operator /(Vector3 a, float b)
    { _returnVector3.X = a.X / b; _returnVector3.Y = a.Y / b; _returnVector3.Z = a.Z / b; return _returnVector3; }
    
    
}