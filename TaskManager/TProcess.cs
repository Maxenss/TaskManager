using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TProcess
    {
        public enum Status { NotStarted, Started, Executed, Canceled }

        public static  string NOTSTARTED = "В очереди";
        public static string STARTED = "Выполняется";
        public static string CANCELED = "Отменененный";
        public static string EXECUTED = "Выполненный";

        #region Поля 
        // Только 10 символов
        private string mName;

        // ID - процесса
        private int mId;

        // Количество тактов для выполнения процесса
        private int mCountOfTactsAll;

        // Время создание процесса
        private string mTimeOfCreate;

        // Время, когда процесс выполнился
        private string mTimeOfCompleted;


        private string mTimeOfStartExecute;

        // Количество тактов, оставшихся для выполнения процесса
        private int mCountOfTactsToComplete;

        // Статус процесса
        private Status mTaskStatus;

        // Приоритет
        private int mPriority;

        // Кол-во оперативной памяти, занимаемой процессом
        private int mRAM;

        private long mTimeDelayToExecuteMs;

        private long mTimeDelayToCompleted;

        private long mTimeDelayStartExecute;

        private string mStatusString;
        #endregion

        #region Конструктор
        public TProcess(string mName,
            int mId,
            int mCountOfTactsAll,
            string mTimeOfCreate,
            int mCountOfTactsToComplete,
            Status mTaskStatus,
            int mPriority,
            int RAM, 
            string statusString)
        {
            this.mName = mName;
            this.mId = mId;
            this.mCountOfTactsAll = mCountOfTactsAll;
            this.mTimeOfCreate = mTimeOfCreate;
            this.mCountOfTactsToComplete = mCountOfTactsAll;
            this.mTaskStatus = mTaskStatus;
            this.mPriority = mPriority;
            this.mRAM = RAM;
            this.mStatusString = statusString;
        }
        #endregion

        #region Свойства
        public string Name { get => mName; }
        public int Id { get => mId; }
        public int CountOfTactsAll { get => mCountOfTactsAll; set => mCountOfTactsAll = value; }
        public string TimeOfCreate { get => mTimeOfCreate; }
        public int CountOfTactsToComplete { get => mCountOfTactsToComplete; set => mCountOfTactsToComplete = value; }
        private Status MTaskStatus { get => mTaskStatus; set => mTaskStatus = value; }
        public int Priority { get => mPriority; set => mPriority = value; }
        public int RAM { get => mRAM; set => mRAM = value; }
        public string StatusString { get => mStatusString; set => mStatusString = value; }
        public string TimeOfCompleted { get => mTimeOfCompleted; set => mTimeOfCompleted = value; }
        public long TimeDelayToExecuteMs { get => mTimeDelayToExecuteMs; set => mTimeDelayToExecuteMs = value; }
        public long TimeDelayToCompleted { get => mTimeDelayToCompleted; set => mTimeDelayToCompleted = value; }
        public string TimeOfStartExecute { get => mTimeOfStartExecute; set => mTimeOfStartExecute = value; }
        public long TimeDelayStartExecute { get => mTimeDelayStartExecute; set => mTimeDelayStartExecute = value; }
        #endregion

        long GetMS(DateTime dateTime1, DateTime dateTime2) {
            TimeSpan delay = dateTime2 - dateTime1;
            long ms = (long)delay.TotalMilliseconds;
            return ms;
        }

        public long CalculateDelayTimeToCompleted()
        {
            mTimeDelayToCompleted = GetMS( DateTime.Parse(TimeOfCreate), DateTime.Parse(TimeOfCompleted));

            return 0;
        }

        public long CalculateDelayTimeToComplete()
        {
            mTimeDelayStartExecute = GetMS(DateTime.Parse(TimeOfCreate), DateTime.Parse(TimeOfStartExecute));

            return 0;
        }
    }
}
