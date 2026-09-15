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

namespace CoiPlanningTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MachinePrefab draggedPrefab;
        Point draggedPoint;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void leftMouseBtn(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(mainCanvas);
            IInputElement clickCheck = mainCanvas.InputHitTest(clickPoint);
            if (clickCheck != null)
            {
                if (e.Source != null && e.Source is MachinePrefab)
                {
                    draggedPrefab = (MachinePrefab)e.Source;
                    draggedPoint = e.GetPosition(draggedPrefab);
                }
            }
        }

        private void rightMouseBtn(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(mainCanvas);
            IInputElement clickCheck = mainCanvas.InputHitTest(clickPoint);
            if (clickCheck != null && clickCheck != mainCanvas) return;

            MachinePrefab machinePrefab = new MachinePrefab();
            Canvas.SetLeft(machinePrefab, clickPoint.X);
            Canvas.SetTop(machinePrefab, clickPoint.Y);
            mainCanvas.Children.Add(machinePrefab);
            Console.WriteLine("object made");
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.GetPosition(mainCanvas);
            if(draggedPrefab != null)
            {
                Canvas.SetLeft(draggedPrefab, mousePoint.X-draggedPoint.X);
                Canvas.SetTop(draggedPrefab, mousePoint.Y-draggedPoint.Y);
            }
        }

        private void rightMouseBtnUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void leftMouseBtnUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedPrefab != null)
            {
                Point clickPoint = e.GetPosition(mainCanvas);
                Canvas.SetLeft(draggedPrefab, clickPoint.X - draggedPoint.X);
                Canvas.SetTop(draggedPrefab, clickPoint.Y - draggedPoint.Y);
                draggedPrefab = null;
                System.Diagnostics.Debug.WriteLine("object released");
            }
        }
    }
}
