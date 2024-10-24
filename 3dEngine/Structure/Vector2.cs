namespace _3dEngine;

public struct Vector2(float x = 0, float y = 0)
{
    public float X = x;
    public float Y = y;

    public static readonly Vector2 Zero = new Vector2();
    private static Vector2 _returnVector2 = new Vector2();
    
    public static Vector2 operator +(Vector2 a, Vector2 b) 
    { _returnVector2.X = a.X + b.X; _returnVector2.Y = a.Y + b.Y; return _returnVector2; }
    public static Vector2 operator +(Vector2 a, int b) 
    { _returnVector2.X = a.X + b; _returnVector2.Y = a.Y + b; return _returnVector2; }
    
    public static Vector2 operator -(Vector2 a, Vector2 b) 
    { _returnVector2.X = a.X - b.X; _returnVector2.Y = a.Y - b.Y; return _returnVector2; }
    public static Vector2 operator -(Vector2 a, int b) 
    { _returnVector2.X = a.X - b; _returnVector2.Y = a.Y - b; return _returnVector2; }
    
    public static Vector2 operator *(Vector2 a, Vector2 b)
    { _returnVector2.X = a.X * b.X; _returnVector2.Y = a.Y * b.Y; return _returnVector2; }
    public static Vector2 operator *(Vector2 a, int b)
    { _returnVector2.X = a.X * b; _returnVector2.Y = a.Y * b; return _returnVector2; }
    
    public static Vector2 operator /(Vector2 a, Vector2 b)
    { _returnVector2.X = a.X / b.X; _returnVector2.Y = a.Y / b.Y; return _returnVector2; }
    public static Vector2 operator /(Vector2 a, int b)
    { _returnVector2.X = a.X / b; _returnVector2.Y = a.Y / b; return _returnVector2; }
    public static Vector2 operator /(Vector2 a, Vector2Int b)
    { _returnVector2.X = a.X / b.X; _returnVector2.Y = a.Y / b.Y; return _returnVector2; }

    public Vector2 Rotate(float a)
    {
        double xr = X * Math.Cos(a) - Y * Math.Sin(a);
        double yr = X * Math.Sin(a) + Y * Math.Cos(a);

        return new Vector2((float)xr, (float)yr);
    }

    public void CircleMove(float tick, float r)
    {
        X += (float)Math.Sin(tick) * r;
        Y += (float)Math.Cos(tick) * r;
    }
}