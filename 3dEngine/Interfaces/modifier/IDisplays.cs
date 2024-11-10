using _3dEngine.Implementation;

namespace _3dEngine.Interfaces.modifier;

public interface IDisplays
{
    public RenderData GetRenderData(Vector3 rd, Vector3 ro);
}