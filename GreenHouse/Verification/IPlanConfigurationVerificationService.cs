using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Verification
{
    public interface IPlanConfigurationVerificationService
    {
        bool PlanConfigurationVerification(string acidity, string light, string temperature, string wetness, 
            string acidityInterval, string lightInterval, string temperatureInterval, string wetnessInterval, 
            ref string message);
        bool status();
    }
}
