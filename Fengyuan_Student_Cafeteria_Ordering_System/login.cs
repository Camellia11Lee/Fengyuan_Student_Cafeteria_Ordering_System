using System.Data.SqlTypes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Fengyuan_Student_Cafeteria_Ordering_System;

namespace login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "�˺�";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "����";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("�û�������Ϊ�գ�");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }
            if (textBox2.Text == "")

            {
                MessageBox.Show("���벻��Ϊ�գ�");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }

            string userName = textBox1.Text;
            string userPwd = textBox2.Text;

            //***************************************���û�������֤,���������sql������Ϣ********************************************************

            string sql = string.Format("select * from �ò��û� where �˺�='{0}' and ����='{1}' ", userName, userPwd);
            //�����ѯ����

            DataTable user_info = data_work.DataQuery(sql);

            //resultΪ��ѯ����ֵ

            //�˴�����˺ź������Ƿ�Ϊ��



            //�з���ֵ���¼�ɹ���û������ʾ�����

            if (user_info != null)
            {
                string user_id = user_info.Rows[0]["�˺�"].ToString();

                if (user_id != null)
                {
                    Fengyuan_Student_Cafeteria_Ordering_System.user Form2 = new Fengyuan_Student_Cafeteria_Ordering_System.user(user_id);
                    userName = textBox1.Text;
                    userPwd = textBox2.Text;
                    this.Hide();
                    Form2.Show();//��¼�ɹ���ʾ����һ��ҳ��               
                }
                else
                {
                    MessageBox.Show("�û��������������˻������ڡ�", "!��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("�û��������������˻������ڡ�", "!��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        //���ӵ�ע�����
        private void button2_Click(object sender, EventArgs e)
        {
            register form2 = new register();
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //�˴�����Ϊ�˷�����ʾ���Ӷ�����һ�����ٽ����������ݿ�İ�ť

        private void button3_Click(object sender, EventArgs e)
        {
            // ���ӵ�master���ݿ�
            string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // ������ΪPeople�����ݿ�
            string createDatabaseQuery = "CREATE DATABASE People";
            SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseQuery, connection);
            createDatabaseCommand.ExecuteNonQuery();

            // �л����´��������ݿ�
            connection.ChangeDatabase("People");

            // ������Ϊyonghu�ı�
            string createTableQuery = "CREATE TABLE shangjia (���ں� CHAR(15), ������ VARCHAR(50),���� VARCHAR(50))";
            SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
            createTableCommand.ExecuteNonQuery();

            // �л����´��������ݿ�
            connection.ChangeDatabase("People");

            // ������Ϊshangjia�ı�
            string createTableQuery2 = "CREATE TABLE yonghu (��ݱ�� INT, �˺� VARCHAR(30),���� CHAR(50),�ֻ��� char(15),���� VARCHAR(50))";
            SqlCommand createTableCommand2 = new SqlCommand(createTableQuery2, connection);
            createTableCommand2.ExecuteNonQuery();

            // �ر�����
            connection.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        //���ӵ��̼ҵĵ�¼����
        private void button4_Click(object sender, EventArgs e)
        {
            shangjia_login form3 = new shangjia_login();
            form3.ShowDialog();
        }
    }
}
