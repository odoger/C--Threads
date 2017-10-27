using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev3_Soru1
{
    public class MyArray
    {
        private int [] OurArray;
        private int NUMBER = 1000;
        private Random random;
        public MyArray()
        {
            OurArray = new int[NUMBER];
            random=new Random();
        }

        //This function get  single a element
        private int GetElement(int i)
        {
            return this.OurArray[i];
        }

        //This function set single a element
        private int SetElement(int value, int i)
        {
            return this.OurArray[i] = value;
        }

        //This function adds single unique a element in Array
        private bool SetArray(int value,int i)
        {
            
            if (!this.OurArray.Contains(value)&& i<NUMBER)
            {
                this.OurArray[i] = value;
                return true;
            }
            else
                return false;
         

        }
        
        //This function gets array count
        public int GetCount()
        {
            return this.OurArray.Count();
        }

        //This function generates the random element
        private int RandomElement()
        {          
            return random.Next(1, 10000000);
        }      

        //This function adds 1000 elements in Array
        public void ElementAdd()
        {
           
            bool boolean;
            int i = 0;
            do
            {
                boolean=SetArray(RandomElement(), i);
                if (boolean == true)
                    i += 1;
            } while (i<NUMBER);
        }       
        
        //This function sorts small to big
        public void Sorting(int firstElements, int lastElements)
        {
            int i, j, moved;
            for (i = firstElements  ; i < lastElements; i++)
            {
                moved = GetElement(i);
                j = i;
                while (j > 0 && GetElement(j - 1) > moved)
                {
                    SetElement(GetElement(j - 1), j);
                    j--;
                }
                SetElement(moved, j);
            }           
        }

        //This function sorts a array small to big
        public int[] Sorting(int[] items,int firstElements,int lastElements)
        {
            int i, j, moved;
            for (i = firstElements; i < lastElements; i++)
            {
                moved = items[i];
                j = i;
                while (j > 0 && items[j-1] > moved)
                {
                   
                    items[j] = items[j - 1];
                    j--;
                }
               
                items[j] = moved;
            }
            return items;
        }


        //This function get whole array
        public int[] GetArray(int firstElements,int lastElements)
        {
            int[] returnArray = new int[lastElements - firstElements];
            int sayac=0;
            for (int i = firstElements; i < lastElements; i++)
            {
                returnArray[sayac] = GetElement(i);
                sayac++;
            }
            return returnArray;
        }

        //This function merges two sequence
        public void MergeArrays(int[] array1, int[] array2)
        {
            array1.CopyTo(this.OurArray, 0);
            array2.CopyTo(this.OurArray, this.NUMBER / 2);
            Sorting(this.OurArray, 0, this.NUMBER);
        }
    }
}
