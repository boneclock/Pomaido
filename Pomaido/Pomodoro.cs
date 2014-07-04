using System;

namespace Pomaido
{

    public enum PomodoroRoundType { 
        Work,
        ShortBreak,
        LongBreak
    }

    public class PomodoroSettings
    {
        public TimeSpan WorkRoundLength { get; set; }
        public TimeSpan ShortBreakRoundLength { get; set; }
        public TimeSpan LongBreakRoundLength { get; set; }
        public int NbWorkRoundBeforeLongBreak { get; set; }
    }

    public class Pomodoro
    {
        private int nbWorkRoundDone;
        private PomodoroSettings settings;

        public TimeSpan TimeUntilEndOfTheRound { get; private set; }
        public PomodoroRoundType CurrentRoundType { get; private set; }

        public event Action RoundSwitched;

        public Pomodoro(PomodoroSettings pomodoroSettings)
        {
            settings = pomodoroSettings;
            nbWorkRoundDone = 0;
            StartWorkRound(false);
        }

        public void Tick()
        {
            TimeUntilEndOfTheRound -= TimeSpan.FromSeconds(1);
            
            if (TimeUntilEndOfTheRound.TotalSeconds == 0) {
                StartNextRound();
            }
        }

        private void StartNextRound()
        {
            if (CurrentRoundType != PomodoroRoundType.Work) {
                StartWorkRound(true);
                return;
            }

            if (++nbWorkRoundDone % settings.NbWorkRoundBeforeLongBreak == 0) {
                StartLongBreakRound(true);
            } else {
                StartShortBreakRound(true);
            }
        }

        private void StartShortBreakRound(bool sendNotification)
        {
            TimeUntilEndOfTheRound = settings.ShortBreakRoundLength;
            CurrentRoundType = PomodoroRoundType.ShortBreak;

            if (sendNotification) {
                RoundSwitched();
            }
        }

        private void StartLongBreakRound(bool sendNotification)
        {
            TimeUntilEndOfTheRound = settings.LongBreakRoundLength;
            CurrentRoundType = PomodoroRoundType.LongBreak;

            if (sendNotification) {
                RoundSwitched();
            }
        }

        private void StartWorkRound(bool sendNotification)
        {
            TimeUntilEndOfTheRound = settings.WorkRoundLength;
            CurrentRoundType = PomodoroRoundType.Work;

            if (sendNotification) {
                RoundSwitched();
            }
        }

    }
}
