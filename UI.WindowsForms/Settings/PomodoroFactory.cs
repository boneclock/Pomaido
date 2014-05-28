using Pomaido;
using System;
using System.Configuration;

namespace UI.WindowsForms.Settings
{
    class PomodoroFactory : IPomodoroFactory
    {
        public Pomaido.Pomodoro Create()
        {
            return new Pomodoro(new PomodoroSettings {
                WorkRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroWorkRoundLength"]),
                ShortBreakRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroShortBreakRoundLength"]),
                LongBreakRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroLongBreakRoundLength"]),
                NbWorkRoundBeforeLongBreak = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPomodoroNbWorkRoundBeforeLongBreak"]),
            });
        }
    }
}
