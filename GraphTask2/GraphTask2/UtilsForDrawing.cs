using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTask2
{
    class UtilsForDrawing
    {
        public static Pen PenLine = new Pen(Color.Chocolate);
        public static Pen PenNode = new Pen(Color.Green);
        public static Pen CrimsonPenNode = new Pen(Color.Crimson);
        public static SolidBrush BrushBackground = new SolidBrush(Color.NavajoWhite);
        public static SolidBrush BrushBackHighLight = new SolidBrush(Color.Crimson);
        public static SolidBrush BrushNodeData = new SolidBrush(Color.Black);
        public static Font FontNode = new Font("Calibri", 15);
        public static Font FontEdge = new Font("Calibri", 12);
    }
}
