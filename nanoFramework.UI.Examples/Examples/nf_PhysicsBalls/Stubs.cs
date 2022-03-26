using System;

namespace Avalonia
{
    class Stubs
    {
    }
    public class Matrix4x4
    {
        public Matrix4x4(float M11, float M12, float M13, int z1, float M21, float M22, float M23, int z2, float M31, float M32, float M33, int z3, int z4, int z5, int z6, int z7)
        {
        }
    }
    public class Vector3
    {
        public Vector3(float X, float Y, int z1)
        {

        }

        public static Vector3 Transform(Vector3 position, Matrix4x4 matrix)
        {
            throw null;
        }
    }
}
