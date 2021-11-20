using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MailslotDemo_Src
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      //csMailSlot1.Name = "MySlot"; 
      // The Mailslot name can be (and in this case is) set in the designer
      csMailSlot1.Connect("*");
      //All that is needed then is to call .Connect()
    }

    private void csMailSlot1_OnReceivedData(string User, string Command, string Text)
    {
      txtMessages.Text += User + " - " + Text + "\r\n";
      //When a message is received add it to the TextBox
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      csMailSlot1.Close();
      // Close the Mailslot and end the receive thread before exiting
      // This is probably not necessary but good practice
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      csMailSlot1.SendText("User", "Command", txtInput.Text);
      // Send a message out the Mailslot
      txtInput.Clear();
    }

    private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        btnSend_Click(this, e);
      }
    }


  }
}