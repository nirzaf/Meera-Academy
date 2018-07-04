using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Meera_Academy.DS;
using Excel = Microsoft.Office.Interop.Excel;


namespace Meera_Academy
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        DS.User_DS.USERSELECTDataTable UserDT = new User_DS.USERSELECTDataTable();
        DS.User_DSTableAdapters.USERSELECTTableAdapter UserAdapter = new Meera_Academy.DS.User_DSTableAdapters.USERSELECTTableAdapter();

        DS.Student_DS.STUDENTSELECTDataTable StuDT = new Student_DS.STUDENTSELECTDataTable();
        DS.Student_DSTableAdapters.STUDENTSELECTTableAdapter StuAdapt = new Meera_Academy.DS.Student_DSTableAdapters.STUDENTSELECTTableAdapter();

        DS.Student_DS.COURSESELECTDataTable CourseDT = new Student_DS.COURSESELECTDataTable();
        DS.Student_DSTableAdapters.COURSESELECTTableAdapter CourseAdapter = new Meera_Academy.DS.Student_DSTableAdapters.COURSESELECTTableAdapter();

        DS.Student_DS.STUDENTSEARCHDataTable SearchDT = new Student_DS.STUDENTSEARCHDataTable();
        DS.Student_DSTableAdapters.STUDENTSEARCHTableAdapter SearchAdapter = new Meera_Academy.DS.Student_DSTableAdapters.STUDENTSEARCHTableAdapter();

        DS.Student_DS.STUDENTSELECTBYIDDataTable IDDT = new Student_DS.STUDENTSELECTBYIDDataTable();
        DS.Student_DSTableAdapters.STUDENTSELECTBYIDTableAdapter IDAdapter = new Meera_Academy.DS.Student_DSTableAdapters.STUDENTSELECTBYIDTableAdapter();

        DS.Student_DS.TEACHERSELECTDataTable TeaDT = new Student_DS.TEACHERSELECTDataTable();
        DS.Student_DSTableAdapters.TEACHERSELECTTableAdapter TeaAdapter = new Meera_Academy.DS.Student_DSTableAdapters.TEACHERSELECTTableAdapter();

        public int userid;
       public string uname;
        private void gplogin_Enter(object sender, EventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            int blank = 0;
            if (txtname.Text == "")
            {
                lblnamee.Visible = true;
                blank = 1;
            }
            else { lblnamee.Visible = false; }
            if (txtsurname.Text == "")
            {
                lblsurnamee.Visible = true;
                blank = 1;
            }
            else {
                lblsurnamee.Visible = false;
            }
            if (txtemail.Text == "")
            {
                lblemaile.Visible = true;
                blank = 1;
            }
            else 
            {
                lblemaile.Visible = false;
            }

            if (txtemail.Text.Contains("@") && txtemail.Text.Contains("."))
            {
                lblemaile.Visible = false;
            }
            else
            {
                lblemaile.Visible = true;
                blank = 1;
            }
            if (txtcontact.Text == "")
            {
                lblmoe.Visible = true;
                blank = 1;
            }
            else
            {
                lblmoe.Visible = false;
            }

            if (blank == 0)
            {
                lblmoe.Visible = false;
                lblemaile.Visible = false;
                lblnamee.Visible = false;
                lblsurnamee.Visible = false;
//gpcourse.Visible = true;
                Drpyear.SelectedItem = 0;
                gpcourse.Enabled = true;
                CourseDT = CourseAdapter.SelectCourse();
                cmbcourse.DataSource = CourseDT;
                cmbcourse.DisplayMember = "CourseName";
                cmbcourse.ValueMember = "Coursefees";
                cmbcourse.Text = "SELECT";

                TeaDT = TeaAdapter.select();
                cmbteacher.DataSource = TeaDT;
                cmbteacher.DisplayMember = "TeacherName";
                cmbteacher.ValueMember = "ID";
                cmbteacher.Text = "SELECT";

                txtfees.Text = "";
            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
        }
        }

     
        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_DS.USERSELECT' table. You can move, or remove it, as needed.
           // this.uSERSELECTTableAdapter.Select(this.user_DS.USERSELECT);
            // TODO: This line of code loads data into the 'student_DS.TEACHERSELECT' table. You can move, or remove it, as needed.
            //this.tEACHERSELECTTableAdapter.select();
            //DS.student_DSTEACHERSELECT.Select();
            // TODO: This line of code loads data into the 'student_DS.TEACHERSELECT' table. You can move, or remove it, as needed.
            //this.tEACHERSELECTTableAdapter.select(this.student_DS.TEACHERSELECT);
            //lbltime.Text = System.DateTime.Now.TimeOfDay.ToString(); ;
            lblsec.Text = System.DateTime.Now.ToString();
            label72.Text = System.DateTime.Now.DayOfWeek.ToString();
       }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try{
                
            if (txtusername.Text == "")
            {
                MessageBox.Show("Please, Enter UserName !!", "Meera Academy");
            
            }
            else if (txtpassword.Text == "")
            {
                MessageBox.Show("Please, Enter Password !!", "Meera Academy");

            }
            else
            {
                int user = 0;
                UserDT = UserAdapter.Select();
                for (int i = 0; i < UserDT.Rows.Count; i++)
                {
                    byte[] bb = Convert.FromBase64String(UserDT.Rows[i]["Password"].ToString());
                    string getpass = System.Text.ASCIIEncoding.ASCII.GetString(bb);


                    if (txtusername.Text == UserDT.Rows[i]["UserName"].ToString() && txtpassword.Text == getpass.ToString())
                    {

                        userid =Convert.ToInt32(UserDT.Rows[i]["ID"].ToString());
                         uname = UserDT.Rows[i]["UserName"].ToString();
                        user = 1;
                    }
                }

                if (user == 0)
                {
                    MessageBox.Show("Invalid Username or Password !!", "Meera Academy");
                }
                else
                {
                    MessageBox.Show("Welcome to Meera Academy.", " Meera Academy");
                    lbldisplay.Text = "Welcome " + uname;
                    lbldisplay.Visible = true;
                    //lblmeera.Visible = false;
                    txtusername.Text = "";
                    txtpassword.Text = "";
                    gplogin.Visible = false;
                    btnlogout.Visible = true;
                    pnllogo.Visible = true;
                }

            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
        }
        }

        
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 0;
            studentclear();
            //CourseDT = CourseAdapter.SelectCourse();
            //cmbcourse.DataSource = CourseDT;
            //cmbcourse.DisplayMember = "CourseName";
            //cmbcourse.ValueMember = "Coursefees";
            //cmbcourse.Text = "SELECT";
            //groupBox2.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tbstudent.Visible = true;
            btnedit.Visible = false;
            lblfees.Text = "";
            tbstudent.SelectedIndex = 2;
             lblfeeerror.Text ="";
             gpupdatefees.Visible = false;
             txtfeeid.Text = "";
             txtfeeadd.Text = "";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                dgstudent.DataSource = null;
                dgfess.DataSource = null;
                dgfess.Visible = false;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 1;
                CourseDT = CourseAdapter.SelectCourse();
                cmbscoure.DataSource = CourseDT;
                cmbscoure.DisplayMember = "CourseName";
                cmbscoure.ValueMember = "Coursefees";
                cmbscoure.Text = "SELECT";

                TeaDT = TeaAdapter.select();
                cmmtach.DataSource = TeaDT;
                cmmtach.DisplayMember = "TeacherName";
                cmmtach.ValueMember = "ID";
                cmmtach.Text = "SELECT";

                txtsname.Text = "";
                lblrecord.Text = "";
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        
        }



        private void pictureBox6_Click(object sender, EventArgs e)
        {

            lblcourse.Text = ""; 
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 3;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 4;
                CourseDT = CourseAdapter.SelectCourse();
                dgcourse.DataSource = CourseDT;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        }

      

        private void btnlogout_Click(object sender, EventArgs e)
        {
            lbldisplay.Visible = false;
            lbldisplay.Text = "";
            gplogin.Visible = true;
            tbstudent.Visible = false;
            pnllogo.Visible = false;
            btnlogout.Visible = false;
            //lblmeera.Visible = true;
        }

      

        private void btnfeeview_Click(object sender, EventArgs e)
        {
            try
            {
                txtfeepaid.ReadOnly = true;
                btnedit.Visible = false;
                txtfeename.ReadOnly = true;
                txtfeesure.ReadOnly= true;
                txtfeemobile.ReadOnly = true;
                txtfeemail.ReadOnly = true;
                lblfees.Text = "";
                if (txtfeeid.Text != "")
                {
                    IDDT = IDAdapter.SelectByID(Convert.ToInt32(txtfeeid.Text));
                    if (IDDT.Rows.Count > 0)
                    {
                        MessageBox.Show("Student Name is " + IDDT.Rows[0]["Studentname"].ToString() + " " + IDDT.Rows[0]["surename"].ToString(), "Meera Academy");
                    
                        txtfeename.Text = IDDT.Rows[0]["Studentname"].ToString();
                        txtfeesure.Text = IDDT.Rows[0]["surename"].ToString();
                        txtfeemobile.Text = IDDT.Rows[0]["contactno"].ToString();
                        txtfeemail.Text = IDDT.Rows[0]["email"].ToString();
                        txtfeefees.Text = IDDT.Rows[0]["fees"].ToString();
                        txtfeepaid.Text = IDDT.Rows[0]["feespaid"].ToString();
                        txtfeerem.Text = IDDT.Rows[0]["feesrem"].ToString();
                        cmbfeecollege.Text = IDDT.Rows[0]["college"].ToString();
                        cmbfeecourse.Text = IDDT.Rows[0]["course"].ToString();
                        gpupdatefees.Visible = true;
                        lblfeeerror.Text = "";
                        btnedit.Visible = true;
                    }
                    else {

                        MessageBox.Show("Wrong Student ID", "Meera Academy");
                        lblfeeerror.Text = "";
                        gpupdatefees.Visible = false;
                        txtfeeid.Text = "";
                        txtfeeadd.Text = "";
                    }



                }
                else
                {
                    lblfeeerror.Text = "Please, Enter Student ID. !!";
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        }

        private void btnfeeupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfeeadd.Text != "")
                {


                    IDDT = IDAdapter.SelectByID(Convert.ToInt32(txtfeeid.Text));
                    //int feepaid = Convert.ToInt32(IDDT.Rows[0]["feespaid"].ToString()) + Convert.ToInt32(txtfeeadd.Text);
                    int feepaid = Convert.ToInt32(txtfeepaid.Text) + Convert.ToInt32(txtfeeadd.Text);

                    if (feepaid > Convert.ToInt32(txtfeefees.Text))
                    {
                        MessageBox.Show("Error !!, Pais Fees is never more then Total Course Fees", "Meera Academy");
                    }
                    else
                    {
                        int feerem = Convert.ToInt32(IDDT.Rows[0]["fees"].ToString()) - feepaid;
                        int update = StuAdapt.Update(Convert.ToInt32(txtfeeid.Text), txtfeename.Text, txtfeesure.Text, txtfeemobile.Text, txtfeemail.Text, txtfeefees.Text, feepaid.ToString(), feerem.ToString());

                        if (update == 1)
                        {
                            //lblfees.Text = "Fees Updated Successfully.!!";
                            MessageBox.Show("Fees Updatd Successfully.!!", "Meera Academy");
                            txtfeepaid.ReadOnly = true;
                            txtfeeadd.Text = "";
                            txtfeename.Text = "";
                            txtfeesure.Text = "";
                            txtfeemobile.Text = "";
                            txtfeemail.Text = "";
                            txtfeefees.Text = "";
                            txtfeepaid.Text = "";
                            txtfeerem.Text = "";
                            cmbfeecollege.Text = "SELECT";

                            cmbfeecourse.Text = "SELECT";
                            gpupdatefees.Visible = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please, Insert Fees", "Meera Academy");
                
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            txtfeename.ReadOnly = false;
            txtfeemail.ReadOnly=false;
            txtfeesure.ReadOnly = false;
            txtfeepaid.ReadOnly = false;
            //txtfeefees.ReadOnly = false;
            //txtfeerem.ReadOnly = false;
            //txtfeepaid.ReadOnly = false;
            txtfeemobile.ReadOnly = false;
           // cmbfeecollege.Enabled = true;
           // cmbfeecourse.Enabled = true;
        }

        public void studentclear()
        {
            try
            {
                txtname.Text = "";
                txtsurname.Text = "";
                txtaddress.Text = "";
                txtpin.Text = "";
                txtcontact.Text = "";
                gpcourse.Enabled = false;
                txtemail.Text = "";
                //cmbcourse.SelectedIndex = 0;
                cmbcollege.SelectedIndex = 0;
                txtfees.Text = "";
                txtcontact.Text = "";
                //cmbteacher.SelectedIndex = 0;
               // gpcourse.Visible = false;
                lblstudentmsg.Text = "";
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfees.Text == "")
                {
                    MessageBox.Show("Please, Check your Course Fees.", "Meera Academy");
                }
                else
                {
                    int ins = StuAdapt.Insert(txtname.Text, txtsurname.Text, txtaddress.Text, txtpin.Text, txtcontact.Text, txtemail.Text, cmbcollege.Text, cmbcourse.Text, txtfees.Text, "0", txtfees.Text, cmbteacher.Text,txtproject.Text ,Drpyear.Text, datestart.Value.Date, dateend.Value.Date);

                    if (ins == 1)
                    {
                        studentclear();
                        lblstudentmsg.Text = "Student Added Successfully !!";
                        MessageBox.Show("Student Added Successfully !!", "Meera Academy");
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbcourse.Text == "SELECT")
                {
                    txtfees.Text = "";
                }
                else
                {
                    txtfees.Text = cmbcourse.SelectedValue.ToString();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblrecord.Text = "";
                dgstudent.DataSource = null;
                dgstudent.Visible = true;
                dgfess.DataSource = null;
                dgfess.Visible = false;
                if (cmbscoure.Text == "SELECT")
                {
                    cmbscoure.Text = "";
                }
                if (cmbsfees.Text == "SELECT")
                {
                    cmbsfees.Text = "";
                }

                if (cmmtach.Text == "SELECT")
                {

                    SearchDT = SearchAdapter.select(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text,cmbyear.Text);
                    dgstudent.DataSource = SearchDT;
                }
                else
                {

                    DS.Student_DS.STUDENTSEARCHBY_TEACHERDataTable TDT = new Student_DS.STUDENTSEARCHBY_TEACHERDataTable();
                    DS.Student_DSTableAdapters.STUDENTSEARCHBY_TEACHERTableAdapter TAdapter = new Meera_Academy.DS.Student_DSTableAdapters.STUDENTSEARCHBY_TEACHERTableAdapter();
                    TDT = TAdapter.select(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text, cmmtach.Text, cmbyear.Text);
                    dgstudent.DataSource = TDT;
                }

                lblrecord.Text = "Record = " + dgstudent.RowCount.ToString();

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtsname.Text = "";
            cmbscoure.Text = "SELECT";
            cmbsfees.Text = "SELECT";
            cmmtach.Text = "SELECT";
            dgstudent.DataSource = null;
            lblrecord.Text = "";
        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcoursename.Text == "")
                {
                    lblcnamee.Visible = true;
                    lblcourse.Text = "";

                }
                else if (txtcoursefees.Text == "")
                {
                    lblcpricee.Visible = true;
                    lblcourse.Text = "";
                }
                else if (cmbduration.Text == "SELECT")
                {
                    lblduration.Visible = true;
                    lblcourse.Text = "";
                }
                else
                {
                    lblcnamee.Visible = false;
                    lblcpricee.Visible = false;
                    lblduration.Visible = false;
                    lblcourse.Text = "";
                    int ins = CourseAdapter.Insert(txtcoursename.Text, txtcoursefees.Text, cmbduration.Text);
                    if (ins == 1)
                    {
                        lblcourse.Text = "Course Added Successfully.";
                        MessageBox.Show("Course Added Successfully. !!", "Meera Academy");
                        txtcoursename.Text = "";
                        txtcoursefees.Text = "";
                        cmbduration.SelectedIndex = 0;
                    }

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
            
        }

        private void tbstudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbstudent.SelectedIndex == 0)
                {
                    tbstudent.Visible = true;
                    //tbstudent.SelectedIndex = 0;
                    studentclear();
                    CourseDT = CourseAdapter.SelectCourse();
                    cmbcourse.DataSource = CourseDT;
                    cmbcourse.DisplayMember = "CourseName";
                    cmbcourse.ValueMember = "Coursefees";
                    cmbcourse.SelectedIndex = 0;
                }
                else if (tbstudent.SelectedIndex == 1)
                {
                    tbstudent.Visible = true;
                    dgstudent.DataSource = null;
                    dgfess.DataSource = null;
                    dgfess.Visible = false;
                    //tbstudent.SelectedIndex = 1;
                    CourseDT = CourseAdapter.SelectCourse();
                    cmbscoure.DataSource = CourseDT;
                    cmbscoure.DisplayMember = "CourseName";
                    cmbscoure.ValueMember = "Coursefees";
                    cmbscoure.Text = "SELECT";


                    TeaDT = TeaAdapter.select();
                    cmmtach.DataSource = TeaDT;
                    cmmtach.DisplayMember = "TeacherName";
                    cmmtach.ValueMember = "ID";
                    cmmtach.Text = "SELECT";
                    txtsname.Text = "";
                    lblrecord.Text = "";
                }
                else if (tbstudent.SelectedIndex == 2)
                {
                    tbstudent.Visible = true;
                    lblfees.Text = "";
                    //tbstudent.SelectedIndex = 2;
                    lblfeeerror.Text = "";
                    gpupdatefees.Visible = false;
                    txtfeeid.Text = "";
                    txtfeeadd.Text = "";
                    btnedit.Visible = false;
  
                }
                else if (tbstudent.SelectedIndex == 3)
                {
                    lblcourse.Text = "";
                    tbstudent.Visible = true;
                    // tbstudent.SelectedIndex = 3;
                }
                else if (tbstudent.SelectedIndex == 4)
                {
                    tbstudent.Visible = true;
                    // tbstudent.SelectedIndex = 4;
                    CourseDT = CourseAdapter.SelectCourse();
                    dgcourse.DataSource = CourseDT;

                }
                else if (tbstudent.SelectedIndex == 5)
                {

                }
                else if (tbstudent.SelectedIndex == 6)
                {
                    dgteacher.DataSource = null;
                    TeaDT = TeaAdapter.select();
                    dgteacher.DataSource = TeaDT;
                }
                else if (tbstudent.SelectedIndex == 7)
                {
                    lblerror.Text = "";

                    if (userid == 1 || userid == 2)
                    {
                        tbadmin.Visible = true;
                        lblerror.Visible = false;
                        lblerror.Text = "";
                        txtsid.Text = "";
                        dgstu.Visible = false;
                        dgstu.DataSource = null;
                        btndel.Visible = false;

                    }
                    else
                    {
                        tbadmin.Visible = false;
                        lblerror.Visible = true;
                        lblerror.Text = "Sorry !!, You are unable to get this faclity !!";

                    }
                    
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open Image Files";
            //fDialog.Filter = "JPEG Files|*.jpeg|GIF Files|*.gif";
            fDialog.InitialDirectory = @"C:\";
            
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fDialog.FileName.ToString());
                //richTextBox1.SaveFile(fDialog.FileName,RichTextBoxStreamType.
               // txtimg.Text = fDialog.FileName;
               
            }
        }

        private void btnteacher_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtteacher.Text == "")
                {
                    MessageBox.Show("Please, Entet Teacher Name", "Meera Academy");
                }
                else
                {

                    int ins = TeaAdapter.Insert(txtteacher.Text, txtquli.Text, txtsubject.Text);

                    if (ins == 1)
                    {
                        MessageBox.Show("Teacher Added Successfully", "Meera Academy");
                        txtteacher.Text = "";
                        txtsubject.Text = "";
                        txtquli.Text = "";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbstudent.Visible = true;
            tbstudent.SelectedIndex = 5;
            txtteacher.Text = "";
            txtsubject.Text = "";
            txtquli.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                dgteacher.DataSource = null;
                tbstudent.Visible = true;
                tbstudent.SelectedIndex = 6;

                TeaDT = TeaAdapter.select();
                dgteacher.DataSource = TeaDT;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error!!  Meera Academy");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            lblsec.Text = System.DateTime.Now.ToString();
          

        }

       

        private void btnseachfees_Click(object sender, EventArgs e)
        {
            try
            {
                lblrecord.Text = "";
                dgstudent.DataSource = null;
                dgstudent.Visible = false;
                dgfess.DataSource = null;
                dgfess.Visible = true;
                if (cmbscoure.Text == "SELECT")
                {
                    cmbscoure.Text = "";
                }
                if (cmbsfees.Text == "SELECT")
                {
                    cmbsfees.Text = "";
                }

                if (cmmtach.Text == "SELECT")
                {
                    DS.Student_DS.STUDENTSEARCHBYFEESDataTable FDT = new Student_DS.STUDENTSEARCHBYFEESDataTable();
                    DS.Student_DSTableAdapters.STUDENTSEARCHBYFEESTableAdapter FAdapter = new Meera_Academy.DS.Student_DSTableAdapters.STUDENTSEARCHBYFEESTableAdapter();

                    FDT = FAdapter.selectfees(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text, cmbyear.Text);
                    dgfess.DataSource = FDT;
                }
                else
                {

                    //DS.Student_DS.STUDENTSEARCHBY_TEACHERDataTable TDT = new Student_DS.STUDENTSEARCHBY_TEACHERDataTable();
                    //DS.Student_DSTableAdapters.STUDENTSEARCHBY_TEACHERTableAdapter TAdapter = new Meera_Academy.DS.Student_DSTableAdapters.STUDENTSEARCHBY_TEACHERTableAdapter();
                    //TDT = TAdapter.select(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text, cmmtach.Text);
                    DS.Student_DS.STUDENTSEARCHBYFEESDataTable TDT = new Student_DS.STUDENTSEARCHBYFEESDataTable();
                    DS.Student_DSTableAdapters.STUDENTSEARCHBYFEESTableAdapter TAdapter = new Meera_Academy.DS.Student_DSTableAdapters.STUDENTSEARCHBYFEESTableAdapter();
                    TDT = TAdapter.selectfeesTeacher(txtsname.Text + '%', cmbscoure.Text, cmbsfees.Text, cmmtach.Text, cmbyear.Text);
                    dgfess.DataSource = TDT;
                }

                lblrecord.Text = "Record = " + dgfess.RowCount.ToString();

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void txtfeepaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int fee = Convert.ToInt32(txtfeefees.Text) - Convert.ToInt32(txtfeepaid.Text);
                txtfeerem.Text = Convert.ToString(fee);
            }
            catch(Exception a)
            { 
           
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtauser.Text == "")
                {
                    MessageBox.Show("UserName cant't be blank!!", " Meera Academy");
                }
                else if (txtapass.Text == "")
                {
                    MessageBox.Show("Password can't be blank !!", " Meera Academy");
                }
                else
                {

                    byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(txtapass.Text);
                    string encryptedConnectionString = Convert.ToBase64String(b);
                  
                   // byte[] bb = Convert.FromBase64String(encryptedConnectionString);
                  //  string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(bb);


                    int m = UserAdapter.Insert(txtauser.Text, encryptedConnectionString.ToString());

                    if (m == 1)
                    {

                        MessageBox.Show("User Added Successfully. !!", " Meera Academy");
                        txtauser.Text = "";
                        UserDT = UserAdapter.Select();
                        cmbuser.DataSource = UserDT;
                        cmbuser.DisplayMember = "UserName";
                        cmbuser.ValueMember = "ID";
                        txtapass.Text = "";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lblpass.Visible = false;
            btnnewpass.Visible = false;
            txtchangepassword.Visible = false;
            try
            {
                if (Convert.ToInt16(cmbuser.SelectedValue) == 1 || Convert.ToInt16(cmbuser.SelectedValue) == 2)
                {
                    MessageBox.Show("You can't Delete this User. !!", "Meera Academy");
                }
                else
                {
                    int a = UserAdapter.Delete(Convert.ToInt16(cmbuser.SelectedValue));

                    if (a == 1)
                    {
                        MessageBox.Show("User Deleted Successfully. !!", "Meera Academy");
                        UserDT = UserAdapter.Select();
                        cmbuser.DataSource = UserDT;
                        cmbuser.DisplayMember = "UserName";
                        cmbuser.ValueMember = "ID";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }

        }

        private void tbadmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (tbadmin.SelectedIndex == 0)
                {
                    dgstu.Visible = false;
                    btndel.Visible = false;
                    txtsid.Text = "";
                   
                    dgstu.DataSource = null;
                   
                }
                else if (tbadmin.SelectedIndex == 1)
                {
                    gpteacher.Visible = false;
                    txtateacherid.Text = "";
                    txtateachname.Text = "";
                    txtaqulif.Text = "";
                    txtasubject.Text = "";
                }
                else if (tbadmin.SelectedIndex == 2)
                {
                    gpupdatecourse.Visible = false;
                    txtcid.Text = "";
                    txtcname.Text = "";
                    txtcfees.Text = "";
                    cmbcduration.SelectedIndex = 0;

                }
                else if (tbadmin.SelectedIndex == 3)
                {
                    txtauser.Text = "";
                    txtapass.Text = "";
                    UserDT = UserAdapter.Select();
                    cmbuser.DataSource = UserDT;
                    cmbuser.DisplayMember = "UserName";
                    cmbuser.ValueMember = "ID";

                    lblpass.Visible = false;
                    btnnewpass.Visible = false;
                    txtchangepassword.Visible = false;

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtateacherid.Text == "")
                {
                    MessageBox.Show("Please Enter Teacher ID", " Meera Academy");

                }
                else
                {
                    TeaDT = TeaAdapter.SelectTeabyID(Convert.ToInt16(txtateacherid.Text));
                    if (TeaDT.Rows.Count > 0)
                    {
                        gpteacher.Visible = true;
                        txtateachname.Text = TeaDT.Rows[0]["TeacherName"].ToString();
                        txtasubject.Text = TeaDT.Rows[0]["Subject"].ToString();
                        txtaqulif.Text = TeaDT.Rows[0]["Qulification"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Teacher ID", "Meera Academy");
                        gpteacher.Visible = false;
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !! Meera Academy");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtateachname.Text == "")
                {
                    MessageBox.Show("Teacher Name can't be blank", " Meera Academy");

                }
                else if (txtasubject.Text == "")
                {
                    MessageBox.Show("Subject Can't be blank", " Meera Academy");
                }
                else if (txtaqulif.Text == "")
                {
                    MessageBox.Show("Qulification field can't be blank", " Meera Academy");
                }
                else
                {
                    int u = TeaAdapter.Update(Convert.ToInt32(txtateacherid.Text), txtateachname.Text, txtaqulif.Text, txtasubject.Text);
                    if (u == 1)
                    {
                        MessageBox.Show("Teacher Detail Updated Successfully. !!", "Meera Academy");
                        gpteacher.Visible = false;
                        txtateachname.Text = "";
                        txtaqulif.Text = "";
                        txtasubject.Text = "";
                        txtateacherid.Text = "";
                    }

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;
                if (dgfess.Visible == true)
                {
                    for (i = 0; i <= dgfess.RowCount - 1; i++)
                    {
                        for (j = 0; j <= dgfess.ColumnCount - 1; j++)
                        {
                            DataGridViewCell cell = dgfess[j, i];
                            xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                        }
                    }
                    xlWorkBook.SaveAs("StudentFees.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    MessageBox.Show("Excel file created , you can find the file 'StudentFees.xls' in My Document", " Meera Academy");

                }
                else if (dgstudent.Visible == true)
                {
                    for (i = 0; i <= dgstudent.RowCount - 1; i++)
                    {
                        for (j = 0; j <= dgstudent.ColumnCount - 1; j++)
                        {
                            DataGridViewCell cell = dgstudent[j, i];
                            xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                        }
                    }

                    xlWorkBook.SaveAs("studentDetail.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    MessageBox.Show("Excel file created , you can find the file 'StudentDetail.xls' in My Document", " Meera Academy");

                }


                // releaseObject(xlWorkSheet);
                // releaseObject(xlWorkBook);
                //releaseObject(xlApp);

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }   
        

            
        }

        private void button15_Click(object sender, EventArgs e)
        {try{
            if (txtcid.Text == "")
            {
                MessageBox.Show("Please, Enter Course ID", "Meera Academy");
            }
            else
            {
                CourseDT = CourseAdapter.SelectCoursebyID(Convert.ToInt32(txtcid.Text));
                if (CourseDT.Rows.Count > 0)
                {
                    gpupdatecourse.Visible = true;
                    txtcname.Text = CourseDT.Rows[0]["Coursename"].ToString();
                    txtcfees.Text = CourseDT.Rows[0]["CourseFees"].ToString();
                   cmbcduration.SelectedItem= CourseDT.Rows[0]["Duration"].ToString();

                }
                else
                {
                    MessageBox.Show("Invalid Course ID", " Meera Academy");
                }
            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error !!");
        }
        }

        private void button14_Click(object sender, EventArgs e)
        {try{
            if (txtcname.Text == "")
            {
                MessageBox.Show("Course Name can't be blank", " Meera Academy");

            }
            else if (txtcfees.Text == "")
            {
                MessageBox.Show("Course Fees Can't be blank", " Meera Academy");
            }
            else
            {
                int u = CourseAdapter.Update(Convert.ToInt32(txtcid.Text), txtcname.Text, txtcfees.Text, cmbcduration.SelectedItem.ToString());
                if (u == 1)
                {
                    MessageBox.Show("Course Detail Updated Successfully. !!", "Meera Academy");
                    gpupdatecourse.Visible = false;
                    txtcname.Text = "";
                    txtcfees.Text = "";
                    txtcid.Text = "";
                }

            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error !!");
        }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try{
            if (txtsid.Text == "")
            {
                MessageBox.Show("Please, Enter Student ID", "Meera Academy");
            }
            else
            {
                IDDT = IDAdapter.SelectByID(Convert.ToInt32(txtsid.Text));
                if (IDDT.Rows.Count > 0)
                {
                    dgstu.DataSource = IDDT;
                    dgstu.Visible = true;
                    btndel.Visible = true;

                }
                else
                {
                    MessageBox.Show("Invalid User ID", "Meera Academy");
                    dgstu.Visible = false;
                    btndel.Visible = false;
                }
            }
        }
        catch (Exception a)
        {
            MessageBox.Show(a.Message.ToString(), "Error !!");
        }
        
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure !! you want to Delete this student", "Meera Academy", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int DEL = StuAdapt.Delete(Convert.ToInt32(txtsid.Text));
                    if (DEL == 1)
                    {
                        MessageBox.Show("Student Deleted Successfully. !!", "Meera Academy");
                        dgstu.Visible = false;
                        dgstu.DataSource = null;
                        btndel.Visible = false;
                        txtsid.Text = "";
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Error !!");
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            IDDT = IDAdapter.SelectByID(Convert.ToInt32(cmbuser.SelectedValue));
            lblpass.Visible = true;
            btnnewpass.Visible = true;
            txtchangepassword.Text = "";
            txtchangepassword.Visible = true;
        }

        private void btnnewpass_Click(object sender, EventArgs e)
        {
            if (txtchangepassword.Text == "")
            {
                MessageBox.Show("Please, Enter New Password", " Meera Academy");
            }
            else
            {
                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(txtchangepassword.Text);
                string newpass = Convert.ToBase64String(b);

                int u = UserAdapter.Update(Convert.ToInt32(cmbuser.SelectedValue), newpass.ToString());
                if (u == 1)
                {
                    MessageBox.Show("Password changed successfully. !!", " Meera Academy");
                    lblpass.Visible = false;
                    btnnewpass.Visible = false;
                    txtchangepassword.Text = "";
                    txtchangepassword.Visible = false;
                }
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    
    }
}