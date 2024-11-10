using _3dEngine.Implementation;
using _3dEngine.Interfaces.modifier;

namespace _3dEngine.Interfaces;

public interface IDisplaysManager
{
    public void FindAllRenderData(Vector3 rd, Vector3 ro, List<IDisplays> displays);
    public RenderData GetNearbyRenderData();
}