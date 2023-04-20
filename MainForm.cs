using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorAssign3
{   /* BMI, BMR AND SAVINGS CALCULATOR BY LUCAS SANDGREN, MALMÖ UNIVERSITY C# CLASS SPRING 2023 */
    public partial class MainForm : Form
    {
        private BMICalculator bmiCalc = new BMICalculator();
        private SavingsCalculations saveCalc = new SavingsCalculations();
        private BMRCalculator bmrCalc = new BMRCalculator();
        private double activityLevel = 0;
        
        public MainForm()
        {
            InitializeComponent();
            InitializeGui();
        }
        private void InitializeGui() 
        {
            /* IN/OUT FOR BMI */
            input_Name.Text = "";
            input_Feet.Text = "";
            input_Inch.Text = "";
            input_Centimeters.Text = "";
            input_Weight.Text = "";
            output_Bmi.Text = "";
            output_Weight.Text = "";
            metricButton.Checked = true;
            /* IN/OUT FOR SAVINGS */
            input_Deposit.Text = "";
            input_Monthly.Text = "";
            input_Years.Text = "";
            input_Growth.Text = "";
            input_Fees.Text = "";
            output_Paid.Text = "";
            output_Earned.Text = "";
            output_Balance.Text = "";
            output_Fees.Text = "";
            /* IN/OUT FOR BMR */
            input_Age.Text = "";
        }
        /* Method to calculate BMI when the BMI button is pressed */
        private void calcBmiButton_Click(object sender, EventArgs e)
        {
            if (metricButton.Checked)
            {
                if (!string.IsNullOrEmpty(input_Centimeters.Text) && // Check if inputs are valid
                    !string.IsNullOrEmpty(input_Weight.Text) &&
                     double.TryParse(input_Centimeters.Text, out double height) && 
                     double.TryParse(input_Weight.Text, out double weight))
                {
                    groupBox4.Text = "RESULTS FOR: " + input_Name.Text;
                    bmiCalc.heightInput = double.Parse(input_Centimeters.Text);
                    bmiCalc.weightInput = double.Parse(input_Weight.Text);
                    bmiCalc.CalculateBmiMetric();
                    bmiCalc.SetWeightCategory();
                    output_Bmi.Text = bmiCalc.tempCalc.ToString("N2");
                    output_Weight.Text = bmiCalc.weightCategory.ToString();

                    /* CHANGE TEXT COLOR ACCORDING TO CATEGORY */
                    string weightCategory = bmiCalc.WeightCategory;
                    if (weightCategory == "Underweight")
                    { output_Weight.ForeColor = Color.Yellow; }
                    if (weightCategory == "Normal Weight")
                    { output_Weight.ForeColor = Color.Green; }
                    if (weightCategory.StartsWith("Overweight"))
                    { output_Weight.ForeColor = Color.Red; }
                }
                else
                {MessageBox.Show("Please enter correct values.");}
            }
            else // Imperial calculations
            {
                if (!string.IsNullOrEmpty(input_Inch.Text) && 
                    !string.IsNullOrEmpty(input_Feet.Text) &&
                    double.TryParse(input_Inch.Text, out double inches) &&
                    double.TryParse(input_Feet.Text, out double feet) &&
                    double.TryParse(input_Weight.Text, out double weight))
                {
                    groupBox4.Text = "RESULTS FOR: " + input_Name.Text;
                    bmiCalc.heightInInches = double.Parse(input_Inch.Text);
                    bmiCalc.heightInFeet = double.Parse(input_Feet.Text);
                    bmiCalc.weightInLbs = double.Parse(input_Weight.Text);
                    bmiCalc.ConvertFeetToInch();
                    bmiCalc.CalculateBmiImperial();
                    bmiCalc.SetWeightCategory();
                    output_Bmi.Text = bmiCalc.tempCalc.ToString("N2");
                    output_Weight.Text = bmiCalc.weightCategory.ToString();
                    
                    /* CHANGE TEXT COLOR ACCORDING TO CATEGORY */
                    string weightCategory = bmiCalc.WeightCategory;
                    if (weightCategory == "Underweight")
                    { output_Weight.ForeColor = Color.Yellow; }
                    if (weightCategory == "Normal Weight")
                    { output_Weight.ForeColor = Color.Green; }
                    if (weightCategory.StartsWith("Overweight"))
                    { output_Weight.ForeColor = Color.Red; }
                }
                else
                {
                    MessageBox.Show("Please enter correct values.");
                }
            }
        }
        /* Method to calculate SAVINGS when the BMI button is pressed */
        private void calcSavingsButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(input_Deposit.Text, out double deposit) &&
                double.TryParse(input_Monthly.Text, out double monthly) &&
                double.TryParse(input_Years.Text, out double years) &&
                double.TryParse(input_Growth.Text, out double growth) &&
                double.TryParse(input_Fees.Text, out double fees))
            {
                saveCalc.initialDeposit = deposit;
                saveCalc.totYear = years;
                saveCalc.monthlyDeposit = monthly;
                saveCalc.growth = growth;
                saveCalc.fees = fees;
                saveCalc.CalculateTotalDeposit();
                saveCalc.CalculateTotalEarned();
                saveCalc.CalculateFinal();
                saveCalc.CalculateFees();
                output_Paid.Text = saveCalc.totalDeposit.ToString("0.00");
                output_Earned.Text = saveCalc.totalEarned.ToString("0.00");
                output_Balance.Text = saveCalc.totalSavings.ToString("0.00");
                output_Fees.Text = saveCalc.tempCalc.ToString("0.00");

            }
            else
            {
                MessageBox.Show("Please enter correct values.");
            }
        }

        /* Method to calculate BMR when the BMI button is pressed */
        private void calcBmrButton_Click(object sender, EventArgs e)
        {
            if (metricButton.Checked)
            {
                if (!string.IsNullOrEmpty(input_Centimeters.Text) &&
                !string.IsNullOrEmpty(input_Weight.Text) &&
                !string.IsNullOrEmpty(input_Age.Text) &&
                int.TryParse(input_Age.Text, out int age) &&
                double.TryParse(input_Centimeters.Text, out double height) &&
                double.TryParse(input_Weight.Text, out double weight) &&
                activityLevel >= 0)
                {
                    if (maleButton.Checked)
                    {
                        bmrCalc.isMale = true;
                    }
                    else if (femaleButton.Checked)
                    {
                        bmrCalc.isMale = false;
                    }
                    bmrCalc.heightInput = height;
                    bmrCalc.weightInput = weight;
                    bmrCalc.ageInput = age;
                    bmrCalc.activityFactor = activityLevel;
                    double bmr = bmrCalc.CalculateBMRMetric();
                    double maintainBMR = bmrCalc.CalculateActivity();
                    

                    bmrListbox.Items.Add($"BMR RESULTS FOR {input_Name.Text}");
                    bmrListbox.Items.Add($"");
                    bmrListbox.Items.Add($"Your BMR (calories/day) =  \t\t\t{bmr:F1}");
                    bmrListbox.Items.Add($"Calories to maintain your weight = \t\t{maintainBMR:F1}");
                    bmrListbox.Items.Add($"Calories to lose 0.5 kg per week = \t\t{maintainBMR - 500:F1}");
                    bmrListbox.Items.Add($"Calories to lose 1 kg per week = \t\t{maintainBMR - 1000:F1}");
                    bmrListbox.Items.Add($"Calories to gain 0.5 kg per week = \t\t{maintainBMR + 500:F1}");
                    bmrListbox.Items.Add($"Calories to gain 1 kg per week = \t\t{maintainBMR + 1000:F1}");
                    bmrListbox.Items.Add($"");
                    bmrListbox.Items.Add($"");
                    bmrListbox.Items.Add($"Losing more than 1k calories per day is to be avoided.");
                }
                else
                { MessageBox.Show("Please enter correct values."); }
            }
            else
            {
                if (!string.IsNullOrEmpty(input_Inch.Text) &&
                    !string.IsNullOrEmpty(input_Feet.Text) &&
                    double.TryParse(input_Inch.Text, out double inches) &&
                    double.TryParse(input_Feet.Text, out double feet) &&
                    double.TryParse(input_Weight.Text, out double weight) &&
                    activityLevel >= 0)
                {
                    if (maleButton.Checked)
                    {
                        bmrCalc.isMale = true;
                    }
                    else if (femaleButton.Checked)
                    {
                        bmrCalc.isMale = false;
                    }

                    bmrCalc.heightInInches = inches;
                    bmrCalc.heightInFeet = feet;
                    bmrCalc.weightInLbs = weight;
                    bmrCalc.activityFactor = activityLevel;
                    bmrCalc.ConvertFeetToInch();
                    double bmr = bmrCalc.CalculateBMRImperial();
                    double maintainBMR = bmrCalc.CalculateActivity();
                    

                    bmrListbox.Items.Add($"BMR RESULTS FOR {input_Name.Text}");
                    bmrListbox.Items.Add($"");
                    bmrListbox.Items.Add($"Your BMR (calories/day) =  \t\t\t{bmr:F1}");
                    bmrListbox.Items.Add($"Calories to maintain your weight = \t\t{maintainBMR:F1}");
                    bmrListbox.Items.Add($"Calories to lose 0.5 kg per week = \t\t{maintainBMR - 500:F1}");
                    bmrListbox.Items.Add($"Calories to lose 1 kg per week = \t\t{maintainBMR - 1000:F1}");
                    bmrListbox.Items.Add($"Calories to gain 0.5 kg per week = \t\t{maintainBMR + 500:F1}");
                    bmrListbox.Items.Add($"Calories to gain 1 kg per week = \t\t{maintainBMR + 1000:F1}");
                    bmrListbox.Items.Add($"");
                    bmrListbox.Items.Add($"");
                    bmrListbox.Items.Add($"Losing more than 1k calories per day is to be avoided.");

                }
                else
                {
                    MessageBox.Show("Please enter correct values.");
                }
            }
        }


        /* CHECK MALE/FEMALE */
        private void maleButton_CheckedChanged(object sender, EventArgs e)
        {if (maleButton.Checked){femaleButton.Checked = false;}}
       
        /* CHECK MALE/FEMALE */
        private void femaleButton_CheckedChanged(object sender, EventArgs e)
        {if (femaleButton.Checked){maleButton.Checked = false;}}

        /* BELOW IS RADIO BUTTONS FOR ACTIVITY LEVEL INPUT */
        private void activity_One_CheckedChanged(object sender, EventArgs e)
        {activityLevel = 1.2;}
        private void activity_Two_CheckedChanged(object sender, EventArgs e)
        {activityLevel = 1.375;}
         private void activity_Three_CheckedChanged(object sender, EventArgs e)
        {activityLevel = 1.55;}
         private void activity_Four_CheckedChanged(object sender, EventArgs e)
        {activityLevel = 1.725;}
        private void activity_Five_CheckedChanged(object sender, EventArgs e)
        {activityLevel = 1.9;}

        /* CHECK METRIC/IMPERIAL */
        private void metricButton_CheckedChanged(object sender, EventArgs e)
        {
            input_Inch.Visible = false;
            input_Feet.Visible = false;
            input_Centimeters.Visible = true;
            label2.Text = "HEIGHT (CM)";
            label3.Text = "WEIGHT (KG)";
        }
        private void imperialButton_CheckedChanged(object sender, EventArgs e)
        {
            input_Inch.Visible = true;
            input_Feet.Visible = true;
            input_Centimeters.Visible = false;
            label2.Text = "HEIGHT (FT AND IN)";
            label3.Text = "WEIGHT (LBS)";
        }
        /* RESET GUI */
        private void Reset_One_Click(object sender, EventArgs e)
        {   
            InitializeGui();
            bmrListbox.Items.Clear();
            bmiCalc.heightInput = 0;
            bmiCalc.weightInput = 0;
            bmiCalc.heightInInches = 0;
            bmiCalc.heightInFeet = 0;
            bmiCalc.weightInLbs = 0;
            bmrCalc.heightInput = 0;
            bmrCalc.weightInput = 0;
            bmrCalc.ageInput = 0;
            bmrCalc.activityFactor = 0;
            saveCalc.initialDeposit = 0;
            saveCalc.totYear = 0;
            saveCalc.monthlyDeposit = 0;
            saveCalc.growth = 0;
            saveCalc.fees = 0;
            saveCalc.totalSavings = 0;
            saveCalc.totalDeposit = 0;
            saveCalc.totalEarned = 0;
            saveCalc.finalBalance = 0;
            saveCalc.tempCalc = 0;
        }
    }
}
