using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineOverheating
{
    class Program
    {
        static void Main(string[] args)
        {
            int ovhTemp = 110;
            int i = 10;
            double[] m = { 20, 75, 100, 105, 75, 0 };
            double[] v = { 0, 75, 150, 200, 250, 300};
            double hm = 0.01;
            double hv = 0.0001;
            double c = 0.1;
            int testTime;
            int outsideTemperature;

            Engine engine = new GasolineEngine(i, ovhTemp, m, v, hm, hv, c);
            TestStand stand = new TestStand(engine);
            stand.Notify += ShowMesage;                         //Добавляем обработчик в событие

            Console.WriteLine("Enter outside temperature: ");
            while (!int.TryParse(Console.ReadLine(), out outsideTemperature))
            {
                Console.WriteLine("Input Error! Please enter an integer.");
            }

            testTime = stand.TestEngine(outsideTemperature);
            Console.WriteLine($"Time to overheat - {testTime} seconds.");
            Console.ReadKey();
        }

        static void ShowMesage(object sender, StandEvents st)   //Обработчик события тестового стенда
        {
            Console.WriteLine(st.Message);
        }
    }
}
