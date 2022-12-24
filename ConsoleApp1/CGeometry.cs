using g3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Geometry
{
    internal class CGeometry : ICloneable, ISimpleMesh<Vector3d, Index3i>
    {
        private readonly DMesh3 mesh;

        public CGeometry(CSimpleMesh pSimpleMesh) {
            mesh = DMesh3Builder.Build<Vector3d, Index3i, Vector3d>(pSimpleMesh.Vertices, pSimpleMesh.Triangles);
            MeshNormals meshNormal = new MeshNormals(mesh);
            meshNormal.Compute();
            meshNormal.CopyTo(mesh);
        } 

        IEnumerable<Vector3d> ISimpleMesh<Vector3d, Index3i>.Vertices  {
            get
            {
                return mesh.Vertices();

            }
              

    }

        IEnumerable<Index3i> ISimpleMesh<Vector3d, Index3i>.Triangles {
            get
            {
                return mesh.Triangles();
            }

        }
        /// <summary>
        ///  Make a copy of object DMesh3
        /// </summary>
        /// <returns>object DMesh3 </returns>  
        public object Clone()
        {
            DMesh3 mesh_copy = new DMesh3(mesh);
            return mesh;
        }
        /// <summary>
        /// Save to file with route full pPatch
        /// </summary>
        /// <param name="pPatch"> rute sample D://myfile.stl</param>
       public void saveTo(string pPatch)
        {
            DMesh3 mesh_copy = (DMesh3)  Clone();
            WriteOptions w = new WriteOptions
            {
                bWriteBinary = true
            };  
            StandardMeshWriter.WriteMesh(pPatch, mesh_copy, w);
        }
    }

}
