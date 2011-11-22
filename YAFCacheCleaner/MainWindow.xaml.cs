using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace YAFCacheCleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread cacheClearThread;

        public MainWindow()
        {
            InitializeComponent();
            MinimizeToTray.Enable(this);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 14400000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            cacheClearThread = new Thread(new ThreadStart(CacheClear));
            cacheClearThread.Start();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CacheClear();
            
        }

        private static void CacheClear()
        {
            YAFDB db = new YAFDB();
            Debug.WriteLine(db.ClearCache().ToString());
            
        }
    }
}
