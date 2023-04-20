using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAssign3
{
    internal class BMICalculator
    {
        public double heightInput { get; set; }
        public double weightInput { get; set; }
        public double heightInInches { get; set; }
        public double heightInFeet { get; set; }
        public double weightInLbs { get; set; }
        public string weightCategory { get; set; }
        public double tempCalc { get; set; }    
        

        public double ConvertFeetToInch() // feet*12 + inches to get total inches value
        {return (heightInFeet * 12) + heightInInches;}
        public double CalculateBmiMetric()
        {
            double heightInMeters = heightInput / 100;
            tempCalc = weightInput / (heightInMeters*heightInMeters);
            return tempCalc;
        }

        public double CalculateBmiImperial()
        {   
            double heightInInches = ConvertFeetToInch();
            tempCalc = weightInLbs / (heightInInches * heightInInches) * 703;
            return tempCalc;
        }

        public string WeightCategory
        {get{return weightCategory;}}

        public void SetWeightCategory()
        {
            if (tempCalc > 0 && tempCalc < 18.5)
            {weightCategory = "Underweight";}
            if (tempCalc > 18.5 && tempCalc < 24.9)
            {weightCategory = "Normal Weight";}
            if (tempCalc > 25.0 && tempCalc < 29.9)
            {weightCategory = "Overweight (Pre-Obesity)";}
            if (tempCalc > 30.0 && tempCalc < 34.9)
            {weightCategory = "Overweight (Obesity class I";}
            if (tempCalc > 35.0 && tempCalc < 39.9)
            {weightCategory = "Overweight (Obesity class II";}
            if (tempCalc > 40)
            {weightCategory = "Overweight (Obesity class III";}
        }
    }
}
