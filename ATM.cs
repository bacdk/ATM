using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ATM
{
    public partial class ATM : Form
    {
        public ATM()
        {
            InitializeComponent();
            DocDuLieuATM();
            Step1();
            
        }

        //Declare
        //
        int step;
        String passWord = "";

        //Card
        bool isDKB = false;
        bool isKD = false;

        //Khách hàng
        String tenChuTK = "";
        String matKhau = "";
        Int32 soDu = 0;
        String fileName = "";
        Int32 soTienRut = 0;
        String matKhauMoi = "";

        //ATM
        Int32 soTienTrongATM = 0;
        int soTo500K = 0;
        int soTo200K = 0;
        int soTo100K = 0;
        int soTo50K = 0;
        bool atmHetTien = false;

        //Keyboard
        int kbValue = -1;

        //Cash
        int soTo500 = 0;
        int soTo200 = 0;
        int soTo100 = 0;
        int soTo50 = 0;
        //
        int soTo500Con = 0;
        int soTo200Con = 0;
        int soTo100Con = 0;
        int soTo50Con = 0;

        //FixCash
        int sT500 = 0;
        int sT200 = 0;
        int sT100 = 0;
        int sT50 = 0;

        //Func
        //Kiểm tra số tiền nhập vào
        bool KiemTraSoTienNhap(String soTien)
        {
            Int32 so = 0;
            bool laSo = Int32.TryParse(soTien, out so);
            if (laSo == true)
            {
                if(so % 50000 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }


        //Hàm cho xuất ngược
        /*
        //Hàm tính số tờ 200 còn thiếu để cộng lại đủ chia cho 500
        int TinhSoTo200Can(int soTo)
        {
            int k = 1;
            for (int i = 1; i < 5; i++)
            {
                if ((soTo + i) % 5 == 0)
                {
                    k = i;
                    break;
                }
            }
            return k;
        }

        //Tính số tờ có mệnh giá thấp hơn khi chuyển xuống.
        void FixCash(Int32 soTien, String bacTien)
        {
            //
            sT500 = 0;
            sT200 = 0;
            sT100 = 0;
            sT50 = 0;
            //
            if (bacTien == "sT50")
            {
                sT100 = soTien / 100000; 
            }
            else if (bacTien == "sT100")
            {
                sT200 = soTien / 200000;
            }
            else if (bacTien == "sT200")
            {
                sT500 = soTien / 500000;
            }
            else
            {
                atmHetTien = true;
            }
            
            //
            soTo500 += sT500;
            soTo200 += sT200;
            soTo100 += sT100;
            soTo50 += sT50;
        }

        //Kiểm tra có đủ số tờ mệnh giá đó để trả không. Nếu không đủ chuyển xuống mệnh giá thấp hơn.
        void FixCashEnough()
        {
            //

            //
            if (soTo50 > soTo50K)
            {
                if ((soTo50 - soTo50K) % 2 != 0)
                {
                    FixCash(50000 * (soTo50 - soTo50K + 1), "sT50");
                    soTo50 = soTo50K - 1;
                    soTo50Con = soTo50K - soTo50;
                }
                else
                {
                    FixCash(50000 * (soTo50 - soTo50K), "sT50");
                    soTo50 = soTo50K;
                }
            }
            //
            if (soTo100 > soTo100K)
            {
                if ((soTo100  - soTo100K) % 2 != 0)
                {
                    FixCash(100000 * (soTo100 - soTo100K + 1), "sT100");
                    soTo100 = soTo100K - 1;
                    soTo100Con = soTo100K - soTo100;
                }
                else
                {
                    FixCash(100000 * (soTo100 - soTo100K), "sT100");
                    soTo100 = soTo100K;
                }
                
            }
            //
            if (soTo200 > soTo200K)
            {
                if ((soTo200 - soTo200K) % 5 != 0)
                {
                    FixCash(200000 * (soTo200 - soTo200K + TinhSoTo200Can(soTo200 - soTo200K)), "sT200");
                    soTo200 = soTo200K - TinhSoTo200Can(soTo200 - soTo200K);
                    soTo200Con = soTo200K - soTo200;
                }
                else
                {
                    FixCash(200000 * (soTo200 - soTo200K), "sT200");
                    soTo200 = soTo200K;
                }
            }
            if (soTo500 > soTo500K)
            {
                if (500000 * (soTo500 - soTo500K) == soTo200Con * 200000 + soTo100Con * 100000 + soTo50Con * 50000)
                {
                    soTo500 = soTo500K;
                    soTo200 += soTo200Con;
                    soTo100 += soTo100Con;
                    soTo50 += soTo50Con;
                }
                else
                {
                    atmHetTien = true;
                }
            }
        }

        //Tham lam, tính số tờ tiền trả cho khách hàng theo mệnh giá
        void Cash(Int32 soTien)
        {
            //
            //Cash
            soTo500 = 0;
            soTo200 = 0;
            soTo100 = 0;
            soTo50 = 0;

            //FixCash
            sT500 = 0;
            sT200 = 0;
            sT100 = 0;
            sT50 = 0;

            //     
            soTo50 = soTien / 50000;
            soTo100 = 0;
            soTo200 = 0;
            soTo500 = 0;

            //
            FixCashEnough();
        }

        */

        //Hàm cho xuất cao xuống
        //Tính số tờ có mệnh giá thấp hơn khi chuyển xuống.
        void FixCash(Int32 soTien, String bacTien)
        {
            //
            sT500 = 0;
            sT200 = 0;
            sT100 = 0;
            sT50 = 0;
            //
            if (bacTien == "sT500")
            {
                sT200 = soTien / 200000;
                sT100 = (soTien - (sT200 * 200000)) / 100000;
                sT50 = (soTien - (sT200 * 200000) - (sT100 * 100000)) / 50000;
            }
            else if (bacTien == "sT200")
            {
                sT100 = soTien / 100000;
                sT50 = (soTien - (sT100 * 100000)) / 50000;
            }
            else if (bacTien == "sT100")
            {
                sT50 = soTien / 50000;
            }
            //
            soTo500 += sT500;
            soTo200 += sT200;
            soTo100 += sT100;
            soTo50 += sT50;
        }

        //Kiểm tra có đủ số tờ mệnh giá đó để trả không. Nếu không đủ chuyển xuống mệnh giá thấp hơn.
        void FixCashEnough()
        {
            if (soTo500 > soTo500K)
            {
                FixCash(500000 * (soTo500 - soTo500K), "sT500");
                soTo500 = soTo500K;
            }
            if (soTo200 > soTo200K)
            {
                FixCash(200000 * (soTo200 - soTo200K), "sT200");
                soTo200 = soTo200K;
            }
            if (soTo100 > soTo100K)
            {
                FixCash(100000 * (soTo100 - soTo100K), "sT100");
                soTo100 = soTo100K;
            }
            if (soTo50 > soTo50K)
            {
                atmHetTien = true;
            }
        }

        //Tham lam, tính số tờ tiền trả cho khách hàng theo mệnh giá
        void Cash(Int32 soTien)
        {
            //
            //Cash
            soTo500 = 0;
            soTo200 = 0;
            soTo100 = 0;
            soTo50 = 0;

            //FixCash
            sT500 = 0;
            sT200 = 0;
            sT100 = 0;
            sT50 = 0;

            //
            soTo500 = soTien / 500000;
            soTo200 = (soTien - (soTo500 * 500000)) / 200000;
            soTo100 = (soTien - (soTo500 * 500000) - (soTo200 * 200000)) / 100000;
            soTo50 = (soTien - (soTo500 * 500000) - (soTo200 * 200000) - (soTo100 * 100000)) / 50000;

            //
            FixCashEnough();
        }

        //Trừ tờ tiền
        void TruToTien()
        {
            soTo500K -= soTo500;
            soTo200K -= soTo200;
            soTo100K -= soTo100;
            soTo50K -= soTo50;
        }
        
        //Đọc dữ liệu ATM
        void DocDuLieuATM()
        {
            FileStream fs = new FileStream("ATM.txt", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            //StreamWriter wd = new StreamWriter(fs, Encoding.UTF8);

            soTienTrongATM = Convert.ToInt32(rd.ReadLine());

            soTo500K = Convert.ToInt32(rd.ReadLine());
            soTo200K = Convert.ToInt32(rd.ReadLine());
            soTo100K = Convert.ToInt32(rd.ReadLine());
            soTo50K  = Convert.ToInt32(rd.ReadLine());

            fs.Close();
        }

        //Cap Nhat du lieu ATM
        void GhiDuLieuATM(Int32 soTienTrongATM, int soTo500K, int soTo200K, int soTo100K, int soTo50K)
        {
            FileStream fs = new FileStream("ATM.txt", FileMode.Open);
            StreamWriter wd = new StreamWriter(fs, Encoding.UTF8);

            wd.WriteLine(soTienTrongATM);
            wd.WriteLine(soTo500K);
            wd.WriteLine(soTo200K);
            wd.WriteLine(soTo100K);
            wd.WriteLine(soTo50K);

            wd.Flush();
            fs.Close();
        }

        //Đọc dữ liệu khách hàng
        void DocDuLieuKhachHang(String name)
        {
            FileStream fs = new FileStream(name, FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);

            tenChuTK = Convert.ToString(rd.ReadLine());
            matKhau = Convert.ToString(rd.ReadLine());
            soDu = Convert.ToInt32(rd.ReadLine());

           
            fs.Close();
        }

        //Ghi Du Lieu Khach hang
        void GhiDuLieuKhachHang(String name ,String tenChuTK, String matKhau, Int32 soDu)
        {
            FileStream fs = new FileStream(name, FileMode.Open);
            StreamWriter wd = new StreamWriter(fs, Encoding.UTF8);

            wd.WriteLine(tenChuTK);
            wd.WriteLine(matKhau);
            wd.WriteLine(soDu);

            wd.Flush();
            fs.Close();
        }

        //
        void Keyboard()
        {
            //Nhập số tiên rút
            if (step == 325)
            {
                txtNhapTien.Text += kbValue.ToString();
            }

            //Nhập lại mật khẩu mới
            if(step == 3411)
            {
                if (txtMatKhau.Text.ToString().Length < 6)
                {
                    txtMatKhau.Text += kbValue.ToString();
                }
            }
            //Nhập mật khẩu mới
            if (step == 341)
            {
                if (txtMatKhau.Text.ToString().Length < 6)
                {
                    txtMatKhau.Text += kbValue.ToString();
                }
                
            }
            //Nhập mật khẩu cũ
            if (step == 34)
            {
                txtMatKhau.Text += kbValue.ToString();
            }
            
            //Nhập mật khẩu
            if (step == 2)
            {
                if (passWord.Length < 6)
                {
                    passWord += kbValue.ToString();
                    if (passWord.Length == 0)
                    {
                        this.lbPassword.Text = "******";
                    }
                    if (passWord.Length == 1)
                    {
                        this.lbPassword.Text = "X*****";
                    }
                    if (passWord.Length == 2)
                    {
                        this.lbPassword.Text = "XX****";
                    }
                    if (passWord.Length == 3)
                    {
                        this.lbPassword.Text = "XXX***";
                    }
                    if (passWord.Length == 4)
                    {
                        this.lbPassword.Text = "XXXX**";
                    }
                    if (passWord.Length == 5)
                    {
                        this.lbPassword.Text = "XXXXX*";
                    }
                    if (passWord.Length == 6)
                    {
                        this.lbPassword.Text = "XXXXXX";
                    } 
                }
            }
            
        }

        //
        void ClearBillCash()
        {
            lbBillGio.Text = "Giờ :";
            lbBillNgay.Text = "Ngày :";
            lbBillSoDu.Text = "Số dư :";
            lbBillSoTienRut.Text = "Số tiền rút :";
            lbBillTenTK.Text = "Tên Chủ TK :";
            lbBillCamOn.Text = "Trân trọng cảm ơn!!!";
            //
            lbCash500.Text = "Số tờ 500K :";
            lbCash200.Text = "Số tờ 200K :";
            lbCash100.Text = "Số tờ 100K :";
            lbCash50.Text =  "Số tờ 50K  :";
        }

        //
        void DisableAll()
        {
            //
            lb1.Hide();
            lb2.Hide();
            lb3.Hide();
            lb4.Hide();
            lb5.Hide();
            lb6.Hide();
            //
            lbCash500.Hide();
            lbCash200.Hide();
            lbCash100.Hide();
            lbCash50.Hide();
            //
            lbWelcome.Hide();
            lbNhapMatKhau.Hide();
            lbChuTK.Hide();
            lbPassword.Hide();
            lbTextSoDu.Hide();
            lbHoiKT.Hide();
            lbInsertCard.Hide();
            //
            lbBillCamOn.Hide();
            lbBillGio.Hide();
            lbBillNgay.Hide();
            lbBillSoDu.Hide();
            lbBillSoTienRut.Hide();
            lbBillTenTK.Hide();
            //
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            //
            btnNum0.Enabled = false;
            btnNum1.Enabled = false;
            btnNum2.Enabled = false;
            btnNum3.Enabled = false;
            btnNum4.Enabled = false;
            btnNum5.Enabled = false;
            btnNum6.Enabled = false;
            btnNum7.Enabled = false;
            btnNum8.Enabled = false;
            btnNum9.Enabled = false;
            btnNumCancel.Enabled = false;
            btnNumClear.Enabled = false;
            btnNumEnter.Enabled = false;
            //
            btnOpps1.Enabled = false;
            btnOpps2.Enabled = false;
            btnOpps3.Enabled = false;
            //
            txtNhapTien.Hide();
            txtMatKhau.Hide();
            lbNote.Hide();
        }

        //
        void Step1()
        {
            step = 1;
            //
            DisableAll();
            //
            lb1.Hide();
            lb2.Hide();
            lb3.Hide();
            lb4.Hide();
            lb5.Hide();
            lb6.Hide();
            //
            lbCash500.Hide();
            lbCash200.Hide();
            lbCash100.Hide();
            lbCash50.Hide();
            //
            lbWelcome.Hide();
            lbNhapMatKhau.Hide();
            lbChuTK.Hide();
            lbPassword.Hide();
            lbTextSoDu.Hide();
            lbHoiKT.Hide();
            lbInsertCard.Show();
            //
            lbBillCamOn.Hide();
            lbBillGio.Hide();
            lbBillNgay.Hide();
            lbBillSoDu.Hide();
            lbBillSoTienRut.Hide();
            lbBillTenTK.Hide();
            //
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            //
            btnNum0.Enabled = false;
            btnNum1.Enabled = false;
            btnNum2.Enabled = false;
            btnNum3.Enabled = false;
            btnNum4.Enabled = false;
            btnNum5.Enabled = false;
            btnNum6.Enabled = false;
            btnNum7.Enabled = false;
            btnNum8.Enabled = false;
            btnNum9.Enabled = false;
            btnNumCancel.Enabled = false;
            btnNumClear.Enabled = false;
            btnNumEnter.Enabled = false;
            //
            btnOpps1.Enabled = false;
            btnOpps2.Enabled = false;
            btnOpps3.Enabled = false;
            //
            lbInsertCard.Text = "Vui lòng cho thẻ vào...";

        }

        //
        void Step2()
        {
            step = 2;
            //
            DisableAll();
            //
            btnNum0.Enabled = true;
            btnNum1.Enabled = true;
            btnNum2.Enabled = true;
            btnNum3.Enabled = true;
            btnNum4.Enabled = true;
            btnNum5.Enabled = true;
            btnNum6.Enabled = true;
            btnNum7.Enabled = true;
            btnNum8.Enabled = true;
            btnNum9.Enabled = true;
            btnNumCancel.Enabled = true;
            btnNumClear.Enabled = true;
            btnNumEnter.Enabled = true;
            //
            btnCardDKB.Enabled = false;
            btnCardKD.Enabled = false;
            //
            lbWelcome.Show();
            lbChuTK.Show();
            lbNhapMatKhau.Show();
            lbPassword.Show();
            lbTextSoDu.Hide();
            lbHoiKT.Hide();
            //
            lbInsertCard.Hide();
        }

        //
        void Step3()
        {
            step = 3;
            //
            DisableAll();
            //
            lb1.Show();
            lb2.Show();
            lb3.Hide();
            lb4.Show();
            lb5.Show();
            lb6.Hide();
            //
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = false;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = false;
            //
            btnNum0.Enabled = false;
            btnNum1.Enabled = false;
            btnNum2.Enabled = false;
            btnNum3.Enabled = false;
            btnNum4.Enabled = false;
            btnNum5.Enabled = false;
            btnNum6.Enabled = false;
            btnNum7.Enabled = false;
            btnNum8.Enabled = false;
            btnNum9.Enabled = false;
            btnNumCancel.Enabled = false;
            btnNumClear.Enabled = false;
            btnNumEnter.Enabled = false;
            //
            lbNhapMatKhau.Hide();
            lbPassword.Hide();
            lbTextSoDu.Hide();
            lbHoiKT.Hide();
            //
            lb1.Text = "Xem Số Dư";
            lb2.Text = "Rút Tiền";
            lb4.Text = "Đổi PIN";
            lb5.Text = "DV Khác";
        }

        //
        void Step31()
        {
            step = 31;
            //
            DisableAll();
            //
            lb1.Hide();
            lb2.Hide();
            lb3.Hide();
            lb4.Hide();
            lb5.Hide();
            lb6.Hide();
            //
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = true;
            btn6.Enabled = true;
            //
            lb5.Show();
            lb6.Show();
            //
            lbTextSoDu.Show();
            lbHoiKT.Show();
            //
            lbTextSoDu.Text = "Số dư tài khoản của bạn là: "+ soDu +" VND";
            lb5.Text = "Có";
            lb6.Text = "Không";
        }

        //
        void Step32()
        {
            step = 32;
            //
            DisableAll();
            //
            lb1.Show();
            lb2.Show();
            lb3.Show();
            lb4.Show();
            lb5.Show();
            lb6.Show();
            //
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            //
            lbWelcome.Show();
            lbChuTK.Show();
            //
            lb1.Text = "4000000";
            lb2.Text = "2000000";
            lb3.Text = "1000000";
            lb4.Text = "500000";
            lb5.Text = "Nhập tay";
            lb6.Text = "Cancel";

        }
        
        //
        void Step321()
        {
            //
            step = 321;
            //
            DisableAll();
            //
            lbBillCamOn.Show();
            lbBillGio.Show();
            lbBillNgay.Show();
            lbBillSoDu.Show();
            lbBillSoTienRut.Show();
            lbBillTenTK.Show();
            //
            lbCash500.Show();
            lbCash200.Show();
            lbCash100.Show();
            lbCash50.Show();
            //
            lbTextSoDu.Show();
            //
            lbBillTenTK.Text += tenChuTK;
            lbBillSoTienRut.Text += soTienRut;
            lbBillSoDu.Text += soDu;
            lbBillNgay.Text += " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            lbBillGio.Text += " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            //
            lbCash500.Text += soTo500.ToString();
            lbCash200.Text += soTo200.ToString();
            lbCash100.Text += soTo100.ToString();
            lbCash50.Text += soTo50.ToString();
            //
            lbTextSoDu.Text = "Vui lòng nhận tiền, hóa đơn và nhận lại thẻ!!!";
        }

        //
        void Step322()
        {
            //
            step = 322;
            //
            DisableAll();
            //
            lbBillCamOn.Show();
            lbBillGio.Show();
            lbBillNgay.Show();
            lbBillSoDu.Show();
            lbBillSoTienRut.Show();
            lbBillTenTK.Show();
            //
            lbCash500.Show();
            lbCash200.Show();
            lbCash100.Show();
            lbCash50.Show();
            //
            lbTextSoDu.Show();
            //
            lbBillTenTK.Text += tenChuTK;
            lbBillSoTienRut.Text += soTienRut;
            lbBillSoDu.Text += soDu;
            lbBillNgay.Text += " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            lbBillGio.Text += " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            //
            lbCash500.Text += soTo500.ToString();
            lbCash200.Text += soTo200.ToString();
            lbCash100.Text += soTo100.ToString();
            lbCash50.Text += soTo50.ToString();
            //
            lbTextSoDu.Text = "Vui lòng nhận tiền, hóa đơn và nhận lại thẻ!!!";
        }

        //
        void Step323()
        {
            //
            step = 323;
            //
            DisableAll();
            //
            lbBillCamOn.Show();
            lbBillGio.Show();
            lbBillNgay.Show();
            lbBillSoDu.Show();
            lbBillSoTienRut.Show();
            lbBillTenTK.Show();
            //
            lbCash500.Show();
            lbCash200.Show();
            lbCash100.Show();
            lbCash50.Show();
            //
            lbTextSoDu.Show();
            //
            lbBillTenTK.Text += tenChuTK;
            lbBillSoTienRut.Text += soTienRut;
            lbBillSoDu.Text += soDu;
            lbBillNgay.Text += " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            lbBillGio.Text += " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            //
            lbCash500.Text += soTo500.ToString();
            lbCash200.Text += soTo200.ToString();
            lbCash100.Text += soTo100.ToString();
            lbCash50.Text += soTo50.ToString();
            //
            lbTextSoDu.Text = "Vui lòng nhận tiền, hóa đơn và nhận lại thẻ!!!";
        }

        //
        void Step324()
        {
            //
            step = 324;
            //
            DisableAll();
            //
            lbBillCamOn.Show();
            lbBillGio.Show();
            lbBillNgay.Show();
            lbBillSoDu.Show();
            lbBillSoTienRut.Show();
            lbBillTenTK.Show();
            //
            lbCash500.Show();
            lbCash200.Show();
            lbCash100.Show();
            lbCash50.Show();
            //
            lbTextSoDu.Show();
            //
            lbBillTenTK.Text += tenChuTK;
            lbBillSoTienRut.Text += soTienRut;
            lbBillSoDu.Text += soDu;
            lbBillNgay.Text += " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            lbBillGio.Text += " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            //
            lbCash500.Text += soTo500.ToString();
            lbCash200.Text += soTo200.ToString();
            lbCash100.Text += soTo100.ToString();
            lbCash50.Text += soTo50.ToString();
            //
            lbTextSoDu.Text = "Vui lòng nhận tiền, hóa đơn và nhận lại thẻ!!!";
        }

        //
        void Step325()
        {
            step = 325;
            //
            DisableAll();
            //
            //
            btnNum0.Enabled = true;
            btnNum1.Enabled = true;
            btnNum2.Enabled = true;
            btnNum3.Enabled = true;
            btnNum4.Enabled = true;
            btnNum5.Enabled = true;
            btnNum6.Enabled = true;
            btnNum7.Enabled = true;
            btnNum8.Enabled = true;
            btnNum9.Enabled = true;
            btnNumCancel.Enabled = true;
            btnNumClear.Enabled = true;
            btnNumEnter.Enabled = true;
            //
            txtNhapTien.Show();
            lbInsertCard.Show();
            lbNote.Show();
            //
            lbInsertCard.Text = "Nhập số tiền: ";
            lbNote.Text = "Số tiền nhập phải là bội số của 50000 VND.";
        }

        //
        void Step3251()
        {
            //
            step = 3251;
            //
            DisableAll();
            //
            lbBillCamOn.Show();
            lbBillGio.Show();
            lbBillNgay.Show();
            lbBillSoDu.Show();
            lbBillSoTienRut.Show();
            lbBillTenTK.Show();
            //
            lbCash500.Show();
            lbCash200.Show();
            lbCash100.Show();
            lbCash50.Show();
            //
            lbTextSoDu.Show();
            //
            lbBillTenTK.Text += tenChuTK;
            lbBillSoTienRut.Text += soTienRut;
            lbBillSoDu.Text += soDu;
            lbBillNgay.Text += " " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            lbBillGio.Text += " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            //
            lbCash500.Text += soTo500.ToString();
            lbCash200.Text += soTo200.ToString();
            lbCash100.Text += soTo100.ToString();
            lbCash50.Text += soTo50.ToString();
            //
            lbTextSoDu.Text = "Vui lòng nhận tiền, hóa đơn và nhận lại thẻ!!!";
        }

        //
        void Step326()
        {
            step = 326;
            //
            DisableAll();
            //
            lbHoiKT.Show();
            lb5.Show();
            lb6.Show();
            btn5.Enabled = true;
            btn6.Enabled = true;
            //
            lbHoiKT.Text = "Bạn có muốn thực hiện giao dịch khác không?";
            lb5.Text = "Có";
            lb6.Text = "Không";
        }
        //
        void Step34()
        {
            step = 34;
            //
            DisableAll();
            //
            btnNum0.Enabled = true;
            btnNum1.Enabled = true;
            btnNum2.Enabled = true;
            btnNum3.Enabled = true;
            btnNum4.Enabled = true;
            btnNum5.Enabled = true;
            btnNum6.Enabled = true;
            btnNum7.Enabled = true;
            btnNum8.Enabled = true;
            btnNum9.Enabled = true;
            btnNumCancel.Enabled = true;
            btnNumClear.Enabled = true;
            btnNumEnter.Enabled = true;
            //
            lbInsertCard.Show();
            txtNhapTien.Hide();
            txtMatKhau.Show();
            //
            txtMatKhau.PasswordChar = '*';
            lbInsertCard.Text = "Nhập mã PIN hiện tại.";

        }

        //
        void Step341()
        {
            step = 341;
            //
            DisableAll();
            //
            btnNum0.Enabled = true;
            btnNum1.Enabled = true;
            btnNum2.Enabled = true;
            btnNum3.Enabled = true;
            btnNum4.Enabled = true;
            btnNum5.Enabled = true;
            btnNum6.Enabled = true;
            btnNum7.Enabled = true;
            btnNum8.Enabled = true;
            btnNum9.Enabled = true;
            btnNumCancel.Enabled = true;
            btnNumClear.Enabled = true;
            btnNumEnter.Enabled = true;
            //
            lbInsertCard.Show();
            txtNhapTien.Hide();
            txtMatKhau.Show();
            //
            lbInsertCard.Text = "Nhập mã PIN mới.";
        }

        //
        void Step3411()
        {
            step = 3411;
            //
            DisableAll();
            //
            btnNum0.Enabled = true;
            btnNum1.Enabled = true;
            btnNum2.Enabled = true;
            btnNum3.Enabled = true;
            btnNum4.Enabled = true;
            btnNum5.Enabled = true;
            btnNum6.Enabled = true;
            btnNum7.Enabled = true;
            btnNum8.Enabled = true;
            btnNum9.Enabled = true;
            btnNumCancel.Enabled = true;
            btnNumClear.Enabled = true;
            btnNumEnter.Enabled = true;
            //
            lbInsertCard.Show();
            txtNhapTien.Hide();
            txtMatKhau.Show();
            //
            lbInsertCard.Text = "Nhập lại mã PIN mới.";
        }

        //
        void Step34111()
        {
            step = 34111;
            //
            DisableAll();
            //
            lbTextSoDu.Show();
            lbHoiKT.Show();
            lb5.Show();
            lb6.Show();
            //
            btn5.Enabled = true;
            btn6.Enabled = true;
            //
            lbTextSoDu.Text = "Đổi mã PIN thành công.";
            lbHoiKT.Text = "Bạn có muốn thực hiện giao dịch khác không?";
            lb5.Text = "Có";
            lb6.Text = "Không";
        }

        //
        void StepKoDuTien()
        {
            step = 99;
            //
            DisableAll();
            //
            lbTextSoDu.Show();
            lbHoiKT.Show();
            lb5.Show();
            lb6.Show();
            //
            btn5.Enabled = true;
            btn6.Enabled = true;
            //
            lbTextSoDu.Text = "Số tiền trong tài khoản của bạn không đủ.";
            lbHoiKT.Text = "Bạn có muốn thực hiện giao dịch khác?";
            lb5.Text = "Có";
            lb6.Text = "Không";
        }
        //
        //Button do
        //
        private void btnCardDKB_Click(object sender, EventArgs e)
        {
            //
            fileName = "Dau Khac Bac.txt";
            //Ket thuc
            if(isDKB == true)
            {
                Application.Restart();
            }
            //Bat dau
            else 
            {
                isDKB = true;
                Step2();
                DocDuLieuKhachHang(fileName);
                lbChuTK.Text = tenChuTK;
                ClearBillCash();
                lbPassword.Text = "******";
            }
            //
        }

        //
        private void btnCardKD_Click(object sender, EventArgs e)
        {
            //
            fileName = "Kieu Dinh.txt";
            //Ket thuc
            if (isKD == true)
            {
                Application.Restart();
            }
            //Bat dau
            else
            {
                isKD = true;
                Step2();
                DocDuLieuKhachHang(fileName);
                lbChuTK.Text = tenChuTK;
                ClearBillCash();
            }
            
        }

        //
        private void btn1_Click(object sender, EventArgs e)
        {
            //
            if (step == 32)
            {
                //Calculate
                soTienRut = 4000000;
                if (soDu >= (soTienRut + 50000) && soTienTrongATM >= soTienRut)
                {
                    //
                    soDu = soDu - soTienRut;
                    soTienTrongATM = soTienTrongATM - soTienRut;
                    Cash(soTienRut);
                    if (atmHetTien == false)
                    {
                        TruToTien();
                        GhiDuLieuKhachHang(fileName, tenChuTK, matKhau, soDu);
                        GhiDuLieuATM(soTienTrongATM, soTo500K, soTo200K, soTo100K, soTo50K);
                        //
                        if (isDKB == true)
                        {
                            btnCardDKB.Enabled = true;
                        }
                        else
                        {
                            btnCardKD.Enabled = true;
                        }
                        //
                        Step321();
                    }
                    else
                    {
                        StepKoDuTien();
                    }
                }
                else
                {
                    StepKoDuTien();
                }

            }
            //
            if (step == 3)
            {
                Step31();
            }
        }

        //
        private void btn5_Click(object sender, EventArgs e)
        {
            if(step == 34111)
            {
                Step3();
            }

            //
            if (step == 326)
            {
                Step3();
            }
            //
            if (step == 99)
            {
                Step3();
            }
            //
            if (step == 32)
            {             
                //Calculate
                //soTienRut = Double.Parse(txtNhapTien.Text.ToString());

                Step325();
            }
            //
            if (step == 31)
            {
                Step3();
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            //
            if (step == 34111)
            {
                if (isDKB == true)
                {
                    btnCardDKB.Enabled = true;
                }
                else
                {
                    btnCardKD.Enabled = true;
                }
                Step1();

                lbInsertCard.Show();
                lbInsertCard.Text = "Vui lòng nhận lại thẻ!!!";
            }
            
            //
            if (step == 326)
            {
                if (isDKB == true)
                {
                    btnCardDKB.Enabled = true;
                }
                else
                {
                    btnCardKD.Enabled = true;
                }
                Step1();

                lbInsertCard.Show();
                lbInsertCard.Text = "Vui lòng nhận lại thẻ!!!";
            }
            //
            if (step == 99)
            {
                if (isDKB == true)
                {
                    btnCardDKB.Enabled = true;
                }
                else
                {
                    btnCardKD.Enabled = true;
                }
                Step1();

                lbInsertCard.Show();
                lbInsertCard.Text = "Vui lòng nhận lại thẻ!!!";
            }
            //
            if (step == 32)
            {
                Step326();
            }

            //
            if (step == 31)
            {
                if (isDKB == true)
                {
                    btnCardDKB.Enabled = true;
                }
                else
                {
                    btnCardKD.Enabled = true;
                }
                Step1();
                
                lbInsertCard.Show();
                lbInsertCard.Text = "Vui lòng nhận lại thẻ!!!";
            }

            //
            if (step == 35)
            {
                if (isDKB == true)
                {
                    btnCardDKB.Enabled = true;
                }
                else
                {
                    btnCardKD.Enabled = true;
                }
                Step1();

                lbInsertCard.Show();
                lbInsertCard.Text = "Vui lòng nhận lại thẻ!!!";
            }
        }

        //
        private void btnNumEnter_Click(object sender, EventArgs e)
        {
            if(step == 325)
            {
                //Calculate
                //
                bool a = KiemTraSoTienNhap(txtNhapTien.Text);
                if (a == true)
                {
                    soTienRut = Int32.Parse(txtNhapTien.Text.ToString());
                    if (soDu >= (soTienRut + 50000) && soTienTrongATM >= soTienRut)
                    {
                        //
                        soDu = soDu - soTienRut;
                        soTienTrongATM = soTienTrongATM - soTienRut;
                        Cash(soTienRut);
                        if (atmHetTien == false)
                        {
                            TruToTien();
                            GhiDuLieuKhachHang(fileName, tenChuTK, matKhau, soDu);
                            GhiDuLieuATM(soTienTrongATM, soTo500K, soTo200K, soTo100K, soTo50K);
                            //
                            if (isDKB == true)
                            {
                                btnCardDKB.Enabled = true;
                            }
                            else
                            {
                                btnCardKD.Enabled = true;
                            }
                            //
                            Step3251();
                        }
                        else
                        {
                            StepKoDuTien();
                        }
                    }
                    else
                    {
                        StepKoDuTien();
                    }
                } 
            }

            //
            if (step == 3411)
            {
                if(matKhauMoi == txtMatKhau.Text.ToString().Trim())
                {
                    matKhau = matKhauMoi;
                    GhiDuLieuKhachHang(fileName, tenChuTK, matKhau, soDu);
                    Step34111();
                }
                
            }
            //
            if (step == 341)
            {
                matKhauMoi = txtMatKhau.Text.ToString();
                Step3411();
            }
            //
            if (step == 34)
            {
                if(matKhau == txtMatKhau.Text.ToString())
                {
                    Step341();
                }
                else
                {
                    txtMatKhau.Text = "";
                    Step34();
                }
                
            }
            //
            if (step == 2)
            {
                if(matKhau == passWord.ToString())
                {
                    Step3();
                }
                else {
                    Step2();
                    lbPassword.Text = "******";
                    passWord = "";
                }
                
            }
        }

        //
        private void btn2_Click(object sender, EventArgs e)
        {
            //
            if (step == 32)
            {
                ////Caculate
                soTienRut = 2000000;
                if (soDu >= (soTienRut + 50000) && soTienTrongATM >= soTienRut)
                {
                    //
                    soDu = soDu - soTienRut;
                    soTienTrongATM = soTienTrongATM - soTienRut;
                    Cash(soTienRut);
                    if (atmHetTien == false)
                    {
                        TruToTien();
                        GhiDuLieuKhachHang(fileName, tenChuTK, matKhau, soDu);
                        GhiDuLieuATM(soTienTrongATM, soTo500K, soTo200K, soTo100K, soTo50K);
                        //
                        if (isDKB == true)
                        {
                            btnCardDKB.Enabled = true;
                        }
                        else
                        {
                            btnCardKD.Enabled = true;
                        }
                        //
                        Step322();
                    }
                    else
                    {
                        StepKoDuTien();
                    }
                }
                else
                {
                    StepKoDuTien();
                }
                
            }
            //
            if (step == 3)
            {
                Step32();
            }
            

        }

        //
        private void btn3_Click(object sender, EventArgs e)
        {
            //
            if (step == 32)
            {
                //Caculate
                soTienRut = 1000000;
                if (soDu >= (soTienRut + 50000) && soTienTrongATM >= soTienRut)
                {
                    //
                    //
                    soDu = soDu - soTienRut;
                    soTienTrongATM = soTienTrongATM - soTienRut;
                    Cash(soTienRut);
                    if (atmHetTien == false)
                    {
                        TruToTien();
                        GhiDuLieuKhachHang(fileName, tenChuTK, matKhau, soDu);
                        GhiDuLieuATM(soTienTrongATM, soTo500K, soTo200K, soTo100K, soTo50K);
                        //
                        if (isDKB == true)
                        {
                            btnCardDKB.Enabled = true;
                        }
                        else
                        {
                            btnCardKD.Enabled = true;
                        }
                        //
                        Step323();
                    }
                    else
                    {
                        StepKoDuTien();
                    }
                }
                else
                {
                    StepKoDuTien();
                }
            }
        }

        //
        private void btn4_Click(object sender, EventArgs e)
        {
            //
            if (step == 32)
            {
                //Caculate
                soTienRut = 500000;
                if (soDu >= (soTienRut + 50000) && soTienTrongATM >= soTienRut)
                {
                    //
                    soDu = soDu - soTienRut;
                    soTienTrongATM = soTienTrongATM - soTienRut;
                    Cash(soTienRut);
                    if (atmHetTien == false)
                    {
                        TruToTien();
                        GhiDuLieuKhachHang(fileName, tenChuTK, matKhau, soDu);
                        GhiDuLieuATM(soTienTrongATM, soTo500K, soTo200K, soTo100K, soTo50K);
                        //
                        if (isDKB == true)
                        {
                            btnCardDKB.Enabled = true;
                        }
                        else
                        {
                            btnCardKD.Enabled = true;
                        }
                        //
                        Step324();
                    }
                    else
                    {
                        StepKoDuTien();
                    }
                }
                else
                {
                    StepKoDuTien();
                }
            }
            //
            if (step == 3)
            {
                Step34();
            }
        }

        //
        private void btnNum0_Click(object sender, EventArgs e)
        {
            kbValue = 0;
            Keyboard();
        }

        //
        private void btnNum1_Click(object sender, EventArgs e)
        {
            kbValue = 1;
            Keyboard();
        }

        //
        private void btnNum2_Click(object sender, EventArgs e)
        {
            kbValue = 2;
            Keyboard();
        }
        
        //
        private void btnNum3_Click(object sender, EventArgs e)
        {
            kbValue = 3;
            Keyboard();
        }

        //
        private void btnNum4_Click(object sender, EventArgs e)
        {
            kbValue = 4;
            Keyboard();
        }

        //
        private void btnNum5_Click(object sender, EventArgs e)
        {
            kbValue = 5;
            Keyboard();
        }

        //
        private void btnNum6_Click(object sender, EventArgs e)
        {
            kbValue = 6;
            Keyboard();
        }

        //
        private void btnNum7_Click(object sender, EventArgs e)
        {
            kbValue = 7;
            Keyboard();
        }

        //
        private void btnNum8_Click(object sender, EventArgs e)
        {
            kbValue = 8;
            Keyboard();
        }

        //
        private void btnNum9_Click(object sender, EventArgs e)
        {
            kbValue = 9;
            Keyboard();
        }

        private void btnNumClear_Click(object sender, EventArgs e)
        {
            //
            if (step == 325)
            {
                txtNhapTien.Text = "";
            }

            //
            if (step == 3411)
            {
                txtMatKhau.Text = "";
            }
            //
            if(step == 341)
            {
                txtMatKhau.Text = "";
            }
            //
            if (step == 34)
            {
                txtMatKhau.Text = "";
            }
            //
            if (step == 2)
            {
                passWord = "";
                lbPassword.Text = "******";

            }
            
        }

        private void btnNumCancel_Click(object sender, EventArgs e)
        {
            if (isDKB == true)
            {
                btnCardDKB.Enabled = true;
            }
            else
            {
                btnCardKD.Enabled = true;
            }
            Step1();

            lbInsertCard.Show();
            lbInsertCard.Text = "Vui lòng nhận lại thẻ!!!";
        }
    }
}
