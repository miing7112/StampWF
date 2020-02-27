//------------------------------------------------------------------------------
//     StampWF
//     Created 2016/4/25 by mi-kim@teratech.co.jp
//
//     機能①：日付表示選択(追加orなし)
//     機能②：背景選択(白or透明)
//     機能③：フォント選択
//     機能④：プレビュー
//     
//     名字　１桁：上、２桁：上１下１、３桁：上２下１、４桁：上２下２
//
//     名前の入力可能
//     名字が３桁以上の場合、名前は入力不可
//     名前が３桁以上の場合、頭２桁のみ出力
//
//     空白入力不可
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StampWF
{
    public partial class CreateStamp : Form
    {
        public CreateStamp()
        {
            InitializeComponent();

            Bitmap stampImg = new Bitmap(iImageSize, iImageSize);
            pictureBox1.Image = stampImg;
        }

        const int iImageSize = 150;
        const int iPadding = 3;
        const int iCircleSize = iImageSize - iPadding*2;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string strFamilyName = "";
            string strGivenName = "";

            strFamilyName = txtFamilyName.Text.ToString();
            strGivenName = txtGivenName.Text.ToString();

            Graphics textGraphics = Graphics.FromHwnd(txtFamilyName.Handle);
            SizeF stringSize = textGraphics.MeasureString(txtFamilyName.Text, txtFamilyName.Font);

            MessageBox.Show(System.Environment.SystemDirectory);

            //MessageBox.Show(stringSize.Width.ToString());

            //int iPosition = (iCircleSize - (int)stringSize.Width) / 2;
            //int iLength = strFamilyName.Length;

            //int iPosition = (iCircleSize - 40) / 2 - 20;

            //MessageBox.Show(iPosition.ToString());
            //if (stringSize.Width

            //if (strFamilyName.Equals("")&& strFamilyName.Equals(""))
            //    return;

            string strStampDate = dateTimePicker1.Value.ToString("yyyy.MM.dd");

            Graphics g = Graphics.FromImage(pictureBox1.Image);

            if (strGivenName.Equals(""))
            {
                try
                {
                    g.DrawImage(pictureBox1.Image, 0, 0, iImageSize, iImageSize);
                    g.FillRectangle(Brushes.White, new Rectangle(0, 0, iImageSize, iImageSize));

                    Pen pen = new Pen(Color.Red, 4);
                    g.DrawEllipse(pen, iPadding, iPadding, iCircleSize, iCircleSize);

                    if (chkDate.Checked)
                    {
                        pen = new Pen(Color.Red, 3);
                        g.DrawLine(pen, new Point(5, 80), new Point(145, 80));
                        g.DrawLine(pen, new Point(12, 110), new Point(138, 110));
                        g.DrawString(strStampDate, new Font("MS UI Gothic", 20), Brushes.Red, 9, 81);
                    }

                    Font fontChar = new Font("ＭＳ Ｐ明朝", 40, FontStyle.Bold);

                    g.DrawString(strFamilyName, fontChar, Brushes.Red, 40, 19);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (g != null)
                        g.Dispose();

                    //if (stampImg != null)
                    //    stampImg.Dispose();

                    pictureBox1.Refresh();
                }
            }
            else
            {
                try
                {
                    g.DrawImage(pictureBox1.Image, 0, 0, iImageSize, iImageSize);
                    g.FillRectangle(Brushes.White, new Rectangle(0, 0, iImageSize, iImageSize));

                    Pen pen = new Pen(Color.Red, 4);
                    g.DrawEllipse(pen, iPadding, iPadding, iCircleSize, iCircleSize);

                    if (chkDate.Checked)
                    {
                        pen = new Pen(Color.Red, 3);
                        g.DrawLine(pen, new Point(5, 60), new Point(145, 60));
                        g.DrawLine(pen, new Point(5, 90), new Point(145, 90));
                        g.DrawString(strStampDate, new Font("MS UI Gothic", 20), Brushes.Red, 9, 61);
                    }

                    Font fontChar = new Font("ＭＳ Ｐ明朝", 32, FontStyle.Bold);
                    g.DrawString(strFamilyName, fontChar, Brushes.Red, 46, 11);
                    //Font fontCharGiven = new Font("ＭＳ Ｐ明朝", 30, FontStyle.Bold);
                    //g.DrawString(strGivenName, fontCharGiven, Brushes.Red, 26, 96);

                    Font fontCharGiven = new Font("ＭＳ Ｐ明朝", 32, FontStyle.Bold);
                    g.DrawString(strGivenName, fontCharGiven, Brushes.Red, 46, 96);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (g != null)
                        g.Dispose();

                    //if (stampImg != null)
                    //    stampImg.Dispose();

                    pictureBox1.Refresh();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strStampFileName = "StampWF" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";

            pictureBox1.Image.Save(strStampFileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
