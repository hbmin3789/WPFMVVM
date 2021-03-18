using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFMVVM.Core.ControlsLibrary.Animation
{
    public class AnimationBase : Control, IAnimatable
    {
        #region AnimationDurationProperty

        public static DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(AnimationBase),
                new FrameworkPropertyMetadata(TimeSpan.FromMilliseconds(1), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnAnimationDurationPropertyChanged)));

        private static void OnAnimationDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as AnimationBase;
        }

        public TimeSpan AnimationDuration
        {
            get => (TimeSpan)GetValue(AnimationDurationProperty);
            set => SetValue(AnimationDurationProperty, value);
        }

        #endregion

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
