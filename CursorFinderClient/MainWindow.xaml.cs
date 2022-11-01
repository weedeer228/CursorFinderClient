using CursorFinderClient.Controllers;
using CursorFinderClient.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CursorFinderClient
{

    public partial class MainWindow : Window
    {
        private bool _isRecording;
        private readonly CursorFinderServiceController _finderServiceController;

        public MainWindow()
        {
            InitializeComponent();
            _finderServiceController = new CursorFinderServiceController();
            UpdateRecordsCount();
        }
        public async void UpdateRecordsCount()
        {
            var count = await _finderServiceController.GetDbRecordsCount();
            if (count < 0)
                SetNotConnectedMessage();
            else
                SetConnectedMessage();
            DbRecordsCountTextBlock.Text = count.ToString();
        }
        #region кнопка старт/стоп запись
        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isRecording)
                StopRecord(sender as Button);
            else
                StartRecord(sender as Button);
            CloseAllWindows();
        }

        private async void StartRecord(Button sender)
        {
            if (await _finderServiceController.StartRecording())
            {
                MouseDown += Window_MouseDown;
                MouseMove += Window_MouseMove;
                sender.Background = Brushes.Red;
                sender.Content = "Stop";
                _isRecording = true;
                SetConnectedMessage();
                return;
            }
            SetNotConnectedMessage();
        }
        private async void StopRecord(Button sender)
        {
            if (await _finderServiceController.StoptRecording())
            {
                MouseDown -= Window_MouseDown;
                MouseMove -= Window_MouseMove;
                sender.Background = Brushes.Lime;
                sender.Content = "Start";
                _isRecording = false;
                SetConnectedMessage();
                return;
            }
            SetNotConnectedMessage();
        }
        #endregion

        #region события движения/клика мыши
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!_isRecording) return;
            _finderServiceController.Window_MouseDown(sender, e);
            UpdateRecordsCount();
        }

        private async void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isRecording) return;
            await _finderServiceController.Window_MouseMove(sender, e);
            UpdateRecordsCount();
        }
        #endregion

        private async void ActionList_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isRecording)
                StopRecord(StartButton);
            new MouseActionList(await _finderServiceController.GetCursorPositions()).Show();
        }

        #region кнопки аутентификации
        private async void User_Signin_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isRecording)
                StopRecord(StartButton);
            var result = await _finderServiceController.Auth(false);
            if (result == -1)
            {
                SetNotConnectedMessage();
                return;
            }

            CheckAdminPanel();
            SetConnectedMessage();
        }

        private async void Admin_Signin_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isRecording)
                StopRecord(StartButton);
            var result = await _finderServiceController.Auth(true);
            if (result == -1)
            {
                SetNotConnectedMessage();
                return;
            }

            CheckAdminPanel();
            SetConnectedMessage();
        }
        #endregion

        #region Админка
        private async void CheckAdminPanel()
        {
            if (await _finderServiceController.IsMyAccountAdmin())
                EnableAdminPanel();
            else
                DisableAdminPanel();
        }
        private void EnableAdminPanel()
        {
            ClearDbButton.Visibility = Visibility.Visible;
            ClearDbButton.IsEnabled = true;
        }
        private void DisableAdminPanel()
        {
            ClearDbButton.Visibility = Visibility.Hidden;
            ClearDbButton.IsEnabled = false;
        }
        #endregion

        private async void ClearDbButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRecording)
                StopRecord(StartButton);
            await _finderServiceController.ClearDbRecords();
            UpdateRecordsCount();
        }
        #region сообщение о состоянии подключения клиента к серверу
        private void SetNotConnectedMessage()
        {
            ConnectionLabel.Content = "Not Connected";
            ConnectionLabel.Foreground = Brushes.Red;
        }

        private void SetConnectedMessage()
        {
            ConnectionLabel.Content = "Connected";
            ConnectionLabel.Foreground = Brushes.Lime;
        }
        #endregion

        #region Включение/отключение уведомлений
        private async void NotificationToggle_Checked(object sender, RoutedEventArgs e) => await _finderServiceController.EnableNotifictionsAsync();

        private async void NotificationToggle_Unchecked(object sender, RoutedEventArgs e) => await _finderServiceController.DisableNotifictionsAsync();
        #endregion

        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
            {
                var window = App.Current.Windows[intCounter];
                if (window != this)
                    window.Close();
            }


        }
    }
}
