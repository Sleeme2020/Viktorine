using Viktorine.Models;

namespace Viktorine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            if (register.ShowDialog() == DialogResult.OK)
            {
                Users users = new()
                {
                    Name = register.textBox1.Text,
                    Login = register.textBox2.Text,
                    Password = register.textBox3.Text
                };
                SingleTon.DB.Users.Add(users);
                SingleTon.DB.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var user = SingleTon.DB.Users.Where(u => u.Login == textBox1.Text && u.Password == textBox2.Text).FirstOrDefault();
            if(user == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

        }
    }
}