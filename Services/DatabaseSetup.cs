using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManager.Services
{
    public class DatabaseSetup
    {
        private string _appdataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private string _appFolder = "KUBIXQAZ\\EmployeeManager";
        private string _fileName = "ConnectionString.txt";

        private string _directory;
        private string _connectionStringPath;

        private string _connectionStringTemplate = "data source=serverName;initial catalog=databaseName;user id=username;password=password;TrustServerCertificate=True";

        public DatabaseSetup()
        {
            _directory = Path.Combine(_appdataDirectory, _appFolder);
            _connectionStringPath = Path.Combine(_directory, _fileName);
        }

        public string ReadConnectionString()
        {
            if(!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }

            if(File.Exists(_connectionStringPath))
            {
                string content = File.ReadAllText(_connectionStringPath);

                if(!content.Equals(_connectionStringTemplate))
                {
                    return content;
                }
            } else
            {
                File.WriteAllText(_connectionStringPath, _connectionStringTemplate);
            }

            return null;
        }
    }
}
