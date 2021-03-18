using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFMVVM.Core.ControlsLibrary.CustomControls
{
    /// <summary>
    /// Default Animation Duration is 1.
    /// 
    /// </summary>
    public class HudBlinkTextBlock : HudTextBlockBase 
    {
        public HudBlinkTextBlock() : base()
        {
            //Default Animation Duration
            AnimationDuration = TimeSpan.FromSeconds(1);
        }
    }
}
