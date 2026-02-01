using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using DAL.DAO;
namespace PersonelTrackingUser
{
    public partial class FrmPosition : Form
    {
        public FrmPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        List<DEPARTMENT> departmentList = new List<DEPARTMENT>();
        private void btnSave_Click(object sender, EventArgs e)
        {
           if(txtPosition.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill name field");
            }else if(cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department");
            }else
            {
                POSITION position = new POSITION();
                position.PositionName = txtPosition.Text.Trim();
                position.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                BLL.PositionBLL.AddPosition(position);
                txtPosition.Clear();
                cmbDepartment.SelectedIndex = -1;
                MessageBox.Show("Position was added");
            }
        }

        private void FrmPosition_Load(object sender, EventArgs e)
        {
            departmentList = DepartmentBLL.GetDepartments();
            cmbDepartment.DataSource = departmentList;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
        }
    }
}
