using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace бинарные_файлы_форма_лаба_сишарп_10_2015
{
    public partial class SecondForm : Form
    {
        public SecondForm(List<Employee> employees, List<Salary> salarys, string department)
        {
            InitializeComponent();
            Salary tempsalary = salarys[0];
            double sum;
            for (int i = 0; i < employees.Count; i++)
            {
                sum = 0;
                if(employees[i].department == department)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = employees[i].surname;
                    dataGridView1[1, i].Value = employees[i].name;
                    dataGridView1[2, i].Value = employees[i].patronymic;
                    dataGridView1[3, i].Value = employees[i].position;
                    foreach (var item in salarys)
                    {
                        if (item.number == employees[i].number)
                        {
                            tempsalary = item;
                            break;
                        }
                    }
                    foreach (var item in tempsalary.wage)
                    {
                        sum += item;
                    }
                    dataGridView1[4, i].Value = sum;
                }
            }
        }
    }
}
