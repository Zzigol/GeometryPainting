using System;

namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;
        public double GetLength()
        {
            var vector = new Vector() { X = X, Y = Y };
            return Geometry.GetLength(vector);
        }

        public Vector Add(Vector vector2)
        {
            var vector1 = new Vector() { X = X, Y = Y };
            
            return Geometry.Add(vector1, vector2);
        }

        public bool Belongs(Segment segment)
        {
            var vector = new Vector() { X = X, Y = Y };
            return Geometry.IsVectorInSegment(vector, segment);
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;
        public double GetLength()
        {
            var segment = new Segment();
            
            return Geometry.GetLength(segment);
        }

        public bool Contains(Vector vector)
        {
            var segment = new Segment() { Begin = Begin, End = End };
            
            return Geometry.IsVectorInSegment(vector, segment);
        }
    }

    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static double GetLength(Segment segment)
        {
            var vector = new Vector();

            vector.X = segment.End.X-segment.Begin.X;
            vector.Y = segment.End.Y - segment.Begin.Y;

            return GetLength(vector);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            var vector3 = new Vector();
            vector3.X = vector1.X + vector2.X;
            vector3.Y = vector1.Y + vector2.Y;
            return vector3;
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            bool result;
            if (GetLength(segment)==0 && segment.Begin.X==vector.X && segment.Begin.Y == vector.Y)
                result = true;
            else if ((vector.X - segment.Begin.X)*(segment.End.Y - segment.Begin.Y) - (vector.Y - segment.Begin.Y) * (segment.End.X - segment.Begin.X)==0 &&
                (((segment.Begin.X <= vector.X) && (vector.X <= segment.End.X)) || ((segment.End.X <= vector.X && vector.X <= segment.Begin.X)))
                && GetLength(segment) != 0
                && (((segment.Begin.Y <= vector.Y) && (vector.Y <= segment.End.Y)) || ((segment.End.Y <= vector.Y && vector.Y <= segment.Begin.Y))))
                result = true;
            else result = false;
            return result;
        }
    }
}
