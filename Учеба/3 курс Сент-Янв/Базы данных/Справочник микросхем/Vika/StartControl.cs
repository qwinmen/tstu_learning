using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Vika
{
    public partial class StartControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public StartControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отцентровать плитки по центру окна
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            // Center the panel
            itemPanel1.Location = new Point((this.Width - itemPanel1.Width) / 2 + 16, ((this.Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height + 16);
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
                
                
                appViewTile.Command = newValue.ToggleStartControl;
                devCoTile.Command = newValue.DevComponents;
                
                
                ytdTile.Command = newValue.NotImplemented;
                helpTile.Command = newValue.GettingStartedCommand;
            }
            else
            {
                
                
                appViewTile.Command = null;
                devCoTile.Command = null;
                
                
                ytdTile.Command = null;
                helpTile.Command = null;
            }
        }

        private fConnectInfo _connectInfo = new fConnectInfo();
        /// <summary>
        /// Информация о соединении с базой
        /// </summary>
        private void devCoTile_Click(object sender, EventArgs e)
        {
            _connectInfo.Count(fMain.Count);
            _connectInfo.ShowDialog();
        }

        private FHelp _fHelp = new FHelp();
        /// <summary>
        /// Вызвать окно About
        /// </summary>
        private void helpTile_Click(object sender, EventArgs e)
        {
            _fHelp.ShowDialog();
        }

        /// <summary>
        /// Вход администратора
        /// </summary>
        private void ytdTile_Click(object sender, EventArgs e)
        {
            //проверить подлиность
            fAdminka admin = new fAdminka();
            admin.ShowDialog();

            //установить глобальный флаг в true
            Administrator = admin.StateAdminLogin;
            //Если админ - то сменим иконку Группы пользователей
            pictureBox1.Image = Administrator ? Properties.Resources.root : Properties.Resources.allUser;
            labelX2.Text = Administrator
                               ? "<div align=\"right\"><font size=\"+4\">User</font><br/>admin</div>"
                               : "<div align=\"right\"><font size=\"+4\">User</font><br/>all user</div>";
        }
        /// <summary>
        /// Глобальный флаг админки
        /// </summary>
        public bool Administrator { get; private set; }

        


    }
}
