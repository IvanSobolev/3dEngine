using _3dEngine.Implementation;
using _3dEngine.Interfaces;
using _3dEngine.Interfaces.modifier;

namespace _3dEngine.AbstractClass;

public abstract class Scene(IDisplaysManager displaysManager)
{
    private readonly IDisplaysManager _displaysManager = displaysManager;
    private readonly List<IDisplays> _allDisplays = new List<IDisplays>();
    private readonly List<Light> _allLight = new List<Light>();
    private Camera _renderCamera = new Camera(Vector3.Zero, Vector3.Zero);

    protected void SetMainCamera(Camera camera)
    { _renderCamera = camera; }
    protected void AddDisplaysObject(IDisplays @object)
    { _allDisplays.Add(@object); }

    protected void AddLight(Light light)
    { _allLight.Add(light); }
    
    public abstract void Start();
    public abstract void Update();

    public virtual int GetPixelBrightness(Vector2 uv)
    {
        _renderCamera.SetRdWithUv(uv);
        _displaysManager.FindAllRenderData(_renderCamera, _allDisplays);
        int maxBrightness = 0;
        foreach (var light in _allLight)
        {
            var brightness = light.PointBright(_displaysManager.GetNearbyRenderData());
            if (brightness > maxBrightness)
            {
                maxBrightness = brightness;
            }
        }

        return maxBrightness;
    }
}