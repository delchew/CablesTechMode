using CablesDatabaseEFCoreFirebird.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.IO;

namespace CableTechModeCommon
{
    public class MainPresenter
    {
        private readonly IView _view;
        private readonly DBRepository _dbRepository;
        private readonly ProgramDataRepository _programDataRepository;
        private string _connectionString;

        public MainPresenter(IView view, ProgramDataRepository programDataRepository)
        {
            _view = view;
            _programDataRepository = programDataRepository;
            _view.ShortNameChanged += View_ShortNameChanged;
            _view.ViewClosed += View_ViewClosed;

            var builder = new ConfigurationBuilder();
            var jsonDir = Directory.GetCurrentDirectory();
            // установка пути к текущему каталогу
            builder.SetBasePath(jsonDir);
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var connectionStringConfig = builder.Build();
            // возвращаем из метода строку подключения
            _connectionString = connectionStringConfig.GetConnectionString("JobConnection");

            _dbRepository = new DBRepository(_connectionString);
            FillDataRepository();
        }

        private void FillDataRepository()
        {
            _programDataRepository.CableShortNames = new ObservableCollection<CableShortName>(_dbRepository.GetCablesShortNames());
            //_programDataRepository.InsulatedBillets = _dbRepository.GetBilletsByCableShortNameId(shortNameId);
        }

        private void View_ShortNameChanged(int shortNameId)
        {
            var billets = _dbRepository.GetBilletsByCableShortNameId(shortNameId);
            //_programDataRepository.InsulatedBillets =
        }
        private void View_ViewClosed()
        {
            _dbRepository?.Dispose();
        }

    }
}
 