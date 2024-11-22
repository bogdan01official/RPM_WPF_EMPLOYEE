using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp2;

namespace EmployeeManagement
{
    public partial class EmployeeEditPage : Page
    {
        public event Action<Employee> EmployeeUpdated;

        private Employee _employee;

        public EmployeeEditPage(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            NameTextBox.Text = _employee.Name;
            PositionTextBox.Text = _employee.Position;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _employee.Name = NameTextBox.Text;
            _employee.Position = PositionTextBox.Text;

            EmployeeUpdated?.Invoke(_employee);
            NavigationService.GoBack();
        }
    }
}
