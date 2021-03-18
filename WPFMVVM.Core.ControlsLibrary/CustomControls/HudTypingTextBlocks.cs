using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WPFMVVM.Core.ControlsLibrary.Animation;

namespace WPFMVVM.Core.ControlsLibrary.CustomControls
{
    public class HudTypingTextBlock : HudTextBlockBase
    {
        ObjectAnimationUsingKeyFrames keyframes = new ObjectAnimationUsingKeyFrames();
        Storyboard storyboard = new Storyboard();

        public HudTypingTextBlock()
        {
            AnimationDuration = TimeSpan.FromSeconds(0.2);
        }

        protected override void SetState()
        {
            TextAnimation();
            VisualStateManager.GoToState(this, AnimationState.AnimationStarted, true);
            storyboard.Begin();
        }

        private void TextAnimation()
        {
            var len = Text.Length;
            var frame = AnimationDuration.TotalSeconds / len;
            for (int i = 0; i < len; i++)
            {
                var keyframe = new DiscreteObjectKeyFrame();
                keyframe.KeyTime = TimeSpan.FromSeconds(frame * i);
                keyframe.Value = Text.Substring(0, i + 1);
                keyframes.KeyFrames.Add(keyframe);
            }

            var tbContent = this.GetTemplateChild("tbContent");

            Storyboard.SetTargetProperty(keyframes, new PropertyPath("Text"));
            Storyboard.SetTarget(keyframes, tbContent);

            storyboard.Children.Add(keyframes);

        }
    }
}
