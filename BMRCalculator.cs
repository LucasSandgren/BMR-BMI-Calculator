using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAssign3
{
    internal class BMRCalculator
    {
        public bool isMale { get; set; }
        public double weightInput { get; set; } 
        public double heightInput { get; set; }
        public double heightInInches { get; set; }
        public double heightInFeet { get; set; }
        public double weightInLbs { get; set; }
        public int ageInput { get; set; }
        public double activityLevel { get; set; }
        public double maintainWeightBMR { get; set; }
        public double activityFactor { get; set; }
        

        double BMR = 0;

        public double CalculateBMRMetric()
        {
            
            if (isMale)
            {
                BMR = (10 * weightInput) + (6.25 * heightInput) - (5 * ageInput) + 5;
            }
            else
            {
                BMR = (10 * weightInput) + (6.25 * heightInput) - (5 * ageInput) - 161;
            }
            return BMR;
        }

        public double CalculateBMRImperial()
        {
            
            if (isMale)
            {
                BMR = (10 * weightInLbs) + (6.25 * heightInInches) - (5 * ageInput) + 5;
            }
            else
            {
                BMR = (10 * weightInLbs) + (6.25 * heightInInches) - (5 * ageInput) - 161;
            }
            return BMR;
        }
        

        public double CalculateActivity()
        {
            maintainWeightBMR = BMR * activityFactor;
            return maintainWeightBMR;
        }
        public double ConvertFeetToInch() // Convert feet and inches to only inches
        { return (heightInFeet * 12) + heightInInches; }


    }
}
