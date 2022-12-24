// See https://aka.ms/new-console-template for more information
using g3;
using static g3.ThreeMFReader;
using Geometry;

CGeometry cube = new CGeometry(new CSimpleMesh());
cube.saveTo("G:\\Test.stl");
