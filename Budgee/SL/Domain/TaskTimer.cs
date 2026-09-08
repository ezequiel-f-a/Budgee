using System;
using System.Threading;

namespace SL.Domain
{
    /// <summary>
    /// Temporizador que permite ejecutar determinada acción en un hilo propio cada determinado tiempo.
    /// También permite incluir una cantidad de iteraciones máximas.
    /// </summary>
    public class TaskTimer
    {
        public Action Action { get; private set; }
        public int Delay { get; private set; }
        public int? Iterations { get; private set; }
        public int Iterations_Count { get; private set; }
        public long? Timeout { get; private set; }
        public long Elapsed_Time { get; private set; }
        public bool? Started_After_Delay { get; private set; }

        private System.Timers.Timer timer = null;
        private Thread taskForBeforeDelay = null;


        public TaskTimer(Action action, int delay)
        {
            Action = action;
            Delay = delay;
        }
        public TaskTimer(Action action, int delay, int iterations)
        {
            Action = action;
            Delay = delay;
            Iterations = iterations;
        }
        public TaskTimer(Action action, int delay, long timeout)
        {
            Action = action;
            Delay = delay;
            Timeout = timeout;
        }
        public TaskTimer(Action action, int delay, int iterations, long timeout)
        {
            Action = action;
            Delay = delay;
            Iterations = iterations;
            Timeout = timeout;
        }

        public void Start(bool start_after_delay = false)
        {
            Stop(); //Si ya habia sido iniciado antes, lo detenemos para reiniciar

            Started_After_Delay = start_after_delay;

            if (Iterations != null)
                Iterations_Count = 0; //Reseteamos las iteraciones

            if (!start_after_delay)
            {
                taskForBeforeDelay = new Thread(
                    new ThreadStart(delegate
                    {
                        Exec_Action(null, null);
                    }));
                taskForBeforeDelay.Start();
            }

            timer = new System.Timers.Timer();
            timer.Elapsed += Exec_Action;
            timer.Interval = Delay;
            timer.Start();

        }
        public void Stop()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Elapsed -= Exec_Action;
                timer.Dispose();
                timer = null;
            }
            if (taskForBeforeDelay != null)
            {
                taskForBeforeDelay.Abort();
                taskForBeforeDelay = null;
            }

            //reseteamos variables
            Iterations_Count = 0;
            Elapsed_Time = 0;
            Started_After_Delay = null;
        }
        [Obsolete("Método aún no desarrollado")]
        public void Wait(int delay_ms)
        {
            throw new NotImplementedException();
        }
        public void Change(Action action, int delay_ms, int? iterations = null)
        {
            Stop();
            this.Action = action;
            this.Delay = delay_ms;
            this.Iterations = iterations;
        }
        void Exec_Action(object source, System.Timers.ElapsedEventArgs e)
        {
            //Filtros

            if (Iterations != null && Iterations_Count >= Iterations)
            {
                this.Stop();
                return;
            }

            if (Timeout != null && Elapsed_Time > Timeout)
            {
                this.Stop();
                return;
            }

            //Accion

            Iterations_Count++;

            //Sumamos tiempo transcurrido
            if (Started_After_Delay != null)
            {
                if (Iterations_Count > 0 && (bool)Started_After_Delay) Elapsed_Time += Delay;
                else if (Iterations_Count > 1 && !(bool)Started_After_Delay) Elapsed_Time += Delay;
            }

            Action.Invoke();
        }
    }
}
