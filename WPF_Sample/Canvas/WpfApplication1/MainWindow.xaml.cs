using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VectorDraw.Actions;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Render;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            //trick to get the Control Window Handle
            //WindowInteropHelper windowHwnd = new WindowInteropHelper(this);
            //IntPtr handle = windowHwnd.Handle;
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {

            vdraw.Open(null);
            vdraw.SelectionMode = vdrawWpfControlLibrary.vdrawControl.vdSelectionModeEnum.None;
            vdraw.PanMouseButton = vdrawWpfControlLibrary.vdrawControl.PanMouseButtonsEnum.Right;
        }
        private void New(object sender, RoutedEventArgs e)
        {
            
            vdraw.New();
        }
        private void ZoomExtents(object sender, RoutedEventArgs e)
        {
            vdraw.ZoomExtends();
        }
        private void BackGround(object sender, RoutedEventArgs e)
        {
        

            vdraw.Background = new SolidColorBrush(Color.FromArgb(255,0, 0, 255));
            vdraw.Redraw();
        }
        private void ChangeCursor(object sender, RoutedEventArgs e)
        {
            vdraw.vdCursor = Cursors.Arrow;
        }
        private void Layers(object sender, RoutedEventArgs e)
        {
            VectorDraw.Professional.Dialogs.LayersDialog.Show(vdraw.document);
        }
        private void ItemsRed(object sender, RoutedEventArgs e)
        {
            foreach (vdFigure  item in vdraw.document.ActiveLayOut.Entities)
            {
                item.PenColor = new vdColor(System.Drawing.Color.Red);
                item.Update();
            }
            vdraw.Redraw();
        }
        private void Axis(object sender, RoutedEventArgs e)
        {
            vdraw.ShowAxis = !vdraw.ShowAxis;
            vdraw.Redraw();
        }
    }
}
