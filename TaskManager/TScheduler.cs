using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TaskManager
{
    public class TScheduler
    {
        #region Коллекции процессов

        // Лист с процессами в стеке
        private ObservableCollection<TProcess> mTProcessList;
        // Лист с отмененными процессами
        private ObservableCollection<TProcess> mCanceledProcessList;
        // Лист с выполненными процессами
        private ObservableCollection<TProcess> mCompletedProcessList;
        // Лист с выполняемым процессом
        private ObservableCollection<TProcess> mExecutedProcessesList;
        // Лист с выполняемым процессом на первом ресурсе
        private ObservableCollection<TProcess> mExecutedResource1ProcessesList;
        // Лист с выполняемы процессом на втором ресурсе
        private ObservableCollection<TProcess> mExecutedResource2ProcessesList;
        // Лист с выполняемым процессом на третьем ресурсе
        private ObservableCollection<TProcess> mExecutedResource3ProcessesList;
        // Очередь к первому ресурсу
        private ObservableCollection<TProcess> mQueueResource1ProcessesList;
        // Очередь ко второму ресурсу
        private ObservableCollection<TProcess> mQueueResource2ProcessesList;
        // Очередь к третьему ресурсу
        ObservableCollection<TProcess> mQueueResource3ProcessesList;

        #endregion

        #region Закрытые поля

        // Количество оперативной памяти
        private int mCountOfRAM;

        // Количество используемой RAM 
        private int mCountOfRAMUsed;

        // Количество свободной памяти
        private int mCountOfRAMFree;

        // Частота процессора
        private int mCPUFrequency;

        // Количество генерируемых процессов при нажатии на клавишу
        private int mCountOfGenerateTasks;

        // Время генерации случайного процесса
        private int mRandomGenerateTaskTime;

        // Минимальное количество тактов для выполнения процесса
        private int mRangeTactsForTaskMin;

        // Максимальное количество тактов для выполнения процесса
        private int mRangeTactsForTaskMax;

        // Минимальное количество RAM для процесса
        private int mRangeRAMForTaskMin;

        // Максимальное количество RAM для процесса
        private int mRangeRAMForTaskMax;

        // Объект для генерации случайных значений 
        private Random mRandom;

        // Переменная для идентификации процессов
        private int mIDIncrementerProcess;

        private long mAverageDelayTimeToCompleted;

        private long mAverageDelayTimeToStart;

        #endregion

        #region Публичные свойства

        public int CountOfRAM { get => mCountOfRAM; }
        public int CountOfRAMUsed { get => mCountOfRAMUsed; }
        public int CountOfRAMFree { get => mCountOfRAMFree; }
        public int CPUFrequency { get => mCPUFrequency; }
        public long AverageDelayTimeToCompleted { get => mAverageDelayTimeToCompleted; set => mAverageDelayTimeToCompleted = value; }
        public long AverageDelayTimeToStart { get => mAverageDelayTimeToStart; set => mAverageDelayTimeToStart = value; }

        #endregion

        #region Публичные get-методы для коллекций
        public ObservableCollection<TProcess> GetProcessList()
        {
            return mTProcessList;
        }

        public ObservableCollection<TProcess> GetCanceledProcessList()
        {
            return mCanceledProcessList;
        }

        public ObservableCollection<TProcess> GetCompletedProcessList()
        {
            return mCompletedProcessList;
        }

        public ObservableCollection<TProcess> GetResource1ProcessesList()
        {
            return mExecutedResource1ProcessesList;
        }

        public ObservableCollection<TProcess> GetResource2ProcessesList()
        {
            return mExecutedResource2ProcessesList;
        }

        public ObservableCollection<TProcess> GetResource3ProcessesList()
        {
            return mExecutedResource3ProcessesList;
        }

        public ObservableCollection<TProcess> GetOnExecuteProcessesList()
        {
            return mExecutedProcessesList;
        }

        public ObservableCollection<TProcess> GetQueueResource1ProcessesList()
        {
            return mQueueResource1ProcessesList;
        }

        public ObservableCollection<TProcess> GetQueueResource2ProcessesList()
        {
            return mQueueResource2ProcessesList;
        }

        public ObservableCollection<TProcess> GetQueueResource3ProcessesList()
        {
            return mQueueResource3ProcessesList;
        }
        #endregion

        #region Конструктор класса

        public TScheduler(int mCountOfRAM,
            int mCPUFrequency,
            int mCountOfGenerateTasks,
            int mRandomGenerateTaskTime,
            int mRangeTactsForTaskMin,
            int mRangeTactsFrequencyForTaskMax,
            int mRangeRAMForTaskMin,
            int mRangeRAMForTaskMax)
        {
            this.mCountOfRAM = mCountOfRAM;
            this.mCountOfRAMFree = this.mCountOfRAM;
            this.mCPUFrequency = mCPUFrequency;
            this.mCountOfGenerateTasks = mCountOfGenerateTasks;
            this.mRandomGenerateTaskTime = mRandomGenerateTaskTime;
            this.mRangeTactsForTaskMin = mRangeTactsForTaskMin;
            this.mRangeTactsForTaskMax = mRangeTactsFrequencyForTaskMax;
            this.mRangeRAMForTaskMin = mRangeRAMForTaskMin;
            this.mRangeRAMForTaskMax = mRangeRAMForTaskMax;
            this.mRandom = new Random();
            this.mIDIncrementerProcess = 1;

            // Инициализация коллекций
            this.mTProcessList = new ObservableCollection<TProcess>();
            this.mCanceledProcessList = new ObservableCollection<TProcess>();
            this.mCompletedProcessList = new ObservableCollection<TProcess>();
            this.mExecutedProcessesList = new ObservableCollection<TProcess>();
            this.mExecutedResource1ProcessesList = new ObservableCollection<TProcess>();
            this.mExecutedResource2ProcessesList = new ObservableCollection<TProcess>();
            this.mExecutedResource3ProcessesList = new ObservableCollection<TProcess>();
            this.mQueueResource1ProcessesList = new ObservableCollection<TProcess>();
            this.mQueueResource2ProcessesList = new ObservableCollection<TProcess>();
            this.mQueueResource3ProcessesList = new ObservableCollection<TProcess>();


            Start();
        }

        #endregion

        #region Методы
        // Вызывается при создании объекта
        public void Start()
        {
            for (int i = 0; i < mCountOfGenerateTasks; i++)
            {
                GenerateTProcess();
            }

            CPU100msTick();

             Resource1Method();
             Resource2Method();
             Resource3Method();

            CalculateRAM();
            CalculateAverageDelayToCompleted();
            CalculateAverageDelayToStart();

            RandomGenerateProcesses();
        }

        // Метод для генерация процесса и добавления его в коллекцию
        public void GenerateTProcess()
        {
            string name = "";
            name += (char)mRandom.Next(97, 123);
            name += (char)mRandom.Next(97, 123);
            name += (char)mRandom.Next(97, 123);
            name += (char)mRandom.Next(97, 123);
            name += (char)mRandom.Next(97, 123);
            name += (char)mRandom.Next(97, 123);


            TProcess process = new TProcess(name,
               IncrementID(),
               mRandom.Next(mRangeTactsForTaskMin, mRangeTactsForTaskMax),
               DateTime.Now.ToString(),
               0,
               TProcess.Status.NotStarted,
               mRandom.Next(1, 10),
               mRandom.Next(mRangeRAMForTaskMin, mRangeRAMForTaskMax),
               TProcess.NOTSTARTED);

            if (mCountOfRAMFree >= process.RAM)
            {
               // mCountOfRAMUsed += process.RAM;
               // mCountOfRAMFree-= mCountOfRAMUsed;

                mTProcessList.Add(process);
            }
            else
            {
                process.StatusString = TProcess.CANCELED;
                mCanceledProcessList.Add(process);
            }

        }

        // Метод для генерации нескольких(count) процессов
        public void GenerateProcesses(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateTProcess();
            }
        }

        // Метод для авто-инкимента ID
        private int IncrementID()
        {
            return mIDIncrementerProcess++;
        }

        #region Async-методы

        private async void CPU100msTick()
        {
            while (true)
            {
                await Task.Delay(100);

                int tactsSumPerSecond = mCPUFrequency / 10;

                int maxPriority = 1;

                while (tactsSumPerSecond >= 0 && !(mTProcessList.Count == 0) ||
                      (tactsSumPerSecond >= 0 && !(mExecutedProcessesList.Count == 0)))
                {
                    maxPriority = 1;

                    // Получать процесс с максимальным приоритетом
                    foreach (TProcess process in mTProcessList)
                    {
                        if (process.Priority > maxPriority)
                        {
                            maxPriority = process.Priority;
                        }
                    }

                    // Проверяем, выполняется ли какой либо процесс
                    if (mExecutedProcessesList.Count != 0)
                    {
                        TProcess process = mExecutedProcessesList[0];
                        if (process.CountOfTactsToComplete == tactsSumPerSecond)
                        {
                            mExecutedProcessesList.Clear();

                            #region Для случайного выполнения на ресурсе
                            int resourceFlag = mRandom.Next(0, 5);

                            switch (resourceFlag)
                            {
                                case 1:
                                    process.StatusString = TProcess.NOTSTARTED;
                                    mQueueResource1ProcessesList.Add(process);
                                    break;
                                case 2:

                                    process.StatusString = TProcess.NOTSTARTED;
                                    mQueueResource2ProcessesList.Add(process);
                                    break;
                                case 3:
                                    if (mExecutedResource3ProcessesList.Count == 0)

                                        process.StatusString = TProcess.NOTSTARTED;
                                    mQueueResource3ProcessesList.Add(process);

                                    break;
                                default:
                                    process.TimeOfStartExecute = DateTime.Now.ToString();
                                    process.CalculateDelayTimeToComplete();
                                    mCompletedProcessList.Add(process);

                                    process.TimeOfCompleted = DateTime.Now.ToString();
                                   // mCountOfRAMUsed -= process.RAM;
                                   // mCountOfRAMFree += process.RAM;
                                    process.StatusString = TProcess.EXECUTED;
                                    process.CalculateDelayTimeToCompleted();

                                    break;
                            }
                            #endregion

                            // Так как процессор отвоевал своё
                            continue;
                        }

                        else if (process.CountOfTactsToComplete >
                            tactsSumPerSecond)
                        {
                            process.CountOfTactsToComplete -= tactsSumPerSecond;
                            continue;
                        }

                        else
                        {
                            mExecutedProcessesList.Clear();

                            #region Для случайного выполнения на ресурсе
                            int resourceFlag = mRandom.Next(0, 5);

                            switch (resourceFlag)
                            {
                                case 1:
                                    process.StatusString = TProcess.NOTSTARTED;


                                    mQueueResource1ProcessesList.Add(process);
                                    break;
                                case 2:
                                    process.StatusString = TProcess.NOTSTARTED;

                                    mQueueResource2ProcessesList.Add(process);
                                    break;
                                case 3:
                                    process.StatusString = TProcess.NOTSTARTED;

                                    mQueueResource3ProcessesList.Add(process);

                                    break;
                                default:
                                    // mCountOfRAMUsed -= process.RAM;
                                    // mCountOfRAMFree += process.RAM;
                                    mCompletedProcessList.Add(process);
                                    process.TimeOfCompleted = DateTime.Now.ToString();
                                    process.StatusString = TProcess.EXECUTED;
                                    process.CalculateDelayTimeToCompleted();
                                    process.TimeOfStartExecute = DateTime.Now.ToString();
                                    process.CalculateDelayTimeToComplete();

                                    break;
                            }
                            #endregion
                        }
                    }

                    // Цикл для процессов не в процессоре
                    for (int i = 0; i < mTProcessList.Count; i++)
                    {
                        TProcess process = mTProcessList[i];

                        // Это если процессор свободен от другого таска
                        if (process.Priority == maxPriority)
                        {
                            tactsSumPerSecond -= process.CountOfTactsToComplete;
                            process.StatusString = TProcess.STARTED;
                            process.TimeOfStartExecute = DateTime.Now.ToString();
                            process.CalculateDelayTimeToComplete();

                            if (tactsSumPerSecond >= 0)
                            {
                                mExecutedProcessesList.Add(process);

                                mTProcessList.Remove(process);

                                mExecutedProcessesList.Remove(process);

                                #region Для случайного выполнения на ресурсе
                                int resourceFlag = mRandom.Next(0, 5);

                                switch (resourceFlag)
                                {
                                    case 1:
                                 
                                            process.StatusString = TProcess.NOTSTARTED;

                                            mQueueResource1ProcessesList.Add(process);
                                       
                                        break;
                                    case 2:
                                       
                                            process.StatusString = TProcess.NOTSTARTED;

                                            mQueueResource2ProcessesList.Add(process);
                                        
                                        break;
                                    case 3:
                                        
                                            process.StatusString = TProcess.NOTSTARTED;

                                            mQueueResource3ProcessesList.Add(process);
                                        
                                        break;
                                    default:
                                        mCompletedProcessList.Add(process);
                                        process.StatusString = TProcess.EXECUTED;
                                        process.TimeOfCompleted = DateTime.Now.ToString();
                                        process.CalculateDelayTimeToCompleted();
                                        process.TimeOfStartExecute = DateTime.Now.ToString();
                                        process.CalculateDelayTimeToComplete();
                                        //  mCountOfRAMUsed -= process.RAM;
                                        //  mCountOfRAMFree += process.RAM;

                                        break;
                                }
                                #endregion
                            }
                            else
                            {
                                mTProcessList.Remove(process);
                                mExecutedProcessesList.Add(process);
                                process.CountOfTactsToComplete += tactsSumPerSecond;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private async void RandomGenerateProcesses()
        {
            while (true)
            {
                await Task.Delay(mRandomGenerateTaskTime * 1000);

                GenerateProcesses(mCountOfGenerateTasks);
            }
        }

        #region Методы ресурсов
        private async void Resource1Method()
        {
            while (true)
            {
                await Task.Delay(mRandom.Next(100, 300));

                int maxPriority = 1;

                // Получать процесс с максимальным приоритетом
                foreach (TProcess process in mQueueResource1ProcessesList)
                {
                    if (process.Priority > maxPriority)
                    {
                        maxPriority = process.Priority;
                    }
                }

                foreach (TProcess process in mQueueResource1ProcessesList)
                {
                    if (process.Priority == maxPriority)
                    {
                        mQueueResource1ProcessesList.Remove(process);
                        mExecutedResource1ProcessesList.Add(process);
                        process.StatusString = TProcess.STARTED;
                        process.TimeOfStartExecute = DateTime.Now.ToString();
                        process.CalculateDelayTimeToComplete();
                        await Task.Delay(mRandom.Next(100, 1000));

                        if (mRandom.Next(0, 2) == 1)
                        {
                           // mCountOfRAMUsed -= process.RAM;
                           // mCountOfRAMFree += process.RAM;
                            process.StatusString = TProcess.EXECUTED;
            
                            process.TimeOfCompleted = DateTime.Now.ToString();
                            process.CalculateDelayTimeToCompleted();

                            process.TimeOfStartExecute = DateTime.Now.ToString();
                            process.CalculateDelayTimeToComplete();
                            mExecutedResource1ProcessesList.Clear();
                            mCompletedProcessList.Add(process);
                            break;
                        }
                        else
                        {
                            mExecutedResource1ProcessesList.Clear();
                            process.StatusString = TProcess.NOTSTARTED;
                            mTProcessList.Add(process);
                            break;
                        }
                    }
                }
            }
        }

        private async void Resource2Method()
        {
            while (true)
            {
                await Task.Delay(mRandom.Next(100, 300));

                int maxPriority = 1;

                // Получать процесс с максимальным приоритетом
                foreach (TProcess process in mQueueResource2ProcessesList)
                {
                    if (process.Priority > maxPriority)
                    {
                        maxPriority = process.Priority;
                    }
                }

                foreach (TProcess process in mQueueResource2ProcessesList)
                {
                    if (process.Priority == maxPriority)
                    {
                        mQueueResource2ProcessesList.Remove(process);
                        mExecutedResource2ProcessesList.Add(process);
                        process.StatusString = TProcess.STARTED;
                        process.TimeOfStartExecute = DateTime.Now.ToString();
                        process.CalculateDelayTimeToComplete();
                        await Task.Delay(mRandom.Next(100, 1000));

                        if (mRandom.Next(0, 2) == 1)
                        {
                            //mCountOfRAMUsed -= process.RAM;
                            //mCountOfRAMFree += process.RAM;
                            process.StatusString = TProcess.EXECUTED;
                            process.TimeOfCompleted = DateTime.Now.ToString();
                            process.CalculateDelayTimeToCompleted();

                            mExecutedResource2ProcessesList.Clear();
                            mCompletedProcessList.Add(process);
                            break;
                        }
                        else
                        {
                            mExecutedResource2ProcessesList.Clear();
                            process.StatusString = TProcess.NOTSTARTED;
                            mTProcessList.Add(process);
                            break;
                        }
                    }
                }
            }
        }

        private async void Resource3Method()
        {
            while (true)
            {
                await Task.Delay(mRandom.Next(100, 300));

                int maxPriority = 1;

                // Получать процесс с максимальным приоритетом
                foreach (TProcess process in mQueueResource3ProcessesList)
                {
                    if (process.Priority > maxPriority)
                    {
                        maxPriority = process.Priority;
                    }
                }

                foreach (TProcess process in mQueueResource3ProcessesList)
                {
                    if (process.Priority == maxPriority)
                    {
                        mQueueResource3ProcessesList.Remove(process);
                        mExecutedResource3ProcessesList.Add(process);
                        process.StatusString = TProcess.STARTED;
                        process.TimeOfStartExecute = DateTime.Now.ToString();
                        process.CalculateDelayTimeToComplete();
                        await Task.Delay(mRandom.Next(100, 1000));

                        if (mRandom.Next(0, 2) == 1)
                        {
                           // mCountOfRAMUsed -= process.RAM;
                           // mCountOfRAMFree += process.RAM;
                            process.StatusString = TProcess.EXECUTED;
                            process.TimeOfCompleted = DateTime.Now.ToString();
                            process.CalculateDelayTimeToCompleted();

                            mExecutedResource3ProcessesList.Clear();
                            mCompletedProcessList.Add(process);
                            break;
                        }
                        else
                        {
                            mExecutedResource3ProcessesList.Clear();
                            process.StatusString = TProcess.NOTSTARTED;
                            mTProcessList.Add(process);
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #endregion


        public async void CalculateRAM()
        {
            while (true)
            {
                await Task.Delay(100);
      
                int RAMUsed = 0;

                foreach (TProcess process in mTProcessList)
                {
                    RAMUsed += process.RAM;
                }

                foreach (TProcess process in mExecutedProcessesList)
                {
                    RAMUsed += process.RAM;
                }

                foreach (TProcess process in mExecutedResource1ProcessesList)
                {
                    RAMUsed += process.RAM;
                }

                foreach (TProcess process in mExecutedResource2ProcessesList)
                {
                    RAMUsed += process.RAM;
                }

                foreach (TProcess process in mExecutedResource3ProcessesList)
                {
                    RAMUsed += process.RAM;
                }

                foreach (TProcess process in mQueueResource1ProcessesList)
                {
                    RAMUsed += process.RAM;
                }

                foreach (TProcess process in mQueueResource2ProcessesList)
                {
                    RAMUsed += process.RAM;
                }

                foreach (TProcess process in mQueueResource3ProcessesList)
                {
                    RAMUsed += process.RAM;
                }

                mCountOfRAMUsed = RAMUsed;
                mCountOfRAMFree = mCountOfRAM - mCountOfRAMUsed;

                if (mCountOfRAMFree < 0) {
                    mCountOfRAMFree = 0;
                    mCountOfRAMUsed = mCountOfRAM;
                }
            }
        }

        public async void CalculateAverageDelayToCompleted() {
            while (true)
            {
                await Task.Delay(100);

                long sum = 0;
                long average = 0;

                foreach (TProcess process in mCompletedProcessList) {
                    sum += process.TimeDelayToCompleted;
                }

                if (mCompletedProcessList.Count != 0)
                {
                    average = sum / mCompletedProcessList.Count;

                    mAverageDelayTimeToCompleted = average;
                }
            }
        }

        
        public async void CalculateAverageDelayToStart()
        {
            while (true)
            {
                await Task.Delay(100);

                long sum = 0;
                long average = 0;

                foreach (TProcess process in mCompletedProcessList)
                {
                    sum += process.TimeDelayStartExecute;
                }

                if (mCompletedProcessList.Count != 0)
                {
                    average = sum / mCompletedProcessList.Count;

                    mAverageDelayTimeToStart = average;
                }
            }
        }
        

        #endregion
    }
}