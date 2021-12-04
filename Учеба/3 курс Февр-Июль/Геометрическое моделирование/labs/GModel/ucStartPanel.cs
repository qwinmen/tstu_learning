using System;
using System.Drawing;

namespace GModel
{
    public partial class ucStartPanel : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public ucStartPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отцентровать плитки по центру окна
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            // Центровать панель с ОКНАМИ
            itemPanel1.Location = new Point((this.Width - itemPanel1.Width) / 2,
                ((this.Height - lblxCorp.Height - 16) - itemPanel1.Height) / 2 + lblxCorp.Height + 16);
            base.OnResize(e);
        }

        private MetroBillCommands _Commands;
        /// <summary>
        /// Gets or sets the commands associated with the control.
        /// </summary>
        public MetroBillCommands Commands
        {
            get { return _Commands; }
            set
            {
                if (value != _Commands)
                {
                    MetroBillCommands oldValue = _Commands;
                    _Commands = value;
                    OnCommandsChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// Реакция на клик по плитке.
        /// Called when Commands property has changed.
        /// </summary>
        /// <param name="oldValue">Old property value</param>
        /// <param name="newValue">New property value</param>
        protected virtual void OnCommandsChanged(MetroBillCommands oldValue, MetroBillCommands newValue)
        {
            if (newValue != null)
            {
                mtiLagranj.Command = newValue.ToggleStartControl;
                mtiBese.Command = newValue.DevComponents;
                mtiArmitt.Command = newValue.NotImplemented;

                mtiBSpline.Command = newValue.GettingStartedCommand;
                mtiPoverxnosti.Command = newValue.Poverxnost;
                mtiNew.Command = newValue.NewMethod;
            }
            else
            {
                mtiLagranj.Command = null;
                mtiBese.Command = null;
                mtiArmitt.Command = null;

                mtiBSpline.Command = null;
                mtiPoverxnosti.Command = null;
                mtiNew.Command = null;
            }
        }


    }
}
