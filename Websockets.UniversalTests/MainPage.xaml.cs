using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Websockets.SharedTest;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Websockets.UniversalTests
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Test sample;

        public MainPage()
        {
            this.InitializeComponent();

            Websockets.Net.WebsocketConnection.Link();

            sample = new Test();
            sample.OnOutput += Sample_OnOutput;
            sample.DoTest(true);

            Application.Current.Suspending += Current_Suspending;
            Window.Current.Closed += Window_Closed;
        }

        private void Current_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            sample.EndTest();
        }

        private void Sample_OnOutput(object sender, string e)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { Out.Items.Add(e); });
        }

        private void Window_Closed(object sender, Windows.UI.Core.CoreWindowEventArgs e)
        {
            sample.EndTest();
        }
    }
}
