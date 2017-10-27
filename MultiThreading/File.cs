using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev3_Soru1
{
    public class File
    {
        FileStream file;
        StreamWriter sw;
        public File()
        {
           file = new FileStream("number.txt", FileMode.Create, FileAccess.Write);
           sw = new StreamWriter(file);
        }

        //
        public bool Write(int[] array)
        {
            foreach (var number in array)
            {
                sw.WriteLine(number);
            }
            sw.Close();
            file.Close();
            return true;
        }
    }
}
