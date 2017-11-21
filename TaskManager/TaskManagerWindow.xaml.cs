using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для TaskManagerWindow.xaml
    /// </summary>
    public partial class TaskManagerWindow : Window
    {
        #region Поля класса

        #region Строки для Label'ов
        private string labelCountOfRAMFreeLabel = "Количество свободной RAM: ";
        private string labelCountOfRAMUsedLabel = "Количество занятой RAM: ";
        private string labelCountOfRAMFullLabel = "Всего RAM: ";
        private string labelCPUFreqLabel = "Частота CPU: ";
        private string labelCompletedCountLabel = "Выполненных процессов: ";
        private string labelCanceledCountLabel = "Отклоненных процессов: ";
        private string labelInQueueCountLabel = "Процессов в очереди: ";
        private string labelDelayToCompletedLabel = "Среднее время для выполнения: ";
        private string labelDelayToStartLabel = "Среднее время для начала выполнения: ";
        #endregion

        // Объект-планировщик обеспечивающий работу с процессами
        private TScheduler mScheduler;

        #endregion

        // Конструктор окна
        public TaskManagerWindow(TScheduler scheduler)
        {
            InitializeComponent();
            this.mScheduler = scheduler;


            dgProcessList.ItemsSource = mScheduler.GetProcessList();
            dgCanceledProcessList.ItemsSource = mScheduler.GetCanceledProcessList();
            dgCompletedProcessList.ItemsSource = mScheduler.GetCompletedProcessList();
            dgResource1ProcessList.ItemsSource = mScheduler.GetResource1ProcessesList();
            dgResource2ProcessList.ItemsSource = mScheduler.GetResource2ProcessesList();
            dgResource3ProcessList.ItemsSource = mScheduler.GetResource3ProcessesList();
            dgExecuteProcessList.ItemsSource = mScheduler.GetOnExecuteProcessesList();

            dgResourceQueue1ProcessList.ItemsSource = mScheduler.GetQueueResource1ProcessesList();
            dgResourceQueue2ProcessList.ItemsSource = mScheduler.GetQueueResource2ProcessesList();
            dgResourceQueue3ProcessList.ItemsSource = mScheduler.GetQueueResource3ProcessesList();

            this.RefreshGUI();
            RefreshGUITask();
        }

        #region Методы класса

        // Метод для обновления значений пользовательского интерфейса
        private void RefreshGUI()
        {
            labelCountRAMFree.Content = labelCountOfRAMFreeLabel + mScheduler.CountOfRAMFree + " MB";
            labelCountRAMUsed.Content = labelCountOfRAMUsedLabel + mScheduler.CountOfRAMUsed + " MB";
            labelCountRAM.Content = labelCountOfRAMFullLabel + mScheduler.CountOfRAM + " MB";
            labelCPUFreq.Content = labelCPUFreqLabel + mScheduler.CPUFrequency + " MHz";
            labelProcessesCompletedCount.Content = labelCompletedCountLabel + mScheduler.GetCompletedProcessList().Count;
            labelProcssesCanceledCount.Content = labelCanceledCountLabel + mScheduler.GetCanceledProcessList().Count;
            labelProcessesInQueueCount.Content = labelInQueueCountLabel + mScheduler.GetProcessList().Count;
            labelDelayCompleted.Content = labelDelayToCompletedLabel + mScheduler.AverageDelayTimeToCompleted + " ms";
            labelDelayToStart.Content = labelDelayToStartLabel + mScheduler.AverageDelayTimeToStart + " ms";
        }

        // Метод для обновленя GUI каждые 100ms
        private async void RefreshGUITask()
        {
            while (true)
            {
                await Task.Delay(100);

                RefreshGUI();
            }
        }

        #region Обработчики на нажатие кнопок

        // Метод для генерации одного процесса
        private void btGenerateTProcess_Click(object sender, RoutedEventArgs e)
        {
            this.mScheduler.GenerateTProcess();
            this.RefreshGUI();
        }

        // Обработчик на нажатие. Добавляем 10 процессов в очередь
        private void btGenerate10TProcess_Click(object sender, RoutedEventArgs e)
        {
            mScheduler.GenerateProcesses(10);
        }

        // Обработчик на нажатие. Добавляем 100 процессов в очередь
        private void btGenerate100TProcess_Click(object sender, RoutedEventArgs e)
        {
            mScheduler.GenerateProcesses(100);
        }

        // Метод для изменения конфигурации устройства
        private void btSetConfig_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        #endregion

        #endregion
    }
}
