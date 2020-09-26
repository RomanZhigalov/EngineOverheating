using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineOverheating
{
    class GasolineEngine : Engine
    {
        private double engineTemperature;
        private readonly int overheatTemperature;
        private double outsideTemperature;          //Окружающая температура                                                   
        private double currentM;                       
        private double currentV;                          
        private double vh;                          //Скорость нагрева двигателя
        private double vc;                          //Скорость охлаждения двигателя
        private bool isAlive;                       
        private int index;      

        public override double EngineTemperature { get { return engineTemperature; } }
        public override int OverheatTemperature { get { return overheatTemperature; } }
        public override bool IsAlive { get { return isAlive; } }    
        public  int I { get; private set; }                         //Момент инерции двигателя
        public  double[] M { get; private set; }                    //Крутящий момент двигателя   
        public  double[] V { get; private set; }                    //Скорость вращения коленвала 
        public double Hm { get; private set; }                      //Коэффициент зависимости скорости нагрева от крутящего момента
        public double Hv { get; private set; }                      //Коэффициент зависимости скорости нагрева от скорости вращения коленвала
        public double C { get; private set; }                       //Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды

        public override void Start(double outsideTemp)
        {
            outsideTemperature = outsideTemp;
            engineTemperature = outsideTemp;
            isAlive = true;
            index = 0;
            currentM = M[index];
            currentV = V[index];
        }

        public override void Stroke()
        {
            if (currentV >= V[index + 1])
            {
                index++;
            }
            currentV += currentM / I;                                       //Ускоряем каленвал
            currentM = M[index] + (M[index + 1] - M[index]) * 
                (currentV - V[index]) / (V[index + 1] - V[index]);          //Увеличиваем крутящий момент
            vh = currentM * Hm + (currentV * currentV) * Hv;                //Рассчитываем скорость нагрева
            vc = C * (outsideTemperature - engineTemperature);              //Рассчитываем скорость охлаждения
            engineTemperature += (vh + vc);                                 //Изменяем температуру двигателя 
        }
        public override void Stop()
        {
            isAlive = false;
        }

        public GasolineEngine(int i, int ovhTemp,
            double[] m, double[] v,
            double hm, double hv, double c)
        {
            overheatTemperature = ovhTemp;
            I = i;
            M = m;
            V = v;
            Hm = hm;
            Hv = hv;
            C = c;
            if (M.Length != V.Length)
            {
                throw new Exception("Variables M[] & V[] must have same length");
            }
        }
    }
}
