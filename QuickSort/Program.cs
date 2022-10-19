using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class program
    {
        //array of integers to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0; // number of comparasion
        private int mov_count = 0; // number of data movements

        //number of elements in array
        private int n;
        private int low;

        void input()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elements \n");
            }
            Console.WriteLine("\n======================");
            Console.WriteLine("Enter Array Elements");
            Console.WriteLine("\n======================");

            //get array elements
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
            //swaps the element at index x with the element at index y
        }
        void swap(int x,int y)
        {
            int temp;
            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
            
        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low < high)
                return;

            //Patition the list into two parts;
            //One containing elements less that or equal to pivot
            //Outer countaining element greather than pivot

            i = low;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //Search fot an element greater than pivot
                while ((arr[i] <= pivot) && (j <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                //Search for an elements less than or equal to pivot
                while ((arr[i] > pivot) && (j >= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count--;

                if (i < j)
                {
                    swap(i, j);
                    mov_count++;
                }
            }

            //j now contains the index of the last element in the sorted list

            if (low < j)
            {
                //Move the pivot to its correct position in the list
                swap(low, j);
                mov_count++;
            }
            //sort the list on the left of pivot using quick sort
            q_sort(low,j -1);
            mov_count++;

            //sort the list in the right of pivot using quick sort
            q_sort(j + 1, high);
        }
    }
}
