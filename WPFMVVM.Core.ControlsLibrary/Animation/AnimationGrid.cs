using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WPFMVVM.Core.ControlsLibrary.Animation
{
    public class AnimationGrid : Grid, IAnimatable
    {
        private List<IAnimatable> _animations = new List<IAnimatable>();

        #region AnimationStartTriggerProperty

        public static DependencyProperty AnimationStartTriggerProperty =
            DependencyProperty.Register("AnimationStartTrigger", typeof(EAnimationStartTrigger), typeof(AnimationGrid),
                new FrameworkPropertyMetadata(EAnimationStartTrigger.Auto , FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnAnimationStartTriggerPropertyChanged)));

        private static void OnAnimationStartTriggerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as AnimationGrid;
        }

        public EAnimationStartTrigger AnimationStartTrigger
        {
            get => (EAnimationStartTrigger)GetValue(AnimationStartTriggerProperty);
            set => SetValue(AnimationStartTriggerProperty, value);
        }

        #endregion

        #region AnimationDurationProperty

        public static DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(AnimationGrid),
                new FrameworkPropertyMetadata(TimeSpan.FromMilliseconds(1), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnAnimationDurationPropertyChanged)));

        private static void OnAnimationDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as AnimationGrid;
        }

        public TimeSpan AnimationDuration
        {
            get
            {
                if(AnimationStartTrigger == EAnimationStartTrigger.Auto)
                {
                    TimeSpan time = TimeSpan.FromSeconds(0);
                    _animations.ForEach(x => time.Add(x.AnimationDuration));
                    SetValue(AnimationDurationProperty, time);
                }
                return (TimeSpan)GetValue(AnimationDurationProperty);
            }
            set => SetValue(AnimationDurationProperty, value);
        }

        #endregion

        public AnimationGrid()
        {

        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            if(AnimationStartTrigger == EAnimationStartTrigger.Auto)
            {
                StartAnimation();
            }
        }

        private async Task StartAnimation()
        {
            _animations = GetAnimations();
            for(int i = 0; i < _animations.Count; i++)
            {
                _animations[i].StartAnimation();
                await Task.Delay(_animations[i].AnimationDuration);
            }
        }

        public List<IAnimatable> GetAnimations()
        {
            List<IAnimatable> retval = new List<IAnimatable>();

            for (int i = 0; i < Children.Count; i++)
            {
                if(Children[i] is IAnimatable)
                {
                    retval.Add(Children[i] as IAnimatable);
                }
                else if(Children[i] is Panel)
                {
                    retval.AddRange(GetChilds(Children[i] as Panel));
                }
            }

            return retval;
        }

        private List<IAnimatable> GetChilds(Panel panel)
        {
            var children = panel.Children;
            List<IAnimatable> retval = new List<IAnimatable>();

            for (int i = 0; i < children.Count; i++)
            {
                if(children[i] is IAnimatable)
                {
                    retval.Add(children[i] as IAnimatable);
                }
                else if(children[i] is Panel)
                {
                    retval.AddRange(GetChilds(children[i] as Panel));
                }
            }

            return retval;
        }

        void IAnimatable.StartAnimation()
        {
            StartAnimation();
        }
    }
}
