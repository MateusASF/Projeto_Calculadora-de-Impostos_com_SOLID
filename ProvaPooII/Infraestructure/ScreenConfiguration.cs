using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPooII.Infraestructure
{
    public static class ScreenConfiguration
    {
        public static string Show(string screen, string errorMessage = "")
        {
            var response = string.Empty;
            Console.Clear();
            Console.WriteLine(screen);

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                Console.WriteLine();
                var defaultBackgroundColor = Console.BackgroundColor;
                var defaultForegroundColor = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(errorMessage);
                Console.BackgroundColor = defaultBackgroundColor;
                Console.ForegroundColor = defaultForegroundColor;
            }
            

            response = Console.ReadLine().Trim();

            return response;
        }

        public static string GetInput(string screen, Predicate<string> predicate, string customMessage = null)
        {
            string response;
            var messages = string.Empty;

            while (!predicate.Invoke(response = Show(screen, messages)))
                messages = customMessage ?? "O campo não pode ser vazio";

            return response;
        }
    }
}
