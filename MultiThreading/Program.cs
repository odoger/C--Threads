using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odev3_Soru1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Produces a Array object
            MyArray array = new MyArray();

            //Adds random 1000 elements
            array.ElementAdd();

            //Sorting array 0-499
            int[] unSortingArray1 = new int[array.GetCount()/2];
            unSortingArray1 = array.GetArray(0, array.GetCount()/2);
            Thread tFirstSorting = new Thread(()=>array.Sorting(unSortingArray1,0,array.GetCount()/2));
          

            //Sorting array 500-999
            int[] unSortingArray2 = new int[array.GetCount()/2];
            unSortingArray2 = array.GetArray(array.GetCount()/2, array.GetCount());
            Thread tSecondSorting = new Thread(() => array.Sorting(unSortingArray2, 0, array.GetCount() / 2));

            tFirstSorting.Start();
            tSecondSorting.Start();

            //Threadler işlemlerini bitirene kadar kalması gerekecek.            
            tFirstSorting.Join();            
            tSecondSorting.Join();

            //When completed both sorting thread operation, if didn't completed error message
             Thread tMerge;
             tMerge = new Thread(() => array.MergeArrays(unSortingArray1, unSortingArray2));
             tMerge.Start();
             tMerge.Join();

            //Kendi oluşturduğumuz File sınıfı sayesinde sıralanmış tüm diziyi dosyaya yazdırıyoruz.
             File f = new File();
             f.Write(array.GetArray(0, array.GetCount()));

            //Sıralı diziyi console ekranında gösteriyoruz.
            foreach (var item in array.GetArray(0,array.GetCount()))            
                Console.WriteLine(item);
            
           
            Console.ReadLine();
        }
      
    }
}
