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

            string userName = textBox1.Text;
            string userPwd = textBox2.Text;
            string connStr = "server=DESKTOP-KP99S2Q;database=People;uid=sa;pwd=200299";
            
            //***************************************���û�������֤,���������sql������Ϣ********************************************************

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "select * from dbo.yonghu where �˺�=@t1 and ����=@t2 ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@t1", SqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@t2", SqlDbType.VarChar).Value = userPwd;

            //�����ѯ����

            object result = cmd.ExecuteScalar();

            //resultΪ��ѯ����ֵ

            //�˴�����˺ź������Ƿ�Ϊ��

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

            //�з���ֵ���¼�ɹ���û������ʾ�����

            if (result != null && result != DBNull.Value)
            {
                int count = Convert.ToInt32(result);
                if (count > 0)
                {
                    progress Form2 = new progress();
                    userName = textBox1.Text;
                    userPwd = textBox2.Text;
                    Form2.Show();//��¼�ɹ���ʾ����һ��ҳ��
                    MessageBox.Show("��ӭ���룡", "��½�ɹ���", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            conn.Close();
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
