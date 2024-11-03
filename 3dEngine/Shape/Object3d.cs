namespace _3dEngine;

public class Object3d : Shape
{
    private readonly List<Triangle> _faces;
    
    private readonly List<float> _intersections = new List<float>{ };
    private readonly List<Vector3> _normalIntersections = new List<Vector3> { };
    private Vector3 _lastNormal = new Vector3();

    public Object3d(Vector3 position, Vector3 rotate, List<Triangle> faces) : base(position, rotate)
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
            _faces.Add(new Triangle(new Vector3[]
                {
                    vertex[facingInfo.Vertex1 - 1],
                    vertex[facingInfo.Vertex2 - 1],
                    vertex[facingInfo.Vertex3 - 1]
                }, normals[facingInfo.NormalIndex - 1])
            );
        }
    }
    
    public override Vector3 ItPoint(Vector3 ro, Vector3 rd)
    {
        float intersection = Intersection(ro, rd);
        return ro + rd * intersection;
    }
    
    public override Vector3 LastPointNormal()
    {
        return _lastNormal;
    }

    private float Intersection(Vector3 ro, Vector3 rd)
    {
        FindAllIntersection(ro, rd);
        return NearbyIntersection();
    }

    private void FindAllIntersection(Vector3 ro, Vector3 rd)
    {
        ClearOldIntersectionsData();
        for(int i =0; i < _faces.Count; i ++)
        {
            var intersection = _faces[i].Intersection(ro,rd, Position, Rotate);
            if(intersection > -1)
            {
                _intersections.Add(intersection);
                _normalIntersections.Add(_faces[i].GetNormal(Rotate));
            }
        }
        CheckIntersectionExist();
    }

    private void CheckIntersectionExist()
    {
        if (!_intersections.Any())
        {
            _normalIntersections.Add(Vector3.Zero);
            _intersections.Add(-1);
        }
    }
    private void ClearOldIntersectionsData()
    {
        _intersections.Clear();
        _normalIntersections.Clear();
    }

    private float NearbyIntersection()
    {
        float minIntersection = _intersections[0];
        _lastNormal = _normalIntersections[0];
        for (int i = 0; i < _intersections.Count; i ++)
        {
            if (minIntersection > _intersections[i])
            {
                minIntersection = _intersections[i];
                _lastNormal = _normalIntersections[i];
            }
        }
        
        return minIntersection;
    }
}