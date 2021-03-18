using WPFMVVM.Core.ControlsLibrary.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVM.Core.ControlsLibrary.WindowFrame
{
    public class HudCornerFrame : AnimationBase
    {
        public HudCornerFrame() : base()
        {
            //Default AnimationDuration
            AnimationDuration = TimeSpan.FromSeconds(1);
        }
    }
}
