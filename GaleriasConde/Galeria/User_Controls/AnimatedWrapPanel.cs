﻿using Galeria.Other_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Galeria.User_Controls
{
    public class AnimatedWrapPanel : WrapPanel
    {
        private DispatcherTimer animationTimer;
        private DateTime lastArrange = DateTime.MinValue;

        public IArrangeAnimator Animator { get; set; }

        public AnimatedWrapPanel()
            : this(new FractionDistanceAnimator(0.25), TimeSpan.FromSeconds(0.05))
        {
        }

        public AnimatedWrapPanel(IArrangeAnimator animator, TimeSpan animationInterval)
        {
            animationTimer = AnimationBase.CreateAnimationTimer(this, animationInterval);
            Animator = animator;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            finalSize = base.ArrangeOverride(finalSize);

            AnimationBase.Arrange(Math.Max(0, (DateTime.Now - lastArrange).TotalSeconds), this, Children, Animator);
            lastArrange = DateTime.Now;

            return finalSize;
        }
    }
}
