using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
namespace PersonelTrackingUser
{
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtDepartment.Text.Trim()=="")
            {
                MessageBox.Show("Please Fill the name field");
            }else
            {
                DEPARTMENT department = new DEPARTMENT();
                if(!isUpdate)
                {
                    department.DepartmentName = txtDepartment.Text.Trim();
                    BLL.DepartmentBLL.AddDepartment(department);
                    txtDepartment.Clear();
                    MessageBox.Show("New Department Save Success");
                }else
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "warning", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        department.ID = detail.ID;
                        department.DepartmentName = txtDepartment.Text;
                        DepartmentBLL.UpdateDepartment(department);
                        MessageBox.Show("Department was update");
                        this.Close();
                    }
                }
               

            }
           

        }
        public bool isUpdate = false;
        public DEPARTMENT detail = new DEPARTMENT();
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            if(isUpdate)
            {
              
                txtDepartment.Text = detail.DepartmentName;
                
            }
        }
    }
}
