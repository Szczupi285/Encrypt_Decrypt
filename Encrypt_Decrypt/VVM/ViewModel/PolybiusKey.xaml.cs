using System;
using System.Collections.Generic;
using System.Data;
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

namespace Encrypt_Decrypt.VVM.ViewModel
{
    /// <summary>
    /// Logika interakcji dla klasy PolybiusKey.xaml
    /// </summary>
    public partial class PolybiusKey : UserControl
    {
        public PolybiusKey()
        {
            InitializeComponent();



          
        }

        public void GeneratePolybiusSquare()
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;

            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = GridLength.Auto;

            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;

            // find two divisors that are nearest eachother this numbers are for loops

            if (mainWindow.language == "polish")
            {


                for (int i = 0; i < 8; i++)
                {
                    PolybiusSquare.ColumnDefinitions.Add(new ColumnDefinition());

                    for (int j = 0; j < 4; j++)
                    {
                        PolybiusSquare.RowDefinitions.Add(new RowDefinition());

                        TextBox textBox = new TextBox();
                        textBox.MaxLength = 2;
                        textBox.FontSize = 25;

                        Frame frame = new Frame();
                        frame.Content = textBox;
                        frame.Width = 100;
                        frame.Height = 50;
                        frame.BorderBrush = new SolidColorBrush(Color.FromRgb(112, 112, 112));
                        frame.Margin = new Thickness(10);
                        frame.BorderThickness = new Thickness(3);



                        PolybiusSquare.Children.Add(frame);


                        Grid.SetColumn(frame, i);
                        Grid.SetRow(frame, j);
                    }

                }

               
            }
        }

        private void PolybiusKey_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
