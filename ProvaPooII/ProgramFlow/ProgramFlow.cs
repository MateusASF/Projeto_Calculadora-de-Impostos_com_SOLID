using ProvaPooII.Infraestructure;
using ProvaPooII.Screens;
using ProvaPOOII.Domain;
using ProvaPOOII.Services;
using ProvaPOOII.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPooII.ProgramFlow
{
    public class ProgramFlow : IProgramFlow
    {
        private readonly ITaxCalculator _taxCalculator;

        public ProgramFlow(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public void Navigate() //da pra melhorar?
        {
            ShowFirstScreen();
            ShowTableCalculation();
            double value = InputUserIR();
            ShowResult(value);

        }

        public double InputUserIR()
        {
            Input _input = new();

            TaxCalculator _tax = new();

            _input.InputForCalculation = double.Parse(ScreenConfiguration.GetInput(ScreensProgram.InputUser, ValidateInput, ScreensProgram.InputUserInvalid));

            return _tax.TaxCalculation(_input.InputForCalculation);
        }


        private bool ValidateInput(string obj)
        {
            return !string.IsNullOrWhiteSpace(obj);
        }

        private void ShowFirstScreen()
        {
            Console.WriteLine(ScreensProgram.HomeScreen);
            Console.ReadKey();
        }

        private void ShowTableCalculation()
        {
            Console.Clear();
            Console.WriteLine(ScreensProgram.CalculationTable);
            Console.ReadKey();
        }

        private void ShowResult(double calculatedEntry)
        {
            Console.Clear();
            Console.WriteLine(ScreensProgram.CalculationCompleted);
            Console.WriteLine($"{ScreensProgram.Result} {calculatedEntry:C}");
            Console.ReadKey();
        }


    }


}
