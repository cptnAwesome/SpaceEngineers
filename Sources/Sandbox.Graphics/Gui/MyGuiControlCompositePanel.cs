﻿using Sandbox.Common.ObjectBuilders.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;

namespace Sandbox.Graphics.GUI
{
    [MyGuiControlType(typeof(MyObjectBuilder_GuiControlCompositePanel))]
    public class MyGuiControlCompositePanel : MyGuiControlPanel
    {
        public float InnerHeight
        {
            get { return m_innerHeight; }
            set
            {
                m_innerHeight = value;
                RefreshInternals();
            }
        }
        private float m_innerHeight;

        #region Construction
        public MyGuiControlCompositePanel()
        {
            BackgroundTexture = MyGuiConstants.TEXTURE_RECTANGLE_NEUTRAL;
        }

        public override void Init(MyObjectBuilder_GuiControlBase objectBuilder)
        {
            base.Init(objectBuilder);

            var ob = (MyObjectBuilder_GuiControlCompositePanel)objectBuilder;
            InnerHeight = ob.InnerHeight;
        }

        public override MyObjectBuilder_GuiControlBase GetObjectBuilder()
        {
            var ob = (MyObjectBuilder_GuiControlCompositePanel)base.GetObjectBuilder();

            ob.InnerHeight = InnerHeight;
            return ob;
        }
        #endregion

        public override void Draw(float transitionAlpha)
        {
            BackgroundTexture.Draw(GetPositionAbsoluteTopLeft(), Size, ApplyColorMaskModifiers(ColorMask, Enabled, transitionAlpha));
            DrawBorder(transitionAlpha);
        }

        private void RefreshInternals()
        {
            MinSize = BackgroundTexture.MinSizeGui;
            MaxSize = BackgroundTexture.MaxSizeGui;
            Size = new Vector2(Size.X, MinSize.Y + InnerHeight);
        }

    }
}
