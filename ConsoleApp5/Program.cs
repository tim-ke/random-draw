using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp5
{
    internal class Program
    {
        static int[] ball;//球
        static ArrayList bag;//裝球的袋子

        static void Main(string[] args)
        {
            Console.WriteLine("請投入球數1~100顆");
            while (true)
            {
                try
                {
                    int ball_nb = int.Parse(Console.ReadLine());
                    if (ball_nb > 0 && ball_nb <= 100)
                    {
                        initial_(ball_nb);//初始化 100顆球
                    }
                    else
                    {
                        throw new Exception();
                    }

                    break;
                }
                catch
                {
                    Console.WriteLine("輸入錯誤，請重新輸入");
                }
            }



            Console.WriteLine("投入球數" + ball.Length);
            ball_random_array(ball);


            Boolean flag = true;
            while (flag)
            {
                Console.WriteLine("請輸入抽取的球數");

                int draw_coount = int.Parse(Console.ReadLine());

                Console.WriteLine("本次抽球號碼：");
                for (int a = 0; a < draw_coount; a++)
                {
                    int nb = GetOneNumber();
                    bag.Add(nb);
                    Console.Write(nb);
                    Thread.Sleep(90);
                    if (ball.Length == 0) { break; }
                    if (a + 1 < draw_coount)
                    {
                        Console.Write(",");
                    }
                }

                Console.WriteLine("");

                if (ball.Length == 0)
                {
                    break;
                }
            }
            Console.WriteLine("抽球完畢。");
            Console.WriteLine("共" + bag.Count + "球。");
            Console.WriteLine("抽球順序：");
            int cc = 1;
            foreach (int Bag in bag)
            {
                Console.Write(Bag);
                if (cc < bag.Count)
                {
                    Console.Write(",");
                }
                cc++;
            }
            Console.ReadKey();

            //Console.WriteLine(string.Join(",", ball));//輸出當前陣列的順序

            //bag.Add(GetOneNumber());

            //Console.WriteLine(bag[0]);//輸出當前陣列的順序

            //Console.WriteLine(string.Join(",", ball));//輸出當前陣列的順序
            //Console.Write(123);
            //Console.Write(123);
        }



        /// <summary>
        /// 取的第一顆球放入袋子，並刪除ball取走的球，抽球前會先洗球一次
        /// </summary>
        /// <returns></returns>
        private static int GetOneNumber()
        {
            ball_random_array(ball);//洗球一次
            int get_ball = ball[0];
            int[] ball_temp = new int[ball.Length - 1];//球的暫存區          
            for (int u = 0; u < ball.Length - 1; u++)
            {
                ball_temp[u] = ball[u + 1];
            }
            ball = new int[ball.Length - 1];
            ball = ball_temp;
            return get_ball;
        }

        /// <summary>
        /// 讓陣列中的球交換(隨機)
        /// </summary>
        /// <param name="ar_ball">放入球的陣列</param>
        private static void ball_random_array(int[] ar_ball)
        {
            int loop;//迴圈次數
            int x1, x2;//亂數值
            loop = random_number(255);//迴圈次數
            for (int i = 0; i < loop; i++)
            {
                rotate_array(ar_ball);//讓陣列轉圈圈後再交換
                x1 = random_number((byte)ar_ball.Length);
                x2 = random_number((byte)ar_ball.Length);
                int ball_temp = ar_ball[x1 - 1];//暫存
                ar_ball[x1 - 1] = ar_ball[x2 - 1];//陣列交換
                ar_ball[x2 - 1] = ball_temp;//陣列交換
            }
        }

        /// <summary>
        /// 讓陣列中的球依序轉圈圈(隨機)
        /// </summary>
        /// <param name="ar_ball">放入球的陣列</param>
        private static void rotate_array(int[] ar_ball)
        {
            int loop1, loop2;
            loop1 = random_number(10);//第一層迴圈
            for (int i = 0; i < loop1; i++)
            {
                loop2 = random_number(60);//第二層迴圈
                for (int j = 0; j < loop2; j++)
                {
                    int o1 = ar_ball[ar_ball.Length - 1];
                    for (int k = ar_ball.Length - 1; k >= 0; k--)
                    {


                        if (k != 0)
                        {
                            ar_ball[k] = ar_ball[k - 1];
                        }
                        else
                        {
                            ar_ball[0] = o1;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 初始化球數與排序與球袋 (從1開始)
        /// </summary>
        /// <param name="n"></param>
        private static void initial_(int n)
        {
            bag = new ArrayList();//袋子
            ball = new int[n];//球
            for (int i = 0; i < ball.Length; i++)
            {
                ball[i] = i + 1;
            }
        }

        /// <summary>
        /// 隨機數字-使用微秒方式 <para>n=亂數最大值</para> 
        /// </summary>
        /// <param name="n">亂數最大值</param>
        /// <returns>返回亂數</returns>
        private static byte random_number(byte n)
        {
            long microseconds = (DateTime.Now.Ticks % n) + 1;
            //Console.WriteLine(microseconds);          
            return (byte)microseconds;
        }



    }
}

