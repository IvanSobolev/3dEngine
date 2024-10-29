namespace _3dEngine;

public class Frame
{
    readonly Screen _screen = new Screen();
    public Vector3 ro = new Vector3(-6f, 0, 0);
    public Vector3 rd = new Vector3(0);
    private readonly Shape _sphere = new Sphere(new Vector3(0,0,0), Vector3.Zero);
    private readonly LightBase _light = new LightBase(new Vector3(-2f,-0f,0f));
    
    public void MainLoop()
    {
        for (int t = 0; true; t++)
        {
            GameTime.StartFrame();
            _light.Position.X = (float)Math.Sin(t * 0.001f);
            _light.Position.Z = (float)Math.Cos(t * 0.001f);
            for (int j = 0; j < _screen.GetHeight(); j++)
            {
                for (int i = 0; i < _screen.GetWidth(); i++)
                {
                    _screen.SetPixelPos(i, j);
                    Vector2 uv = _screen.GetUv();
                    
                    rd.X = 3;
                    rd.Y = uv.Y;
                    rd.Z = uv.X;
                    rd = rd.Norm();
                    
                    Vector2 intersection = _sphere.Intersection(ro, rd);
                    Vector3 itPoint = ro + rd * intersection.X;
                    int brightness = intersection.X > 0? _light.PointBright(itPoint) : 0;
                    _screen.Paint(brightness);
                }
            }
            GameTime.EndFrame();
            _screen.Paint( Double.Round(GameTime.GetFps(), 1)  + "       ", Vector2Int.Zero);
        }
    }
}