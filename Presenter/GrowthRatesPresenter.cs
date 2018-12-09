using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using GreenHouse;

namespace Presenter
{
    class GrowthRatesPresenter
    {
        private IKernel kernel;
        private IGreenhouse model;
        private IGrowthRatesView view;

        public GrowthRatesPresenter(IKernel k, IGreenhouse g, IGrowthRatesView v)
        {
            kernel = k;
            model = g;
            view = v;

            model.tickInfo2 += tickUpdate;
        }

        public void tickUpdate(double a, double l, double t, double w)
        {
            view.showAcidity(a);
            view.showLight(l);
            view.showTemperature(t);
            view.showWetness(w);
            //graphs))
        }

        public void run()
        {

            view.Show();
        }
    }
}
