using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVM.Core.ControlsLibrary.Animation;

namespace WPFMVVM.Core.ControlsLibrary.CustomControls
{
    public class HudTextBlockBase : AnimationBase
    {
        #region TextProperty

        public static DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(HudTextBlockBase),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnTextPropertyChanged)));

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as HudTextBlockBase;
            control.Text = e.NewValue.ToString();
        }

        public string Text
        {
            get => GetValue(TextProperty).ToString();
            set => SetValue(TextProperty, value);
        }

        #endregion
    }
}
