using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Verification
{
    public class AddDevicesVerificationService : IAddDevicesVerificationService
    {
        private static bool _status;
        public AddDevicesVerificationService()
        {
            _status = false;
        }
        public bool addDevicesVerification(string x, string y, ref string message)
        {
            int result;
            bool success = false;
            success = Int32.TryParse(x, out result);
            if (result >= 20 || result < 0) success = false;
            if (!success)
            {
                message = "Wrong coordinates! Please input the again.";
                return success;
            }

            success = Int32.TryParse(y, out result);
            if (result >= 20 || result < 0) success = false;
            if (!success) message = "Wrong coordinates! Please input the again.";
            if (success) _status = true;
            return success;
        }
        public bool status()
        {
            return _status;
        }
    }
}
