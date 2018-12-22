using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Verification
{
    public class GreenhouseVerificationService : IGreenhouseVerificationService
    {
        public bool GreenhouseVerification()
        {
            AddDevicesVerificationService ads = new AddDevicesVerificationService();
            PlanConfigurationVerificationService pcs = new PlanConfigurationVerificationService();
            bool result = false;
            if (ads.status() &&
                pcs.status())
                result = true;
            return result;
        }
    }
}
