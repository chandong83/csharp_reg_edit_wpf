using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rtd_tool
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Label[] lblIDHs = new Label[16];
        Label[] lblIDLs = new Label[16];
        TextBox[,] txtHex = new TextBox[16, 16];

        SolidColorBrush SelectedLabelBrush = new SolidColorBrush(Color.FromArgb(255, (byte)0xBF, (byte)0x8F, (byte)0xFF));
        SolidColorBrush NormalLabelBrush = new SolidColorBrush(Color.FromArgb(00, (byte)0xBF, (byte)0x8F, (byte)0xFF));
        SolidColorBrush NormalTextBrush = new SolidColorBrush(Color.FromArgb(255, (byte)0xFF, (byte)0xFF, (byte)0xFF));
        SolidColorBrush SeletecTextBrush = new SolidColorBrush(Color.FromArgb(255, (byte)0xBF, (byte)0xBF, (byte)0xBF));
        public MainWindow()
        {
            InitializeComponent();

            lblIDHs[0] = lblNumHigh0;
            lblIDHs[1] = lblNumHigh1;
            lblIDHs[2] = lblNumHigh2;
            lblIDHs[3] = lblNumHigh3;
            lblIDHs[4] = lblNumHigh4;
            lblIDHs[5] = lblNumHigh5;
            lblIDHs[6] = lblNumHigh6;
            lblIDHs[7] = lblNumHigh7;
            lblIDHs[8] = lblNumHigh8;
            lblIDHs[9] = lblNumHigh9;
            lblIDHs[10] = lblNumHighA;
            lblIDHs[11] = lblNumHighB;
            lblIDHs[12] = lblNumHighC;
            lblIDHs[13] = lblNumHighD;
            lblIDHs[14] = lblNumHighE;
            lblIDHs[15] = lblNumHighF;

            lblIDLs[0] = lblNumLow0;
            lblIDLs[1] = lblNumLow1;
            lblIDLs[2] = lblNumLow2;
            lblIDLs[3] = lblNumLow3;
            lblIDLs[4] = lblNumLow4;
            lblIDLs[5] = lblNumLow5;
            lblIDLs[6] = lblNumLow6;
            lblIDLs[7] = lblNumLow7;
            lblIDLs[8] = lblNumLow8;
            lblIDLs[9] = lblNumLow9;
            lblIDLs[10] = lblNumLowA;
            lblIDLs[11] = lblNumLowB;
            lblIDLs[12] = lblNumLowC;
            lblIDLs[13] = lblNumLowD;
            lblIDLs[14] = lblNumLowE;
            lblIDLs[15] = lblNumLowF;

            for(int i=0;i<16;i++)
            {
                for(int j=0;j<16;j++)
                {   
                    string str = string.Format("{0:X2}", (i * 16) + j);
                    txtHex[i, j] = (TextBox)FindName("txtNum"+str);
                    txtHex[i, j].Text = str;
                }
            }
        }

        private void txtNum_MouseEnter(object sender, MouseEventArgs e)
        {            
            string name = ((TextBox)sender).Name;
            if(name.Length != 0)
            {
                name = name.Substring(name.Length - 2);
                
                
                int hex = Int32.Parse(name, System.Globalization.NumberStyles.HexNumber);

                lblIDHs[(((byte)hex >> 4) & 0x0F)].Background = SelectedLabelBrush;
                lblIDLs[((byte)hex & 0x0F)].Background = SelectedLabelBrush;


            }
        }

        private void txtNum_MouseLeave(object sender, MouseEventArgs e)
        {
            string name = ((TextBox)sender).Name;
            if (name.Length != 0)
            {
                name = name.Substring(name.Length - 2);

                int hex = Int32.Parse(name, System.Globalization.NumberStyles.HexNumber);
               
                lblIDHs[(((byte)hex >> 4) & 0x0F)].Background = NormalLabelBrush;
                lblIDLs[((byte)hex & 0x0F)].Background = NormalLabelBrush;
            }
        }


        private void ShowRegTextInfo(int hex)
        {
            string info = string.Format("REG INFO 0x{0:X}", hex) + Environment.NewLine;

            info += "Test infomation";

            txtRegInfo.Text = info;
        }

        private void txtNum_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Background = SeletecTextBrush;
            string name = ((TextBox)sender).Name;
            if (name.Length != 0)
            {
                name = name.Substring(name.Length - 2);
                int hex = Int32.Parse(name, System.Globalization.NumberStyles.HexNumber);
                ShowRegTextInfo(hex);
            }
        }

        private void txtNum_LostFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Background = NormalTextBrush;
        }
    }
}
