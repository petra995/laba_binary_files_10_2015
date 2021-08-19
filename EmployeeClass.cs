using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace бинарные_файлы_форма_лаба_сишарп_10_2015
{
    public class Employee
    {
        public string surname;
        public string name;
        public string patronymic;
        public string number;
        public string position;
        public string department;
        public Employee()
        {
            surname = "";
            name = "";
            patronymic = "";
            number = "";
            position = "";
            department = "";
        }
        public Employee(string surname, string name, string patronymic, string number, string position, string department)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.number = number;
            this.position = position;
            this.department = department;
        }
        public void WriteToFile(string filepath)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(filepath, FileMode.Append)))
            {
                bw.Write(surname);
                bw.Write(name);
                bw.Write(patronymic);
                bw.Write(number);
                bw.Write(position);
                bw.Write(department);
                bw.Write('\n');
            }
        }
        public void ReadFromFile(BinaryReader br)
        {
            try
            {
                surname = br.ReadString();
                name = br.ReadString();
                patronymic = br.ReadString();
                number = br.ReadString();
                position = br.ReadString();
                department = br.ReadString();
                br.ReadChar();
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла.");
            }
        }
        public void EmployeeListToDataGridView(List<Employee> employees, DataGridView dataGridView1)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = employees[i].surname;
                dataGridView1[1, i].Value = employees[i].name;
                dataGridView1[2, i].Value = employees[i].patronymic;
                dataGridView1[3, i].Value = employees[i].number;
                dataGridView1[4, i].Value = employees[i].position;
                dataGridView1[5, i].Value = employees[i].department;
            }
        }
    }
}
