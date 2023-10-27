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
using Encrypt_Decrypt.VVM.ViewModel;
using System.Windows.Shapes;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    /// <summary>
    /// Logika interakcji dla klasy PolybiusKey.xaml
    /// </summary>
    public partial class PolybiusKey : UserControl
    {

        public TextBox[,] TextBoxes { get; set; }

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

            // polybius cipher as an exception has other alhpabet where j is threated as i
            string lang = "";

            if (mainWindow.language == "english")
                lang = "PolybiusEnglish";
            else
                lang = mainWindow.language;



            (int, int) multipliers = LanguageOperations.GetClosestMultipliers(lang);

            TextBoxes = new TextBox[multipliers.Item1, multipliers.Item2];
           

                for (int i = 0; i < multipliers.Item1 + 1; i++)
                {
                    PolybiusSquare.ColumnDefinitions.Add(new ColumnDefinition());

                    for (int j = 0; j < multipliers.Item2 + 1; j++)
                    {
                        PolybiusSquare.RowDefinitions.Add(new RowDefinition());


                        if(i == 0)
                        {
                            TextBlock textBlock = new TextBlock();
                            textBlock.Text = $"{j}";
                            textBlock.FontSize = 25;

                            Frame frame = new Frame();
                            frame.Content = textBlock;
                            frame.Width = 100;
                            frame.Height = 50;
                            frame.BorderBrush = new SolidColorBrush(Color.FromRgb(112, 112, 112));
                            frame.Margin = new Thickness(10);
                            frame.BorderThickness = new Thickness(3);


                            PolybiusSquare.Children.Add(frame);


                            Grid.SetColumn(frame, i);
                            Grid.SetRow(frame, j);
                        }
                        else if(j == 0)
                        {
                            TextBlock textBlock = new TextBlock();
                            textBlock.Text = $"{i}";
                            textBlock.FontSize = 25;

                            Frame frame = new Frame();
                            frame.Content = textBlock;
                            frame.Width = 100;
                            frame.Height = 50;
                            frame.BorderBrush = new SolidColorBrush(Color.FromRgb(112, 112, 112));
                            frame.Margin = new Thickness(10);
                            frame.BorderThickness = new Thickness(3);


                            PolybiusSquare.Children.Add(frame);


                            Grid.SetColumn(frame, i);
                            Grid.SetRow(frame, j);
                        }
                        else
                        {
                            TextBox textBox = new TextBox();
                            textBox.MaxLength = 1;
                            textBox.FontSize = 25;
                            textBox.Text = "";
                            
                            if(mainWindow.language == "polish")
                                textBox.PreviewTextInput += InputValidation.TextBox_PreviewTextInputPolish;
                            else if(mainWindow.language == "polishXVQ")
                                textBox.PreviewTextInput += InputValidation.TextBox_PreviewTextInputPolishXVQ;
                            else if(mainWindow.language == "english")
                                textBox.PreviewTextInput += InputValidation.TextBox_PreviewTextInputPolybiusEnglish;


                            // store the reference of a current textbox in 2d array of textboxes
                            TextBoxes[i - 1, j - 1] = textBox;

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
            bool isFilled = false;

           foreach(TextBox s in TextBoxes)
           {
                if (String.IsNullOrEmpty(s.Text))
                {
                    isFilled = false;
                    break;
                }
                else
                    isFilled = true;
                   
           }   



            var mainWindow = Window.GetWindow(this) as MainWindow;

            if(mainWindow.IsEncryption == true && isFilled == true)
            {
                Encrypt Polybius = new Encrypt(mainWindow.Algorithm, TextBoxes,
                mainWindow.input, mainWindow.language);
                mainWindow.Result.Text = Polybius.performEncryption(Polybius);
                mainWindow.PolybiusKeyControl.Content = null;
                
            }
            else if(isFilled == true)
            {
                Decrypt Polybius = new Decrypt(mainWindow.Algorithm, TextBoxes,
                mainWindow.input, mainWindow.language);
                mainWindow.Result.Text = Polybius.performDecryption(Polybius);
                mainWindow.PolybiusKeyControl.Content = null;
            }
            else
            { }
           





        }
    }
}
