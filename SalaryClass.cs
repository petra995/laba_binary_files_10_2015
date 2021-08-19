using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace бинарные_файлы_форма_лаба_сишарп_10_2015
{
    public class Salary
    {
        public string number;
        public List<double> wage;
        public Salary()
        {
            number = "";
            wage = new List<double> { };
        }
        public Salary(string number, List<double> wage)
        {
            this.number = number;
            this.wage = wage;
        }
        public void WriteToFile(string filepath)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(filepath, FileMode.Append)))
            {
                bw.Write(number);
                for (int i = 0; i < wage.Count; i++)
                {
                    bw.Write(wage[i]);
                }
                bw.Write('\n');
            }
        }
        public void ReadFromFile(BinaryReader br)
        {
            try
            {
                int i = 0;
                number = br.ReadString();
                while ((char)br.PeekChar() != '\n')
                {
                    wage.Add(br.ReadDouble()); //newsalary.wage.Add(br.ReadDouble());
                    i++;
                }
                br.ReadChar();
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла.");
            }
        }
        public void SalaryListToDataGridView(List<Salary> salarys, DataGridView dataGridView2)
        {
            for (int i = 0; i < salarys.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2[0, i].Value = salarys[i].number;
                for (int j = 0; j < salarys[i].wage.Count; j++)
                {
                    dataGridView2[j + 1, i].Value = salarys[i].wage[j];
                }
            }
        }
    }
}
