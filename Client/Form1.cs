using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatClient : Form
    {
        private string _NickName;
        private bool _IsLogin = false;

        public delegate void OnLoginSuccess(string nickname);
        public delegate void OnLoginFail();
        public delegate void OnSignUpSuccess();
        public delegate void OnReceiveMessage(string nickname, string content);

        public OnLoginSuccess _OnLoginSuccess;
        public OnLoginFail _OnLoginFail;
        public OnSignUpSuccess _OnSignUpSuccess;
        public OnReceiveMessage _OnReceiveMessage;

        public ChatClient()
        {
            InitializeComponent();

            _OnLoginSuccess = new OnLoginSuccess(ReceiveLoginSuccess);
            _OnLoginFail = new OnLoginFail(ReceiveLoginFail);
            _OnSignUpSuccess = new OnSignUpSuccess(ReceiveSignUpSuccess);
            _OnReceiveMessage = new OnReceiveMessage(ReceiveMessage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AsynchronousClient.StartClient(this);
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            SignUpDialog signUpDialog = new SignUpDialog();
            signUpDialog.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginDialog loginDialog = new LoginDialog();
            loginDialog.Show();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (false == _IsLogin)
                return;

            string packet = $"SendMessagePacket;{_NickName};{InputTextBox.Text};<EOF>";
            AsynchronousClient.Send(AsynchronousClient.GetSocket(), packet);

            InputTextBox.Text = "";
        }

        public void ReceiveMessage(string nickname, string content)
        {
            ChatMessageTextBox.AppendText($"{nickname} : {content}\r\n");
        }

        public void ReceiveLoginSuccess(string nickname)
        {
            _NickName = nickname;
            _IsLogin = true;

            ChatMessageTextBox.Text += "로그인에 성공하였습니다\r\n";
        }

        public void ReceiveLoginFail()
        {
            ChatMessageTextBox.Text += "로그인에 실패하였습니다\r\n";
        }

        public void ReceiveSignUpSuccess()
        {
            ChatMessageTextBox.Text += "회원가입에 성공하였습니다\r\n";
        }
    }
}
