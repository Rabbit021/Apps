﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Interactivity;

namespace Behavior.BehaviorLib
{
    public class TextBoxGetFocusBahavior : TargetedTriggerAction<TextBox>
    {
        public void GotFocus()
        {

        }

        protected override void Invoke(object parameter)
        {
            TextBox targetTextBox = Target;
            targetTextBox.SelectAll();
        }
    }
}
