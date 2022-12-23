// See https://aka.ms/new-console-template for more information
using g3;
using static g3.ThreeMFReader;

/*
 * List of vertex
*/
List<Vector3d> vertex = new()
{
    new Vector3d(2,5,0),
    new Vector3d(0,0.3,0),
    new Vector3d(2,0,0),
    new Vector3d(5,2,0),

};
/*List of triangles
 *
 */
List<Vector3i> triang = new()
{
    new Vector3i(0,2,1),
    new Vector3i(0,3,2),

};

/*
 *Calculate normal normalize for all vertex
 */
Vector3d normal = MathUtil.Normal(vertex[0], vertex[2], vertex[1]);

/*
 * Add each Normal of each vertex
 */
List<Vector3d> normals = new()
{
    normal,
    normal,
    normal,
    normal
};

DMesh3 mesh = DMesh3Builder.Build(vertex, triang, normals, null);

mesh.EnableVertexColors(new Vector3f(255, 0, 0));
bool hasVertexColor=mesh.Components.HasFlag(MeshComponents.VertexColors);
bool hasVertexNormal = mesh.Components.HasFlag(MeshComponents.VertexNormals);


//HalfEdgeMesh hmesh = new HalfEdgeMesh(mesh);
DMesh3 mesh_copy = new DMesh3(mesh);
WriteOptions w = new WriteOptions
{
    bWriteBinary = true
};
string name = "G:\\Test.stl";
StandardMeshWriter.WriteMesh(name, mesh_copy, w);