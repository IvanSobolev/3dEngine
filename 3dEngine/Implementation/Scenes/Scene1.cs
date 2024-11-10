using _3dEngine.AbstractClass;
using _3dEngine.Interfaces;
using _3dEngine.Shape;
using _3dEngine.StaticClass;

namespace _3dEngine.Implementation.Scenes;

public class Scene1 (IDisplaysManager iDisplaysManager) : Scene(iDisplaysManager)
{
    private readonly Camera _camera = new Camera(new Vector3(0,0,0), Vector3.Zero);
    
    private readonly Light _light = new Light(new Vector3(-1f,0f,0f),10);

    private readonly Sphere _sphere = new Sphere(new Vector3(0,0,0), Vector3.Zero);

    private readonly Object3d _cube = new Object3d(
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
    

    public override void Start()
    {
        _cube.Position = new Vector3(0,0,2);
        _sphere.Position = new Vector3(0, 0, -2);
        
        _camera.Position = new Vector3(-1f, 0, 0);
        _light.Position = new Vector3(-1, 0, 0);
        
        AddDisplaysObject(_cube);
        AddDisplaysObject(_sphere);
        AddLight(_light);
        SetMainCamera(_camera);
    }

    public override void Update()
    {
        _camera.GlobalRotate.Y += 1f * GameTime.GetDeltaTime();
        _light.Position = _camera.GetRo();
    }
}