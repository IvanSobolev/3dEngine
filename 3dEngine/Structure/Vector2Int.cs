namespace _3dEngine;

public class Vector2Int(int x = 0, int y = 0)
{
    public int X = x;
    public int Y = y;
    
    public static readonly Vector2Int Zero = new Vector2Int();
    public Vector2Int(int a) : this(a, a) { }
    public Vector2Int() : this(0, 0) { }
    
    private static Vector2Int _returnVectorInt = new Vector2Int();
    private static Vector2 _returnVector = new Vector2();
    
    public static Vector2Int operator +(Vector2Int a, Vector2Int b)
    { _returnVectorInt.X = a.X + b.X; _returnVectorInt.Y = a.Y + b.Y; return _returnVectorInt; }
    public static Vector2Int operator +(Vector2Int a, int b)
    { _returnVectorInt.X = a.X + b; _returnVectorInt.Y = a.Y + b; return _returnVectorInt; }
    
    public static Vector2Int operator -(Vector2Int a, Vector2Int b)
    { _returnVectorInt.X = a.X - b.X; _returnVectorInt.Y = a.Y - b.Y; return _returnVectorInt; }
    public static Vector2Int operator -(Vector2Int a, int b)
    { _returnVectorInt.X = a.X - b; _returnVectorInt.Y = a.Y - b; return _returnVectorInt; }
    
    public static Vector2Int operator *(Vector2Int a, Vector2Int b)
    { _returnVectorInt.X = a.X * b.X; _returnVectorInt.Y = a.Y * b.Y; return _returnVectorInt; }
    public static Vector2Int operator *(Vector2Int a, int b)
    { _returnVectorInt.X = a.X * b; _returnVectorInt.Y = a.Y * b; return _returnVectorInt; }
    
    public static Vector2 operator /(Vector2Int a, Vector2Int b)
    { _returnVector.X = (float)a.X / b.X; _returnVector.Y = (float)a.Y / b.Y; return _returnVector; }
    public static Vector2 operator /(Vector2Int a, Vector2 b)
    { _returnVector.X = a.X / b.X; _returnVector.Y = a.Y / b.Y; return _returnVector; }
    public static Vector2 operator /(Vector2Int a, int b)
    { _returnVector.X = (float)a.X / b; _returnVector.Y = (float)a.Y / b; return _returnVector; }
}