using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAssign3
{
    internal class SavingsCalculations
    {
        public double initialDeposit { get; set; }
        public double totYear { get; set; }
        public double monthlyDeposit { get; set; }
        public double growth { get; set; }
        public double fees { get; set; }
        public double totalSavings { get; set; }
        public double totalDeposit { get; set; }
        public double totalEarned { get; set; }
        public double finalBalance { get; set; }  
        public double tempCalc { get; set; }    

        static private double NUM_OF_MONTHS = 12;

        public double CalculateTotalDeposit()
        {
            double currentBalance = initialDeposit;
            double monthlyRate = (growth / 100) / NUM_OF_MONTHS;
            int numOfMonths = (int)(totYear * NUM_OF_MONTHS);

            for (int i = 1; i <= numOfMonths; i++)
            {
                currentBalance += monthlyDeposit;
                currentBalance += (monthlyRate * currentBalance);
                totalDeposit += monthlyDeposit;
            }

            return totalDeposit;
        }


        public double CalculateTotalEarned() // TOTAL EARNINGS
        {
            double finalBalance = FinalBalance();
            double amountEarned = finalBalance - totalDeposit;
            totalEarned = amountEarned;
            return totalEarned;
        }

        private double FinalBalance() // TOTAL BALANCE
        {
            {
                double finalBalance = initialDeposit;
                double monthlyRate = (growth / 100) / NUM_OF_MONTHS;
                int numOfMonths = (int)(totYear * NUM_OF_MONTHS);
                for (int i = 1; i < numOfMonths; i++)
                {
                    finalBalance += monthlyDeposit;
                    finalBalance += (monthlyRate * finalBalance) ;
                }
                finalBalance = finalBalance + 1200;
                return finalBalance;
            }
        }
        public double CalculateFinal() // TOTAL SUM
        {
            totalSavings = totalEarned+ totalDeposit;
            return totalSavings;
        }
        public double CalculateFees() // FEES
        {
            tempCalc = totalSavings * (fees/100);
            return tempCalc;
        }
    }
}
