using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using BudgetTracker.Domain.Models;
using Microsoft.Win32;

namespace BudgetTracker.WPF.Commands
{
    public class ImportUserDataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var user = parameter as User;

            if (user == null)
            {
                // handle the case where the parameter is not a User object
                return;
            }

            var dialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = ".json"
            };

            var result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                var filePath = dialog.FileName;

                using (var fileStream = new StreamWriter(filePath))
                {
                    Console.WriteLine("Hello");
                    /*var serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(fileStream, user);*/
                }
            }
        }
    }
}
