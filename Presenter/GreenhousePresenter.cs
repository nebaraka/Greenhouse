using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using GreenHouse;

namespace Presenter
{
    public class GreenhousePresenter
    {
        private IKernel kernel;
        private IGreenhouse model;
        private IGreenhouseView view;
    }
}
