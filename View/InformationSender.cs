using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ViewModel;

namespace View
{
    public class InformationSender : Window
    {
        public InformationSender(ShopViewModel vm)
        {
            this.vm = vm;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            vm.Start = DateTime.Now.Second;
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second - vm.Start > 10)
            {
                vm.NotificationVisibility = "visible";
            }
            CommandManager.InvalidateRequerySuggested();
        }
        private ShopViewModel vm;  
    }
}

