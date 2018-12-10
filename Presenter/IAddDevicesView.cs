using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presenter
{
    public interface IAddDevicesView : IView
    {
        event Delegates.addDel add;
        event Delegates.del delete;
        void addDeviceToList(string s, Location l);
        void deleteDeviceFromList();
        //void addToList(string s);
        ComboBox currentComboBox { get; }
    }

    public static class Delegates
    {
        public delegate void del(string s);
        public delegate void addDel(object o, Location l);
    }
}
