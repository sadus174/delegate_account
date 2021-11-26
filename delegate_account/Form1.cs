using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegate_account
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Bank
        {
            // Объявляем делегат
            public delegate void AccountStateHandler(string message);
            // Создаем переменную делегата
            AccountStateHandler _del;

            // Регистрируем делегат
            public void RegisterHandler(AccountStateHandler del)
            {
                _del = del;
            }

            string clientFIO;
            int clientSUM;
            public int ClientSUM { get => clientSUM;}
            public string ClientFIO { get => clientFIO; set => clientFIO = value; }

            public Bank (string fio, int sum)
            {
                clientSUM = sum;
                ClientFIO = fio;
            }

            public void Withdraw(int sum_Withdraw)
            {
                if (sum_Withdraw <= ClientSUM)
                {
                    clientSUM -= sum_Withdraw;

                    if (_del != null)
                        _del($"Сумма {sum_Withdraw} снята со счета");
                }
                else
                {
                    if (_del != null)
                        _del("Недостаточно денег на счете");
                }
            }

            public void Put(int sum_Put)
            {
                clientSUM += sum_Put;
            }
        }
    }
}
