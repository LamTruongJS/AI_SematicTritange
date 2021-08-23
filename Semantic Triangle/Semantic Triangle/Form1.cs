/* 
 * University of Information Technology - VNU 
 * Create by:  Lâm Thanh Cường
 * Class: CNTN03
 * Student ID:  08520526
 * Email:  thanhcuong1990@gmail.com
 * website:  http://thanhcuong.wordpress.com/
 * 
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Semantic_Triangle
{
    public partial class triangle : Form
    {

        #region Decleration
       
        // Khai báo biến.
        private float[,] a = new float[8, 5];  // khai báo mảng chứa 8 thuộc tính: 3 góc, 3 cạnh, diện tích, chiều cao và 5 công thức tính của tam giác trong trường hợp bài toán này.
        private const double pi = 3.1415926535897931;   // Khai bao pi
        private const float angle = 180f;               // Tong 3 goc trong tam giac.
        private const float pif = 3.141592f;
       


        public triangle()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            init();
        }
        
        // Form load
        private void triangle_Load(object sender, EventArgs e)
        {
            cbb_value.SelectedItem = cbb_value.Items[0];
        }

        #endregion


        #region init

        // Khởi tạo các giá trị cho mảng biểu diễn mạng ngữ nghĩa ban đầu.
        //  http://www.uit.edu.vn/data/gtrinh/TH112/Htm/Chuong_02_10.htm
        private void init()
        {
            float temp = -1;     // Bien tam
            for (int i = 0; i < 8; i++ )
            {
                for (int j = 0; j < 5; j++ )
                {
                    a[i, j] = 0;
                }
            }
                        
            a[0, 0] = a[1, 0] = a[3, 0] = a[4, 0] = temp;
            a[1, 1] = a[2, 1] = a[4, 1] = a[5, 1] = temp;
            a[3, 2] = a[4, 2] = a[5, 2] = a[6, 2] = temp;
            a[0, 3] = a[1, 3] = a[2, 3] = temp;
            a[5, 4] = a[6, 4] = a[7, 4] = temp;
        }

#endregion

        
        #region Process


        private bool FindSuccess()
        {
            try
            {
                switch (cbb_value.SelectedIndex)
                {
                    case 1:
                        if (a[0, 0] == -1)
                        {
                            break;
                        }
                        return true;
                    case 2:
                        if (a[1, 0] == -1)
                        {
                            break;
                        }
                        return true;
                    case 3:
                        if (a[2, 1] == -1)
                        {
                            break;
                        }
                        return true;
                    case 4:
                        if (a[3, 0] == -1)
                        {
                            break;
                        }
                        return true;
                    case 5:
                        if (a[4, 0] == -1)
                        {
                            break;
                        }
                        return true;
                    case 6:
                        if (a[5, 1] == -1)
                        {
                            break;
                        }
                        return true;
                    case 7:
                        if (a[6, 2] == -1)
                        {
                            break;
                        }
                        return true;
                    case 8:
                        if (a[7, 4] == -1)
                        {
                            break;
                        }
                        return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi trả về là: \n " + ex.Message.ToString(), "Lỗi....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        // Lấy vị trí yếu tố chưa biết.
        private int GetElementNotKnow(int k)
        {
            try
            {
                int counter = 0;
                int number = -1;
                for (int i = 0; i < 8; i++)
                {
                    if (a[i, k] == -1)
                    {
                        counter++;
                        number = i;
                    }
                }
                if (counter == 1)
                {
                    return number;
                }
                return -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi trả về là:\n " + ex.Message.ToString(), "Lỗi thực thi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Kích hoạt theo cơ chế lan truyền.
        private void spreadingActivation(int j, int ElementNotKnow)
        {
            try
            {
                float value = -1;                
                switch (j)
                {
                    case 0:
                        switch (ElementNotKnow)
                        {
                            case 0:
                                value = (float)(((Math.Asin((a[3, 0] * Math.Sin(a[1, 0])) / (a[4, 0])) * angle) / pi));                                
                                txt_alpha.Text = value.ToString();
                                break;
                            case 1:
                                value = (float)((Math.Asin((a[4, 0] * Math.Sin(a[0, 0])) / (a[3, 0])) * angle) / pi);
                                txt_beta.Text = value.ToString();
                                break;

                            case 3:
                                value = (float)((a[4, 0] * Math.Sin(a[0, 0])) / Math.Sin(a[1, 0]));
                                txt_a.Text = value.ToString();
                                break;

                            case 4:
                                value = (float)((a[3, 0] * Math.Sin(a[1, 0])) / Math.Sin(a[0, 0]));
                                txt_b.Text = value.ToString();
                                break;
                        }
                        break;

                    case 1:
                        switch (ElementNotKnow)
                        {
                            case 1:
                                value = (float)((Math.Asin((a[4, 0] * Math.Sin(a[2, 1])) / (a[5, 1])) * 180.0) / pi);
                                txt_beta.Text = value.ToString();
                                break;

                            case 2:
                                value = (float)((Math.Asin((a[5, 1] * Math.Sin(a[1, 0])) / (a[4, 0])) * 180.0) / pi);
                                txt_deta.Text = value.ToString();
                                break;

                            case 4:
                                value = (float)((a[5, 1] * Math.Sin(a[1, 0])) / Math.Sin(a[2, 1]));
                                txt_b.Text = value.ToString();
                                break;

                            case 5:
                                value = (float)((a[4, 0] * Math.Sin(a[2, 1])) / Math.Sin(a[1, 0]));
                                txt_c.Text = value.ToString();
                                break;
                        }
                        break;

                    case 2:
                        float temp1;
                        float temp2;
                        float temp3;
                        float num5;
                        switch (ElementNotKnow)
                        {
                            case 3:
                                temp1 = (float)Math.Pow((double)a[4, 0], 2.0);
                                temp2 = (float)Math.Pow((double)a[5, 1], 2.0);
                                temp3 = (float)Math.Pow((double)a[6, 2], 2.0);
                                value = (float)Math.Sqrt((temp1 + temp2) + Math.Sqrt((double)((temp1 * temp2) - (4 * temp3))));
                                txt_a.Text = value.ToString();
                                break;

                            case 4:
                                num5 = (float)Math.Pow((double)a[3, 0], 2.0);
                                temp2 = (float)Math.Pow((double)a[5, 1], 2.0);
                                temp3 = (float)Math.Pow((double)a[6, 2], 2.0);
                                value = (float)Math.Sqrt((num5 + temp2) + Math.Sqrt((double)((num5 * temp2) - (4 * temp3))));
                                txt_b.Text = value.ToString();
                                break;

                            case 5:
                                num5 = (float)Math.Pow((double)a[3, 0], 2.0);
                                temp1 = (float)Math.Pow((double)a[4, 0], 2.0);
                                temp3 = (float)Math.Pow((double)a[6, 2], 2.0);
                                value = (float)Math.Sqrt((num5 + temp1) + Math.Sqrt((double)((num5 * temp1) - (4 * temp3))));
                                txt_c.Text = value.ToString();
                                break;

                            case 6:
                                {
                                    float num6 = ((a[3, 0] + a[4, 0]) + a[5, 1]) / 2;
                                    value = (float)Math.Sqrt((double)(((num6 * (num6 - a[3, 0])) * (num6 - a[4, 0])) * (num6 - a[5, 1])));
                                    txt_s.Text = value.ToString();
                                    break;
                                }
                        }
                        break;

                    case 3:
                        switch (ElementNotKnow)
                        {
                            case 0:
                                value = (float)((((pi - a[1, 0]) - a[2, 1]) * angle) / pi);
                                txt_alpha.Text = value.ToString();
                                break;

                            case 1:
                                value = (float)((((pi - a[0, 0]) - a[2, 1]) * angle) / pi);
                                txt_beta.Text = value.ToString();
                                break;

                            case 2:
                                value = (float)((((pi - a[0, 0]) - a[1, 0]) * angle) / pi);
                                txt_deta.Text = value.ToString();
                                break;
                        }
                        break;

                    case 4:
                        switch (ElementNotKnow)
                        {
                            case 5:
                                value = (2f * a[6, 2]) / a[7, 4];
                                txt_c.Text = value.ToString();
                                break;

                            case 6:
                                value = (a[7, 4] * a[5, 1]) / 2f;
                                txt_s.Text = value.ToString();
                                break;

                            case 7:
                                value = (2f * a[6, 2]) / a[5, 1];
                                txt_h.Text = value.ToString();
                                break;
                        }
                        break;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (this.a[ElementNotKnow, i] == -1f)
                    {
                        this.a[ElementNotKnow, i] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trả về là:\n " + ex.Message.ToString(), "Lỗi thực thi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // Kích hoạt yếu tố chưa biết.
        private void activationElementKnow()
        {
            try
            {
                int temp;
                if (!string.IsNullOrEmpty(txt_alpha.Text))
                {
                    float num = (pif * float.Parse(txt_alpha.Text)) / angle;
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[0, temp] == -1f)
                        {
                            this.a[0, temp] = num;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_beta.Text))
                {
                    float num3 = (pif * float.Parse(txt_beta.Text)) / angle;
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[1, temp] == -1f)
                        {
                            this.a[1, temp] = num3;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_deta.Text))
                {
                    float num4 = (pif * float.Parse(txt_deta.Text)) / angle;
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[2, temp] == -1f)
                        {
                            this.a[2, temp] = num4;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_a.Text))
                {
                    float num5 = float.Parse(txt_a.Text);
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[3, temp] == -1f)
                        {
                            this.a[3, temp] = num5;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_b.Text))
                {
                    float num6 = float.Parse(txt_b.Text);
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[4, temp] == -1f)
                        {
                            this.a[4, temp] = num6;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_c.Text))
                {
                    float num7 = float.Parse(txt_c.Text);
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[5, temp] == -1f)
                        {
                            this.a[5, temp] = num7;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_s.Text))
                {
                    float num8 = float.Parse(txt_s.Text);
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[6, temp] == -1f)
                        {
                            this.a[6, temp] = num8;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(txt_h.Text))
                {
                    float num9 = float.Parse(txt_h.Text);
                    for (temp = 0; temp < 5; temp++)
                    {
                        if (this.a[7, temp] == -1f)
                        {
                            this.a[7, temp] = num9;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trả về là:\n " + ex.Message.ToString(), "Lỗi thực thi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý 
        private void Solution()
        {
            try
            {            
                activationElementKnow();
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    for(int i = 0; i < 5; i++)
                    {
                        int elementNotKnow = GetElementNotKnow(i);
                        if (elementNotKnow != -1)
                        {
                            spreadingActivation(i, elementNotKnow);
                            flag = true;
                            if (FindSuccess())
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }
                if (!FindSuccess())
                {
                    MessageBox.Show("Không thể tìm ra  " + cbb_value.SelectedItem.ToString() + " trên mạng ngữ nghĩa đã xây dựng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi trả về là: \n" + ex.Message.ToString(), "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
#endregion


        #region Event button

        // Xử lý nút Bắt đầu tính toán
        private void btn_startCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_value.SelectedItem == cbb_value.Items[0])
                {
                    MessageBox.Show("Bạn Chưa chọn Giá trị cần tính. \n Vui lòng chọn một giá trị cần tính rồi mới nhấn Bắt Đầu tính!", "Cảnh báo từ chương trình!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    Solution();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Bạn đã thực hiện 1 thao tác lỗi, Lỗi trả về là: \n" + ex.Message.ToString() + "\n  Nhấn OK để quay lại chương trình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        // Xử lý khi nhấn nút làm lại.
        private void btn_restart_Click(object sender, EventArgs e)
        {
            txt_alpha.Text = txt_beta.Text = txt_deta.Text = string.Empty;
            txt_a.Text = txt_b.Text = txt_c.Text = string.Empty;
            txt_h.Text = txt_s.Text = string.Empty;
            init();            
        }

        // Xử lý sự kiện khi ấn nút help.
        private void btn_help_Click(object sender, EventArgs e)
        {
            string notice = " Nhập các giá trị thuộc tính của tam giác ở các ô màu vàng tương ứng      với giá trị.";
            string notice1 = "\n Chọn Giá trị cần tính ở combobox.";
            string notice2 = "\n Nhấn Bắt đầu tính và xem kết quả ở ô màu vàng mà bạn muốn xem.";
            string notice3 = "\n Nhấn Nút Làm bài khác để nhập một bài toán mới để xử lý.";
            string notice4 = "\n\n Nếu có vấn đề gì về chương trình hãy liên hệ tác giả\n\tEmail:   thanhcuong1990@gmail.com ";
            
            MessageBox.Show(notice + notice1 + notice2 + notice3 + notice4, "Trợ giúp sử dụng chương trình!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

#endregion


        #region  Only Enter Number to textbox

        // Chi cho phep nhap so vao textbox.
        private void txt_alpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void txt_beta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void txt_deta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void txt_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void txt_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void txt_h_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void txt_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void txt_s_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

#endregion

       
    }
}
