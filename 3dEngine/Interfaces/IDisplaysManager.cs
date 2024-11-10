using _3dEngine.Implementation;
using _3dEngine.Interfaces.modifier;

namespace _3dEngine.Interfaces;

public interface IDisplaysManager
{
    public void FindAllRenderData(Camera camera, List<IDisplays> displays);
    public RenderData GetNearbyRenderData();
}