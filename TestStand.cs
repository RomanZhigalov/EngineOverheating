using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineOverheating
{
    class TestStand
    {

        public event TestStandHandler Notify;

        private readonly Engine engine;

        private int testTime;
        public TestStand (Engine engine)
        {
            this.engine = engine;
        }

        public int TestEngine(double outsideTemperature)
        {
            engine.Start(outsideTemperature);
            while (engine.IsAlive)
            {
                engine.Stroke();
                testTime++;
                if (engine.EngineTemperature >= engine.OverheatTemperature)
                {
                    engine.Stop();
                    Notify?.Invoke(this, new StandEvents("Engine overheated!"));
                }
                if (testTime > 6000)
                {
                    engine.Stop();
                    Notify?.Invoke(this, new StandEvents("Engine cannot be overheated."));
                }
            }
            return testTime;
        }
    }
}
