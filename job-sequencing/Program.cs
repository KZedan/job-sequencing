using System;

namespace job_sequencing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] jobs = new int[100];
            double[] profits = new double[100];
            int[] deadlines = new int[100];
            int i, j, k, n, temp;
            int[,] result = new int[100, 2];
            double temp1;
            try
            {
                Console.WriteLine("Enter number of jobs");
                n = int.Parse(Console.ReadLine());
                for(i = 0; i < n; i++)
                {
                    jobs[i] = i;
                    Console.WriteLine("\nEnter profit\t:");
                    profits[i] = double.Parse(Console.ReadLine());
                    Console.WriteLine("\nEnter deadline\t:");
                    deadlines[i] = int.Parse(Console.ReadLine());
                    result[i, 1] = 0;
                }
                for(i = 0; i < n; i++)
                {
                    for(j = i + 1; j < n; j++)
                    {
                        if(profits[j] > profits[i])
                        {
                            temp1 = profits[i];
                            profits[i] = profits[j];
                            profits[j] = temp1;
                            temp = deadlines[i];
                            deadlines[i] = deadlines[j];
                            deadlines[j] = temp;
                            temp = jobs[i];
                            jobs[i] = jobs[j];
                            jobs[j] = temp;
                        }
                    }
                }
                for(i = 0; i < n; i++)
                {
                    Console.WriteLine("Job number\t:" + jobs[i].ToString() + " Profit :" +
                        profits[i].ToString() + " Deadline :" + deadlines[i]);
                }
                i = 0;
                result[deadlines[0], 1] = 1;
                result[deadlines[0], 0] = jobs[0];
                i++;
                while(i < n)
                {
                    int t = deadlines[i];
                    if(result[t, 1] == 0)
                    {
                        result[t, 1] = 1;
                        result[t, 0] = jobs[i];
                    }
                    else
                    {
                        while((t != -1) && (result[t, 1] != 0))
                        {
                            t--;
                        }
                    }
                    if(t != -1)
                    {
                        result[t, 1] = 1;
                        result[t, 0] = jobs[i];
                    }
                    else
                    {
                        Console.WriteLine("Job " + i + " cannot be done");
                        goto a;
                    }
                }
                Console.WriteLine("Job " + i.ToString() + " slot " + result[i, 0] + " flag" +
                    result[i, 1]);
                i++;
                a:
                Console.WriteLine("Result");
                for (i = 0; i < n; i++)
                {
                    if (result[i, 1] != 0)
                    {
                        Console.WriteLine(result[i, 0]);
                    }
                }

            }
            
            catch(Exception e)
            {
                Console.WriteLine("Exception " + e);
            }
            Console.ReadKey();
        }
    }
}
