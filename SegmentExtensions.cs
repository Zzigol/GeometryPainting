using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTasks;

namespace GeometryPainting
{
    static class MyExtensions
    {
        static Dictionary<Segment, Color> dictionary = new Dictionary<Segment, Color>();
        public static Color GetColor(this Segment segment)
        {
            if (dictionary.ContainsKey(segment)) return dictionary[segment];
            
            return Color.Black;
        }

        public static void SetColor(this Segment segment, Color color) // установить цвет
        {
            if (!dictionary.ContainsKey(segment)) dictionary.Add(segment, color);
            else dictionary[segment] = color;
        }
    }
}
//SetColor должен присваивать переданному сегменту сегменту переданный цвет, а GetColor по сегменту возвращать его цвет
