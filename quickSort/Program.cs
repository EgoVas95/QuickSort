using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickSort
{
    class Program
    {
        static int[] MakeBuf(int size)
        {
            if (size < 2 || size > 2000) {
                return null;
            }
            int[] buf = new int[size];
            Random randNum = new Random();

            for (int i = 0; i < size; i++) {
                buf[i] = randNum.Next(0, Int16.MaxValue);
            }

            return buf;
        }

        static int Partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        static void Quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }

        
        static void LastSort(int[] buf){
            int[] divBy3 = new int[buf.Length], nonDiv = new int[buf.Length];
            int divBy3Idx = 0, nonDivIdx = 0;
            for (int i = 0; i < buf.Length; i++) {
                if (buf[i] % 3 == 0)
                {
                    divBy3[divBy3Idx] = buf[i];
                    divBy3Idx++;
                }
                else {
                    nonDiv[nonDivIdx] = buf[i];
                    nonDivIdx++;
                }
            }
            if (divBy3Idx >= 2)
            {
                Quicksort(divBy3, 0, divBy3Idx - 1);
            }
            if (nonDivIdx >= 2)
            {
                Quicksort(nonDiv, 0, nonDivIdx - 1);
            }
            Array.ConstrainedCopy(divBy3, 0, buf, 0, divBy3Idx);
            Array.ConstrainedCopy(nonDiv, 0, buf, divBy3Idx, nonDivIdx);
        }

        static void QSort(int[] inBuf, int first, int last)
        {
            int count;
            int f = first, l = last;
            int piv = inBuf[(first + last) / 2];
            do
            {
                while (inBuf[f] < piv) f++;
                while (inBuf[l] > piv) l--;
                if (f <= l)
                {
                    count = inBuf[f];
                    inBuf[f] = inBuf[l];
                    inBuf[l] = count;
                    f++;
                    l++;
                }
            } while (f < l);

            if (first < l) QSort(inBuf, first, l);
            if (f < last) QSort(inBuf, f, last);           
        }

        static void WriteArrayToConsole(int[] buf) {
            foreach (int num in buf) {
                Console.Write(num + " ");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            int size = 0;
            while (size == 0){
                Console.Write("Введите размерность массива = ");
                string strNum = Console.ReadLine();
                int s = int.Parse(strNum);
                if (s >= 2 && s <= 2000)
                {
                    size = s;
                }
                else { Console.WriteLine("Ошибка, размер массива должен лежать в диапазоне = [2; 2000]"); }
            }
            int[] buf = MakeBuf(size);
            Console.Write("Исходный массив = ");
            WriteArrayToConsole(buf);
            Console.Write("Остортированный массив = ");
            LastSort(buf);
            WriteArrayToConsole(buf);
            Console.ReadLine();
        }
    }
}
