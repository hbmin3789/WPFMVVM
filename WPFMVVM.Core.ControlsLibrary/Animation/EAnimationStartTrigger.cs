using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVM.Core.ControlsLibrary.Animation
{
    public enum EAnimationStartTrigger
    {
        //OnRendered
        Auto,
        //Set when you want to start animation with AnimationPanel.AnimationStart() method.
        Custom
    }
}
