using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineOverheating
{
    abstract class Engine
    {
        public abstract double EngineTemperature { get; }           //Текущая температура двигателя
        public abstract int OverheatTemperature { get; }            //Температура перегрева
        public abstract bool IsAlive { get; }                       //Заведен ли двиигатель    
        public abstract void Start(double outsideTemperature);      //Запуск двигателя 
        public abstract void Stroke();                              //Цикл работы двигателя
        public abstract void Stop();                                //Остановка двигателя
    }
}
