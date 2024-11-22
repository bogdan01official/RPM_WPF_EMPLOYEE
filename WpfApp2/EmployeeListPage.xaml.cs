using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using WpfApp2;

namespace EmployeeManagement
{
    public partial class EmployeeListPage : Page
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeListPage()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>
            {
                new Employee { Name = "Сидоров Сидор Сидорович", Position = "Торговец" },
                new Employee { Name = "Дурков Павел Андреевич", Position = "Разработчик" },
                new Employee { Name = "Иванов Илья Сергеевич", Position = "Топ-менеджер" }
            };
            EmployeeDataGrid.ItemsSource = Employees;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                var editPage = new EmployeeEditPage(selectedEmployee);
                editPage.EmployeeUpdated += OnEmployeeUpdated;
                NavigationService.Navigate(editPage);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для редактирования.");
            }
        }

        private void OnEmployeeUpdated(Employee updatedEmployee)
        {   
            var employee = Employees[Employees.IndexOf(updatedEmployee)];
            employee.Name = updatedEmployee.Name;
            employee.Position = updatedEmployee.Position;

            EmployeeDataGrid.Items.Refresh();
        }
    }
}
