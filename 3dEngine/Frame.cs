namespace _3dEngine;

public class Frame
{
    readonly Screen _screen = new Screen();
    public Vector3 ro = new Vector3(-2f, 0, 0);
    public Vector3 rd = new Vector3(0);
    private readonly Shape _sphere = new Sphere(new Vector3(0), Vector3.Zero);
    private readonly LightBase _light = new LightBase(new Vector3(-2f,-0f,0f));

    //private DateTime _lastFrame = DateTime.UtcNow;
    //private double fps = 0;
    
    public void MainLoop()
    {
        for (int t = 0; true; t++)
        {
            //_lastFrame = DateTime.UtcNow;
            _light.Position.X = (float)Math.Sin(t * 0.001f);
            _light.Position.Z = (float)Math.Cos(t * 0.001f);
            for (int j = 0; j < _screen.GetHeight(); j++)
            {
                for (int i = 0; i < _screen.GetWidth(); i++)
                {
                    _screen.SetPixelPos(i, j);
                    Vector2 uv = _screen.GetUv();
                    
                    rd.X = 1;
                    rd.Y = uv.Y;
                    rd.Z = uv.X;
                    
                    Vector2 intersection = _sphere.Intersection(ro, rd);
                    Vector3 itPoint = ro + rd * intersection.X;
                    int brightness = intersection.X > 0? _light.PointBright(itPoint) : 0;
                    //_screen.Paint(ro.X + "  " + ro.Y, Vector2Int.Zero);
                    _screen.Paint(brightness);
                }
            }
            //fps = (DateTime.UtcNow - _lastFrame).TotalMicroseconds > 0? 1 / (DateTime.UtcNow - _lastFrame).TotalSeconds : 0;
            //_screen.Paint( Double.Round(fps, 1).ToString(CultureInfo.InvariantCulture), Vector2Int.Zero);
        }
    }
}