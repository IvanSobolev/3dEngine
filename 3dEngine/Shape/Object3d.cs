using _3dEngine.AbstractClass;
using _3dEngine.Implementation;
using _3dEngine.Interfaces;
using _3dEngine.Interfaces.modifier;

namespace _3dEngine.Shape;

public class Object3d : GameObject, IDisplays
{
    private readonly List<Triangle> _faces;
    private readonly IDisplaysManager _displaysManager = new DisplaysManager();
    private List<IDisplays> ids = new List<IDisplays>();

    public Object3d(Vector3 position, Vector3 localRotate, List<Triangle> faces) : base(position, localRotate)
    {
        _faces = faces;
    }
    
    public Object3d(List<Triangle> faces) : base(Vector3.Zero, Vector3.Zero)
    {
        _faces = faces;
    }
    
    public Object3d(Vector3[] vertex, Vector3[] normals, FacingInfo[] facingInfos) : base(Vector3.Zero, Vector3.Zero)
    {
        _faces = new List<Triangle>();
        foreach (var facingInfo in facingInfos)
        {
            _faces.Add(
                new Triangle(
                    new Vector3[]
                    {
                        vertex[facingInfo.Vertex1 - 1],
                        vertex[facingInfo.Vertex2 - 1],
                        vertex[facingInfo.Vertex3 - 1]
                    }, 
                    normals[facingInfo.NormalIndex - 1]
                    )
            );
        }
    }

    public RenderData GetRenderData(Vector3 rd, Vector3 ro)
    {
        ids.Clear();
        foreach (var id in _faces)
        {
            id.Position = Position;
            id.LocalRotate = LocalRotate;
            id.GlobalRotate = GlobalRotate;
            ids.Add(id);
        }
        _displaysManager.FindAllRenderData(rd, ro, ids);
        return _displaysManager.GetNearbyRenderData();
    }
}