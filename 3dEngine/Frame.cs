namespace _3dEngine;

public class Frame
{
    readonly Screen _screen = new Screen();
    public Vector3 ro = new Vector3(-6f, 0, 0);
    public Vector3 rd = new Vector3(0);
    private readonly Shape _sphere = new Sphere(new Vector3(0,0,0), Vector3.Zero);

    private readonly Object3d Cube = new Object3d(
        new Vector3[]
        {
            new Vector3(-1f, -1f, 1f),   
            new Vector3(-1f, 1f, 1f),
            new Vector3(-1f, -1f, -1f),
            new Vector3(-1f, 1f, -1f),
            new Vector3(1f, -1f, 1f),
            new Vector3(1f, 1f, 1f),
            new Vector3(1f, -1f, -1f),
            new Vector3(1f, 1f, -1f)
        },
        new Vector3[]
        {
            new Vector3(-1f, 0, 0),
            new Vector3(0, 0, -1f),
            new Vector3(1f, 0, 0),
            new Vector3(0, 0, 1f),
            new Vector3(0, -1f, 0),
            new Vector3(0, 1f, 0)
        },
        new FacingInfo[]
        {
            new FacingInfo(new int[] {2,3,1}, 1),
            new FacingInfo(new int[] {4,7,3}, 2),
            new FacingInfo(new int[] {8,5,7}, 3),
            new FacingInfo(new int[] {6,1,5}, 4),
            new FacingInfo(new int[] {7,1,3}, 5),
            new FacingInfo(new int[] {4,6,8}, 6),
            new FacingInfo(new int[] {2,4,3}, 1),
            new FacingInfo(new int[] {4,8,7}, 2),
            new FacingInfo(new int[] {8,6,5}, 3),
            new FacingInfo(new int[] {6,2,1}, 4),
            new FacingInfo(new int[] {7,5,1}, 5),
            new FacingInfo(new int[] {4,2,6}, 6)
        });
    
    private readonly Light _light = new Light(new Vector3(-1f,0f,0f),10);
    
    public void MainLoop()
    {
        Cube.Position = new Vector3(1,0,0);
        _light.Position = new Vector3(-3, 0, 0);
        for (int t = 0; true; t++)
        {
            GameTime.StartFrame();
            Cube.Rotate.Y += 0.01f;
            Cube.Rotate.Z += 0.002f;
            Cube.Rotate.X += 0.001f;
            _light.Position.X = (float)Math.Sin(t * 0.001f)*2;
            _light.Position.Z = (float)Math.Cos(t * 0.001f)*2;
            for (int j = 0; j < _screen.GetHeight(); j++)
            {
                for (int i = 0; i < _screen.GetWidth(); i++)
                {
                    _screen.SetPixelPos(i, j);
                    Vector2 uv = _screen.GetUv();
                    
                    rd.X = 3;
                    rd.Y = uv.Y;
                    rd.Z = uv.X;

                    Vector3 itPoint = _sphere.ItPoint(ro,rd);
                    int brightness = _light.PointBright(itPoint,_sphere.LastPointNormal());
                    
                    _screen.Paint(brightness);
                }
            }
            
            _screen.Paint( "Fps: " + Double.Round(GameTime.GetFps(), 1)  + "       ", Vector2Int.Zero);
            GameTime.EndFrame();
        }
    }
}