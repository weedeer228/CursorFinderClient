using CursorFinderClient.CursorFinderService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CursorFinderClient.Controllers
{
    internal class CursorFinderServiceController
    {
        private Point _lastPoint;
        private CursorFinderServiceClient _client;
        private const float _distanceForUpdatePX = 10;
        private int? _userToken = null;

        public CursorFinderServiceController()
        {
            DistanceForUpdate = (float)Math.Pow(_distanceForUpdatePX, 2);
        }

        public async Task<int> UserToken()
        {
            if (_userToken is null)
                _userToken = await Auth(false);
            return (int)_userToken;
        }
        private float DistanceForUpdate { get; }

        public CursorFinderServiceClient ServiceClient
        {
            get
            {
                if (_client == null)
                    _client = new CursorFinderServiceClient("NetTcpBinding_ICursorFinderService");
                return _client;
            }
        }
        /// <summary>
        /// try/catch необходим для вылавливания ошибок при попытке получить данные без подключения к серверу, чтобы приложение не падало
        /// </summary>
        /// <returns></returns>
        public async Task<List<CursorPosition>> GetCursorPositions()
        {
            try
            {
                return (await ServiceClient.GetCursorPositionsByTokenAsync(await UserToken())).ToList();
            }
            catch (System.ServiceModel.CommunicationObjectFaultedException)
            {

                return new List<CursorPosition>();
            }
        }

        public async Task<int> Auth(bool isAmin)
        {
            try
            {
                _userToken = await Task.Run(() => ServiceClient.Auth(isAmin, _userToken));
                return await UserToken();
            }
            catch (System.ServiceModel.CommunicationObjectFaultedException e)
            {

                return -1;
            }

        }
        public async Task UpdateCursorPositionAsync(int xPos, int yPos, MouseActionType mouseActionType) => await ServiceClient.AddNewCursorPositionAsync(xPos, yPos, mouseActionType, await UserToken());
        public async Task UpdateCursorPositionAsync(Point point, MouseActionType mouseActionType) => await UpdateCursorPositionAsync(point.X, point.Y, mouseActionType);
        public async Task<bool> EnableNotifictionsAsync()
        {
            try
            {
                await ServiceClient.EnableNotificationAsync();
                return true;

            }
            catch (System.ServiceModel.CommunicationObjectFaultedException)
            {
                return false;
            }
        }
        public async Task<bool> DisableNotifictionsAsync()
        {
            try
            {
                await ServiceClient.DisableNotificationAsync();
                return true;

            }
            catch (System.ServiceModel.CommunicationObjectFaultedException)
            {
                return false;
            }
        }
        public async void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = Control.MousePosition;
            UpdateLastPoint(point);
            await UpdateCursorPositionAsync(point, GetCurrentMouseActionType(e));
        }
        public async Task<bool> StartRecording()
        {
            try
            {
                return await ServiceClient.StartRecordAsync();
            }
            catch (System.ServiceModel.CommunicationObjectFaultedException)
            {
                return false;
            }
        }
        public async Task<bool> StoptRecording()
        {
            try
            {
                return await ServiceClient.StopRecordAsync();
            }
            catch (System.ServiceModel.CommunicationObjectFaultedException)
            {
                return false;
            }
        }

        public async Task Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var point = Control.MousePosition;
            if (GetDistanceBeetweenPoints(point) < DistanceForUpdate) return;
            UpdateLastPoint(point);
            await UpdateCursorPositionAsync(point, MouseActionType.Shift);
        }
        public async Task<bool> IsMyAccountAdmin() => ServiceClient.IsUSerAdmin(await UserToken());
        public async Task<int> GetDbRecordsCount()
        {
            try
            {
                return await ServiceClient.GetDbRecordsCountAsync(await UserToken());
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {

                return -1;
            }
        }

        public async Task ClearDbRecords() => await ServiceClient.ClearDbAsync(await UserToken());
        private void UpdateLastPoint(Point newPoint) => _lastPoint = newPoint;
        /// <summary>
        /// Решил убрать из формулы рассчета расстояния между
        /// точками квадратный корень, тк тяжелая операция,
        /// в которой нет критической необходимости
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private float GetDistanceBeetweenPoints(Point point) => (float)(Math.Pow((point.X - _lastPoint.X), 2) + Math.Pow((point.Y - _lastPoint.Y), 2));

        /// <summary>
        ///  определение какая кнопка мыши была нажата
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private MouseActionType GetCurrentMouseActionType(MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                return MouseActionType.LeftButtonClick;
            if (e.MiddleButton == MouseButtonState.Pressed)
                return MouseActionType.MiddleButtonClick;
            return MouseActionType.RightButtonClick;
        }
    }

}
