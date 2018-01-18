using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingGraphicsLib
{
   public interface GraphicsInterface
    {
        void DrawingGraphics();//必须实现此接口
        //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow
        int GraphicType { get; set; }//图形类型


    }
}
