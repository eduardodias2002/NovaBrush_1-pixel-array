using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _1_pixel_array{

    public partial class MainWindow : Window{

        private CanvasPanel canvasPanel;
        private WriteableBitmap _canvasBitmap;


        public MainWindow(){
            InitializeComponent();
            CreateCanvas();
            Globals.Initialize(this);
        }

        // Places the Canvas
        public void CreateCanvas(){
            canvasPanel = new CanvasPanel
            {
                Width = 32,
                Height = 32,
            
            };

            // Add it to the named parent container from XAML
            MainCanvas.Children.Add(canvasPanel);
            canvasPanel.prepareCanvas(); 
        }

        // Click Open Button
        private void btn_open_Click(object sender, RoutedEventArgs e){
            var ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.FileName = "Image"; // Default file name
            ofd.DefaultExt = ".png"; // Default file extension
            ofd.Filter = ".Image Files (*.png)|*.png"; // Filter files by extension

            bool? result = ofd.ShowDialog();

            if (result == true)
            {
                try
                {
                    string filename = ofd.FileName;

                    BitmapImage bitmapImage = new BitmapImage(new Uri(filename));
                    WriteableBitmap writable = new WriteableBitmap(bitmapImage);

                    canvasPanel.LoadBitmap(writable);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}