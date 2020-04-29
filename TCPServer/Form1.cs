using SimpleTcp;
using System;
using System.Text;
using System.Windows.Forms;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Globale variabele
        TcpServer tcpServer;
        private void ButtonServer_Click(object sender, EventArgs e)
        {
            //Server starten die luistert op poort 9000
            tcpServer = new TcpServer("0.0.0.0", 9000, false, "", "");
            //Eventhandler toevoegen die getriggerd wordt als een client data stuurt.
            tcpServer.DataReceived += TcpServer_DataReceived; 
            //De server starten.
            tcpServer.Start();
        }

        private void TcpServer_DataReceived(object sender, DataReceivedFromClientEventArgs e)
        {
            //Data omzetten naar leesbare tekst.
            string data = Encoding.UTF8.GetString(e.Data);
            //ENTER weg
            data = data.Trim(); 

            //Actie ondernemen als de data een bepaalde waarde heeft.
            if(data.Equals("abc", StringComparison.OrdinalIgnoreCase))
            {

            }

            //Data tonen in textbox.
            textBoxLog.Invoke((MethodInvoker)delegate {
                //Op de GUI thread.
                textBoxLog.AppendText(data);
                textBoxLog.AppendText(Environment.NewLine);
            });
        }

    }
}
