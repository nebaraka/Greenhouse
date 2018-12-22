using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Verification
{
    public interface IAddDevicesVerificationService
    {
        bool addDevicesVerification(string x, string y, ref string message);
        bool status();
    }
}
