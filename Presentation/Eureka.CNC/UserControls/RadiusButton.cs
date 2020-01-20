using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.UserControls
{
    public class RadiusButton : MaterialRaisedButton
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {            
            GraphicsPath grPaht = new GraphicsPath();
            grPaht.AddEllipse(10, 10, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPaht);
            base.OnPaint(pevent);
        }
    }
}
