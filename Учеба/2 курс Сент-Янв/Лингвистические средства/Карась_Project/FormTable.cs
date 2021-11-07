using System.Windows.Forms;
//LPO-3-Форма Для таблицы Отношений
namespace Карась_Project
{
    public partial class FormTable : Form
    {
        public FormTable()
        {//Это лучше неоткрывать:)8):)
            InitializeComponent();
            #region Отношения
            ListViewItem stroka1 = new ListViewItem("\tИдентиф\t");
            stroka1.SubItems.Add(" ");      stroka1.SubItems.Add("\t=\t"); stroka1.SubItems.Add("\t=\t"); stroka1.SubItems.Add(" ");
            stroka1.SubItems.Add("\t•>\t"); stroka1.SubItems.Add(" ");     stroka1.SubItems.Add("\t=\t"); stroka1.SubItems.Add("\t•>\t");
            stroka1.SubItems.Add("\t=\t");  stroka1.SubItems.Add(" ");     stroka1.SubItems.Add(" ");     stroka1.SubItems.Add("\t=\t");
            stroka1.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka1);

            ListViewItem stroka2 = new ListViewItem("\t=\t");
            stroka2.SubItems.Add("\t<•\t"); stroka2.SubItems.Add(" ");      stroka2.SubItems.Add(" ");
            stroka2.SubItems.Add(" ");      stroka2.SubItems.Add("\t•>\t"); stroka2.SubItems.Add(" ");
            stroka2.SubItems.Add(" ");      stroka2.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka2);

            ListViewItem stroka3 = new ListViewItem("\t+\t");
            stroka3.SubItems.Add(" ");     stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add("\t=\t"); stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add(" ");     stroka3.SubItems.Add(" "); stroka3.SubItems.Add(" ");
            stroka3.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka3);

            ListViewItem stroka4 = new ListViewItem("\tКонст\t");
            stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" ");      stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add(" "); stroka4.SubItems.Add("\t•>\t"); stroka4.SubItems.Add(" ");
            stroka4.SubItems.Add(" "); stroka4.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka4);

            ListViewItem stroka5 = new ListViewItem("\t;\t");
            stroka5.SubItems.Add(" ");      stroka5.SubItems.Add(" ");     stroka5.SubItems.Add(" ");
            stroka5.SubItems.Add(" ");      stroka5.SubItems.Add("\t=\t"); stroka5.SubItems.Add("\t<•\t");
            stroka5.SubItems.Add(" ");      stroka5.SubItems.Add(" ");     stroka5.SubItems.Add(" ");
            stroka5.SubItems.Add("\t<•\t"); stroka5.SubItems.Add(" ");     stroka5.SubItems.Add(" ");
            stroka5.SubItems.Add("\t<•\t");
            listViewTablVosxod.Items.Add(stroka5);

            ListViewItem stroka6 = new ListViewItem("\tif\t");
            stroka6.SubItems.Add("\t<•\t"); stroka6.SubItems.Add(" ");      stroka6.SubItems.Add(" "); 
            stroka6.SubItems.Add(" ");      stroka6.SubItems.Add(" ");      stroka6.SubItems.Add(" "); 
            stroka6.SubItems.Add(" ");      stroka6.SubItems.Add("\t=\t");  stroka6.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka6);

            ListViewItem stroka7 = new ListViewItem("\t>\t");
            stroka7.SubItems.Add("\t=\t"); stroka7.SubItems.Add(" "); stroka7.SubItems.Add(" ");
            stroka7.SubItems.Add(" ");     stroka7.SubItems.Add(" "); stroka7.SubItems.Add(" "); 
            listViewTablVosxod.Items.Add(stroka7);

            ListViewItem stroka8 = new ListViewItem("\tthen do\t");
            stroka8.SubItems.Add("\t<•\t"); stroka8.SubItems.Add(" ");      stroka8.SubItems.Add(" ");
            stroka8.SubItems.Add(" ");      stroka8.SubItems.Add("\t•>\t"); stroka8.SubItems.Add(" ");
            stroka8.SubItems.Add(" ");      stroka8.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka8);

            ListViewItem stroka9 = new ListViewItem("\t/\t");
            stroka9.SubItems.Add("\t=\t"); stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" ");
            stroka9.SubItems.Add(" ");     stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" ");
            stroka9.SubItems.Add(" ");     stroka9.SubItems.Add(" "); stroka9.SubItems.Add(" ");
            stroka9.SubItems.Add(" "); 
            listViewTablVosxod.Items.Add(stroka9);

            ListViewItem stroka10 = new ListViewItem("\tPut Data\t");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" "); stroka10.SubItems.Add(" ");
            stroka10.SubItems.Add(" "); stroka10.SubItems.Add("\t=\t");
            listViewTablVosxod.Items.Add(stroka10);

            ListViewItem stroka11 = new ListViewItem("\t(\t");
            stroka11.SubItems.Add("\t=\t"); stroka11.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka11);

            ListViewItem stroka12 = new ListViewItem("\t)\t");
            stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" ");
            stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" ");
            stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" ");
            stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" "); stroka12.SubItems.Add(" "); 
            stroka12.SubItems.Add("\t•>\t");
            listViewTablVosxod.Items.Add(stroka12);

            ListViewItem stroka13 = new ListViewItem("\tend\t");
            stroka13.SubItems.Add(" "); stroka13.SubItems.Add(" ");      stroka13.SubItems.Add(" ");
            stroka13.SubItems.Add(" "); stroka13.SubItems.Add("\t•>\t"); stroka13.SubItems.Add(" ");
            listViewTablVosxod.Items.Add(stroka13);
            #endregion
        }
    }
}
