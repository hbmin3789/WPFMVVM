using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFMVVM.Core.ControlsLibrary.Animation;

namespace WPFMVVM.Core.ControlsLibrary.CustomControls
{
    public class HudButtonBase : Button , IAnimatable
    {

        #region AnimationDurationProperty

        public static DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(HudButtonBase),
                new FrameworkPropertyMetadata(TimeSpan.FromMilliseconds(1), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnAnimationDurationPropertyChanged)));

        private static void OnAnimationDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as HudButtonBase;
        }

        public TimeSpan AnimationDuration
        {
            get => (TimeSpan)GetValue(AnimationDurationProperty);
            set => SetValue(AnimationDurationProperty, value);
        }

        #endregion

        public HudButtonBase()
        {
            AnimationDuration = TimeSpan.FromSeconds(1);
        }

        public void StartAnimation()
        {
            SetState();
        }

        protected virtual void SetState()
        {
            VisualStateManager.GoToState(this, AnimationState.AnimationStarted, true);
        }
    }
}
