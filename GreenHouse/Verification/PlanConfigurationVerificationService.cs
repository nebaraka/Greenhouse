using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Verification
{
    public class PlanConfigurationVerificationService : IPlanConfigurationVerificationService
    {
        private static bool _status;
        public PlanConfigurationVerificationService()
        {
            _status = false;
        }
        public bool PlanConfigurationVerification(string acidity, string light, string temperature, string wetness,
            string acidityInterval, string lightInterval, string temperatureInterval, string wetnessInterval, ref string message)
        {
            string[] temperatureCor = temperature.Split(';');
            string[] temperatureInts = temperatureInterval.Split(';');
            string[] lightCor = light.Split(';');
            string[] lightInts = lightInterval.Split(';');
            string[] acidityCor = acidity.Split(';');
            string[] acidityInts = acidityInterval.Split(';');
            string[] wetnessCor = wetness.Split(';');
            string[] wetnessInts = wetnessInterval.Split(';');
            ParamValues[] paramValues = new ParamValues[temperatureInts.Length];
            try
            {
                for (int i = 0; i < temperatureCor.Length; i++)
                {
                    string[] tempVal = temperatureCor[i].Split('-');
                    paramValues[i].temperature.minValue = Convert.ToDouble(tempVal[0]);
                    paramValues[i].temperature.maxValue = Convert.ToDouble(tempVal[1]);
                    string[] lightVal = lightCor[i].Split('-');
                    paramValues[i].light.minValue = Convert.ToDouble(lightVal[0]);
                    paramValues[i].light.maxValue = Convert.ToDouble(lightVal[1]);
                    string[] acidityVal = acidityCor[i].Split('-');
                    paramValues[i].acidity.minValue = Convert.ToDouble(acidityVal[0]);
                    paramValues[i].acidity.maxValue = Convert.ToDouble(acidityVal[1]);
                    string[] wetnessVal = wetnessCor[i].Split('-');
                    paramValues[i].wetness.minValue = Convert.ToDouble(wetnessVal[0]);
                    paramValues[i].wetness.maxValue = Convert.ToDouble(wetnessVal[1]);
                    paramValues[i].timeSlice = Convert.ToInt32(temperatureInts[i]);
                }
            }
            catch (Exception e)
            {
                message = "Wrong data! Format: \nCorridors(left):min1-max1;min2-max2 etc. \nIntervals(right):val1;val2 etc.";
                return false;
            }
            foreach (ParamValues pv in paramValues)
            {
                if (pv.acidity.minValue > 14 || pv.acidity.minValue < 0 || 
                    pv.acidity.maxValue > 14 || pv.acidity.maxValue < 0 ||
                    pv.acidity.maxValue < pv.acidity.minValue)
                {
                    message = "Wrong data! Format: \nCorridors(left):min1-max1;min2-max2 etc. \nIntervals(right):val1;val2 etc.";
                    return false;
                }
                if (pv.light.minValue > 500 || pv.light.minValue < 0 || 
                    pv.light.maxValue > 500 || pv.light.maxValue < 0 ||
                    pv.light.maxValue < pv.light.minValue)
                {
                    message = "Wrong data! Format: \nCorridors(left):min1-max1;min2-max2 etc. \nIntervals(right):val1;val2 etc.";
                    return false;
                }
                if (pv.temperature.minValue > 80 || pv.temperature.minValue < 0 || 
                    pv.temperature.maxValue > 80 || pv.temperature.maxValue < 0 ||
                    pv.temperature.maxValue < pv.temperature.minValue)
                {
                    message = "Wrong data! Format: \nCorridors(left):min1-max1;min2-max2 etc. \nIntervals(right):val1;val2 etc.";
                    return false;
                }
                if (pv.wetness.minValue > 100 || pv.wetness.minValue < 0 ||
                    pv.wetness.maxValue > 100 || pv.wetness.maxValue < 0 ||
                    pv.wetness.maxValue < pv.wetness.minValue)
                {
                    message = "Wrong data! Format: \nCorridors(left):min1-max1;min2-max2 etc. \nIntervals(right):val1;val2 etc.";
                    return false;
                }
                if (pv.timeSlice <= 0)
                {
                    message = "Wrong data! Format: \nCorridors(left):min1-max1;min2-max2 etc. \nIntervals(right):val1;val2 etc.";
                    return false;
                }
            }
            _status = true;
            return true;
        }
        public bool status()
        {
            //return _status;
            return true;
        }
    }
}
