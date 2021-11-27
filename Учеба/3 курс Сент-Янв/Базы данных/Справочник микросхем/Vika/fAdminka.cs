using System.Drawing;
using System.Windows.Forms;

namespace Vika
{
    public partial class fAdminka : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public fAdminka()
        {
            InitializeComponent();
            
            lblLoginTrye.BackColor = Color.Red;
            lblPasswdTrye.BackColor = Color.Red;
        }

        private bool _adm;
        private bool _pas;

        /// <summary>
        /// Разрешить Администрировать
        /// </summary>
        internal bool StateAdminLogin { get; private set; }

        private void txtBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {//Агримся на нажатие Enter с условием активности ХешТабл окна
                //-----------------ввод----------------------------//
                string text = txtBoxLogin.Text;
                _adm = text == "root";
            } //В text будет писаться все от начала до конца\ перезаписывая предыдущие\

            lblLoginTrye.BackColor = _adm ? Color.LawnGreen : Color.Red;
        }

        private void txtBoxPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {//Агримся на нажатие Enter с условием активности ХешТабл окна
                //-----------------ввод----------------------------//
                string text = txtBoxPasswd.Text;
                _pas = text == "root";
            } //В text будет писаться все от начала до конца\ перезаписывая предыдущие\

            lblPasswdTrye.BackColor = _pas ? Color.LawnGreen : Color.Red;
        }

        /// <summary>
        /// Перед закрытием формы проверим актуальность токена
        /// </summary>
        private void fAdminka_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(_adm && _pas) StateAdminLogin = true;
            else StateAdminLogin = false;
        }
    }
}
