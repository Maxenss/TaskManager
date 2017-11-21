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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            // Пытаемся создать объект
            TScheduler scheduler = TryToCreateTSheduler();
            if (scheduler == null)
            {
                return;
            }

            // Запускаем окно
            TaskManagerWindow taskManagerWindow =
                new TaskManagerWindow(scheduler);

            // Скрываем текущее окно
            this.Close();
            // Отображаем Диспетчер задач
            taskManagerWindow.Show();
        }

        private TScheduler TryToCreateTSheduler()
        {
            TScheduler scheduler = null;

            if (tbCountOfRAM.Text.Equals(""))
            {
                MessageBox.Show("Введите значение в поле " +
                    "кол-во оперативной памяти.",
                    "Пустое поле");
                return null;
            }

            if (tbFreqCPU.Text.Equals(""))
            {
                MessageBox.Show("Введите значение в поле " +
                    "частота CPU.",
                    "Пустое поле");
                return null;
            }

            if (tbCountOfGenProcess.Text.Equals(""))
            {
                MessageBox.Show("Введите значение в поле " +
                    "кол-во генерируемых процессов.",
                    "Пустое поле");
                return null;
            }

            if (tbMinTacts.Text.Equals(""))
            {
                MessageBox.Show("Введите значение в поле " +
                    "минимальное количество тактов для выполнения процесса.",
                    "Пустое поле");
                return null;
            }

            if (tbMaxTacts.Text.Equals(""))
            {
                MessageBox.Show("Введите значение в поле " +
                    "максимальное количество тактов для выполнения процесса.",
                    "Пустое поле");
                return null;
            }

            if (tbMinRAM.Text.Equals(""))
            {
                MessageBox.Show("Введите значение в поле " +
                    "минимальное количество ОЗУ для выполнения процесса.",
                    "Пустое поле");
                return null;
            }

            if (tbMaxRAM.Text.Equals(""))
            {
                MessageBox.Show("Введите значение в поле " +
                    "максимальное количество ОЗУ для выполнения процесса.",
                    "Пустое поле");
                return null;
            }

            try
            {
                int countRAM = Convert.ToInt32(tbCountOfRAM.Text);
                int freqCPU = Convert.ToInt32(tbFreqCPU.Text);
                int delay = Convert.ToInt32(tbDelayOfGen.Text);
                int countOfGenProcess = Convert.ToInt32(tbCountOfGenProcess.Text);
                int minTacts = Convert.ToInt32(tbMinTacts.Text);
                int maxTacts = Convert.ToInt32(tbMaxTacts.Text);
                int minRAM = Convert.ToInt32(tbMinRAM.Text);
                int maxRAM = Convert.ToInt32(tbMaxRAM.Text);

                if (countRAM <= 0 || freqCPU <= 0 || delay <= 0 ||
                    countOfGenProcess <= 0 || minTacts <= 0 || maxTacts <= 0 ||
                    minRAM <= 0 || maxRAM <= 0)
                {
                    MessageBox.Show("Во всех полях должны быть введены положительные целочисленные значения.",
                        "Отрицательное или равное нулю поле");
                    return null;
                }

                if (minRAM > maxRAM)
                {
                    MessageBox.Show("Минимальное количество RAM не может быть " +
                        "больше максимального количества RAM",
                        "Недопустимое значение");
                    return null;
                }

                if (minTacts > maxTacts)
                {
                    MessageBox.Show("Минимальное количество тактов для " +
                        "выполнения процесса не может быть больше максимального " +
                        "количества тактов для выполнения процесса",
                        "Недопустимое значение");
                    return null;
                }

                scheduler = new TScheduler(countRAM, freqCPU, countOfGenProcess,
    delay, minTacts, maxTacts, minRAM, maxRAM);
            }
            catch (Exception e)
            {
                MessageBox.Show("Обнаружены некорректные значения. " +
                    "Исправьте пожалуйста :)", "Ошибка при вводе");
                MessageBox.Show(e.ToString());
                return null;
            }



            return scheduler;
        }

        private void tbCountOfRAM_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
