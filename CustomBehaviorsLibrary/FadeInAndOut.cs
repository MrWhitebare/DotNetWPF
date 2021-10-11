using System;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace CustomBehaviorsLibrary
{
    public class FadeOutAction:TargetedTriggerAction<UIElement>
    {
        //默认淡出(fade out)时间2s
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            "Duration",typeof(TimeSpan),typeof(FadeOutAction),new PropertyMetadata(TimeSpan.FromSeconds(2)));

        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(FadeOutAction.DurationProperty); }
            set { SetValue(FadeOutAction.DurationProperty, value); }
        }

        //淡出动画时间线
        private Storyboard fadeStoryboard = new Storyboard();
        //淡出动画
        private DoubleAnimation fadeAnimation = new DoubleAnimation();

        public FadeOutAction()
        {
            fadeStoryboard.Children.Add(fadeAnimation);
        }

        protected override void Invoke(object parameter)
        {
            fadeStoryboard.Stop();

            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("Opacity"));
            Storyboard.SetTarget(fadeAnimation, this.Target);

            fadeAnimation.To = 0;
            fadeAnimation.Duration = Duration;
            fadeStoryboard.Begin();
        }
    }

    public class FadeInAction : TargetedTriggerAction<UIElement>
    {
        //默认淡入时间0.5秒
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration",
            typeof(TimeSpan), typeof(FadeInAction), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));

        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(FadeInAction.DurationProperty); }
            set { SetValue(FadeInAction.DurationProperty, value); }
        }

        private Storyboard fadeStoryboard = new Storyboard();
        private DoubleAnimation fadeAnimation = new DoubleAnimation();

        public FadeInAction()
        {
            fadeStoryboard.Children.Add(fadeAnimation);
        }

        protected override void Invoke(object parameter)
        {
            // Make sure the storyboard isn't already running.
            fadeStoryboard.Stop();

            // Set up the storyboard.                        
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("Opacity"));
            Storyboard.SetTarget(fadeAnimation, this.Target);

            // Set up the animation.            
            fadeAnimation.To = 1;
            fadeAnimation.Duration = Duration;

            fadeStoryboard.Begin();
        }
    }


}
