using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace IndividualiosVeiklosMokesciuSkaiciuokle
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)FindName("trisdesimtProcentu");
            RadioButton rb5 = (RadioButton)FindName("penkiProc");
            RadioButton rb15 = (RadioButton)FindName("penkiolikaProc");
            double pajamos = 0;
            double islaidos = 0;
            double vsd = 0;
            double psd = 0;
            double gpmProc = 0;
            double apmokestinamasPelnas = 0;

            Double.TryParse(gautosPajamos.Text, out pajamos);

            if (cb.IsChecked == true)
            {
                islaidos = pajamos * 0.3;
                apmokestinamasPelnas = pajamos - islaidos;
            }
            else
            {
                Double.TryParse(patirtosSanaudos.Text, out islaidos);
                if (islaidos > pajamos)
                {
                    apmokestinamasPelnas = 0;
                }
                else
                {
                    apmokestinamasPelnas = pajamos - islaidos;
                }
            }

            Double.TryParse(sumoketasVSD.Text, out vsd);
            Double.TryParse(sumoketasPSD.Text, out psd);


            if (rb5.IsChecked == true)
            {
                gpmProc = 0.05;
            }
            else
            {
                gpmProc = 0.15;
            }

            if (pajamos >= 0 && islaidos >= 0 && vsd >= 0 && psd >= 0)
            {                
                double mokVsd = apmokestinamasPelnas / 2 * 0.285;
                double mokPsd = apmokestinamasPelnas / 2 * 0.09;
                double mokGpm = apmokestinamasPelnas * gpmProc;

                apmokestinamasPelnasLabel.Text = Convert.ToString(Math.Round(apmokestinamasPelnas, 2));
                if (mokVsd > vsd)
                {
                    mokVsd = mokVsd - vsd;
                    mokVsdLabel.Text = Convert.ToString(Math.Round(mokVsd, 2));
                }
                else
                {
                    mokVsd = 0;
                    mokVsdLabel.Text = "0";
                }

                if (mokPsd > psd)
                {
                    mokPsd = mokPsd - psd;
                    mokPsdLabel.Text = Convert.ToString(Math.Round(mokPsd, 2));
                }
                else
                {
                    mokPsd = 0;
                    mokPsdLabel.Text = "0";
                }
                mokGmpLabel.Text = Convert.ToString(Math.Round(mokGpm, 2));
                visoLabel.Text = Convert.ToString(Math.Round(mokVsd + mokPsd + mokGpm, 2));
                
            }
            else
            {
                //TO-DO validacija

            }
        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox cb = (CheckBox)FindName("trisdesimtProcentu");
            
            if (cb == null)
            {
                //TO-DO pasiskaitinet kas per briedas su tais checbox ir kodel jie null
            }
            else if (cb.IsChecked == true)
            {               
                patirtosSanaudos.IsEnabled = false;
            }
            else
            {             
                patirtosSanaudos.IsEnabled = true;
            }
            
 
        }


    }
}