using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace бинарные_файлы_форма_лаба_сишарп_10_2015
{
    public partial class MainForm : Form
    {
        
        Employee tempemployee = new Employee();
        Salary tempsalary = new Salary();
        public List<Employee> employees = new List<Employee>();// { new Employee("Петров", "Олег", "Юрьевич", "1", "Разработчик", "Отдел C#") };
        List<Salary> salarys = new List<Salary>();// { new Salary("1", 99999) };
        public MainForm()
        {
            InitializeComponent();
            this.файлССотрудникамиToolStripMenuItem.Click += ФайлССотрудникамиToolStripMenuItem_Click;
            this.файлСЗарплатамиToolStripMenuItem.Click += ФайлСЗарплатамиToolStripMenuItem_Click;
            this.добавитьЗарплатуToolStripMenuItem.Click += ДобавитьЗарплатуToolStripMenuItem_Click;
            this.добавитьРаботникаToolStripMenuItem.Click += ДобавитьРаботникаToolStripMenuItem_Click;
            this.справкаToolStripButton.Click += СправкаToolStripButton_Click;
            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;
            openFileDialog1.Filter = "Mydata files(*.mydata)|*.mydata|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Mydata files(*.mydata)|*.mydata|All files(*.*)|*.*";
            openFileDialog1.InitialDirectory = @"C:\TestDirectory";
            saveFileDialog1.InitialDirectory = @"C:\TestDirectory";
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            if (salarys.Count != 0)
            {
                tempsalary = salarys[0];
                double min = 0;
                for (int j = 0; j < tempsalary.wage.Count; j++)
                {
                    min += tempsalary.wage[j];
                }
                Salary minsalary = new Salary();
                for (int i = 0; i < employees.Count; i++)
                {
                    foreach (var item in salarys)
                    {
                        if (item.number == employees[i].number) tempsalary = item;
                    }
                    double sum = 0;
                    for (int j = 0; j < tempsalary.wage.Count; j++)
                    {
                        sum += tempsalary.wage[j];
                    }
                    if (sum < min)
                    {
                        min = sum;
                        minsalary = tempsalary;
                    }
                }
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].number == minsalary.number)
                    {
                        textBox2.Text = $"{employees[i].surname} {employees[i].name} {employees[i].patronymic} {employees[i].position} {min}";
                    }
                }

            }
            else
            {
                MessageBox.Show("не считано ни одной зарпалаты!");
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (salarys.Count != 0)
            {
                string department = textBox1.Text;
                SecondForm secondForm = new SecondForm(employees, salarys, department);
                secondForm.Show();
            }
            else MessageBox.Show("не считано ни одной зарпалаты!");
        }

        private void СправкаToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В одном файле хранятся сведения о сотрудниках: ФИО, табельный номер, должность, отдел, " +
                            "во 2 файле сведения о работе за год: табельный номер, заработная плата по месяцам." +
                            "Вывести на экран информацию о сотрудниках отдела, введенного с клавиатуры (ФИО, должность, зарплата за год)," +
                            "выбрать сотрудника, получившего минимальную зарплату за год.");
        }

        private void ДобавитьРаботникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ДобавитьЗарплатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ФайлСЗарплатамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Открытие файла с зарплатами";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            salarys.Clear();
            using (BinaryReader br = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    tempsalary = new Salary();
                    tempsalary.ReadFromFile(br);
                    salarys.Add(tempsalary);
                }
            }
            tempsalary.SalaryListToDataGridView(salarys, dataGridView2);
        }

        private void ФайлССотрудникамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Открытие файла с сотрудниками";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            employees.Clear();
            using (BinaryReader br = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    tempemployee = new Employee();
                    tempemployee.ReadFromFile(br);
                    employees.Add(tempemployee);
                }
            }
            tempemployee.EmployeeListToDataGridView(employees, dataGridView1);
        }
    }
}
