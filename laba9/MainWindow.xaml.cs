using System;
using System.Windows;
using System.Windows.Controls;

namespace lab6._2._3
{
    public partial class MainWindow : Window
    {
        private Time time1;
        private Time time2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppendResult(string message)
        {
            txtResults.Text += message + Environment.NewLine;
        }

        private void ClearResults()
        {
            txtResults.Text = string.Empty;
        }

        private bool TryParseInt(TextBox tb, string fieldName, out int value)
        {
            if (int.TryParse(tb.Text, out value))
            {
                return true;
            }
            MessageBox.Show($"Ошибка: Некорректное значение для '{fieldName}' в поле '{tb.Name}'. Введите целое число.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            value = 0;
            return false;
        }

        private void UpdateDisplayForTime1()
        {
            if (time1 != null)
            {
                string[] parts = time1.ToString().Split(':');
                if (parts.Length == 3)
                {
                    txtHours1.Text = parts[0];
                    txtMinutes1.Text = parts[1];
                    txtSeconds1.Text = parts[2];
                }
            }
        }

        private void UpdateDisplayForTime2()
        {
            if (time2 != null)
            {
                string[] parts = time2.ToString().Split(':');
                if (parts.Length == 3)
                {
                    txtHours2.Text = parts[0];
                    txtMinutes2.Text = parts[1];
                    txtSeconds2.Text = parts[2];
                }
            }
        }

        private bool CreateTime1()
        {
            int h, m, s;

            if (!TryParseInt(txtHours1, "Часы (Время 1)", out h) ||
                !TryParseInt(txtMinutes1, "Минуты (Время 1)", out m) ||
                !TryParseInt(txtSeconds1, "Секунды (Время 1)", out s))
            {
                time1 = null;
                return false;
            }

            try
            {
                time1 = new Time(h, m, s);
                AppendResult($"time1 успешно создан/обновлен: {time1}");
                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                AppendResult($"Ошибка создания time1: Поле '{ex.ParamName}' - {ex.Message.Split
                    (new[] { Environment.NewLine }, StringSplitOptions.None)[0]}");
                MessageBox.Show($"Ошибка создания time1: Поле '{ex.ParamName}' - {ex.Message.Split
                    (new[] { Environment.NewLine }, StringSplitOptions.None)[0]}", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                time1 = null;
                return false;
            }
        }

        private bool CreateTime2()
        {
            int h, m, s;

            if (!TryParseInt(txtHours2, "Часы (Время 2)", out h) ||
                !TryParseInt(txtMinutes2, "Минуты (Время 2)", out m) ||
                !TryParseInt(txtSeconds2, "Секунды (Время 2)", out s))
            {
                time2 = null;
                return false;
            }

            try
            {
                time2 = new Time(h, m, s);
                AppendResult($"time2 успешно создан/обновлен: {time2}");
                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                AppendResult($"Ошибка создания time2: Поле '{ex.ParamName}' - {ex.Message.Split
                    (new[] { Environment.NewLine }, StringSplitOptions.None)[0]}");
                MessageBox.Show($"Ошибка создания time2: Поле '{ex.ParamName}' - {ex.Message.Split
                    (new[] { Environment.NewLine }, StringSplitOptions.None)[0]}", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                time2 = null;
                return false;
            }
        }

        
        private void InitializeTimes_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            CreateTime1();
            CreateTime2();
        }

        private void SubtractTimes_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime1() || !CreateTime2()) return;
            AppendResult($"Текущий time1: {time1}");
            AppendResult($"Текущий time2: {time2}");
            Time time3 = time1 - time2;
            AppendResult($"Разница (time1 - time2): {time3}");
        }

        private void CopyTime1_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime1()) return;
            AppendResult($"Текущий time1: {time1}");
            Time time4 = new Time(time1);
            AppendResult($"time4 (копия time1): {time4}");
        }

        private void IncrementTime1_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime1()) return;
            AppendResult($"time1 до инкремента: {time1}");
            time1++;
            AppendResult($"time1 (после time1++): {time1}");
            UpdateDisplayForTime1();
        }

        private void DecrementTime2_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime2()) return;
            AppendResult($"time2 до декремента: {time2}");
            --time2;
            AppendResult($"time2 (после --time2): {time2}");
            UpdateDisplayForTime2();
        }

        private void Time1ToMinutes_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime1()) return;
            AppendResult($"Текущий time1: {time1}");
            int minutes = time1;
            AppendResult($"time1 в минутах: {minutes}");

        }

        private void IsTime2NonZero_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime2()) return;
            AppendResult($"Текущий time2: {time2}");
            bool isNonZero = (bool)time2;
            AppendResult($"time2 не нулевое: {isNonZero}");
        }

        private void CompareLessThan_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime1() || !CreateTime2()) return;
            AppendResult($"Текущий time1: {time1}");
            AppendResult($"Текущий time2: {time2}");
            AppendResult($"time1 < time2: {time1 < time2}");
        }

        private void CompareGreaterThan_Click(object sender, RoutedEventArgs e)
        {
            ClearResults();
            if (!CreateTime1() || !CreateTime2()) return;
            AppendResult($"Текущий time1: {time1}");
            AppendResult($"Текущий time2: {time2}");
            AppendResult($"time1 > time2: {time1 > time2}");
        }
    }
}