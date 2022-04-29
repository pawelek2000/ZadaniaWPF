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

namespace WpfMVVM
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Point startPoint;
        private Rectangle myRectangle;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Rectangle_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(myCanvas);

            if (myRectangle != null)
                myCanvas.Children.Remove(myRectangle);

            myRectangle = new Rectangle
            {
                Stroke = Brushes.DarkRed,
                Fill = Brushes.LightPink,
                StrokeThickness = 2
            };

            Canvas.SetLeft(myRectangle, startPoint.X);
            Canvas.SetTop(myRectangle, startPoint.X);
            myCanvas.Children.Add(myRectangle);
        }

     
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released || myRectangle == null)
                return;

            var pos = e.GetPosition(myCanvas);

            var x = Math.Min(pos.X, startPoint.X);
            var y = Math.Min(pos.Y, startPoint.Y);

            var w = Math.Max(pos.X, startPoint.X) - x;
            var h = Math.Max(pos.Y, startPoint.Y) - y;

            myRectangle.Width = w;
            myRectangle.Height = h;

            Canvas.SetLeft(myRectangle, x);
            Canvas.SetTop(myRectangle, y);
        }

        private void Rectangle_MouseLeftUp(object sender, MouseButtonEventArgs e)
        {
            myRectangle = null;
        }

    }
}
