using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSTest
{
    class TestHelper
    {
        public static string getString(int count)
        {
            int number;
            string checkCode = String.Empty;     //存放随机码的字符串   

            System.Random random = new Random();

            for (int i = 0; i < count; i++) //产生4位校验码   
            {
                number = random.Next();
                number = number % 36;
                if (number < 10)
                {
                    number += 48;    //数字0-9编码在48-57   
                }
                else
                {
                    number += 55;    //字母A-Z编码在65-90   
                }

                checkCode += ((char)number).ToString();
            }
            return checkCode; 
       }

        public static int getRandomNum(int left, int right)
        {
            Random ran = new Random();
            return ran.Next(left, right);
        }

        public static Model.Book initBook ()
        {
            string b_id = TestHelper.getString(10);
            ChineseString.RandomChinese str = new ChineseString.RandomChinese();
            string book_name = str.GetRandomChinese(5);
            string author = str.GetRandomChinese(3);
            string publisher = str.GetRandomChinese(2) + "出版社";
            int amout = TestHelper.getRandomNum(20, 50);

            Model.Book book = new Model.Book();
            book.Id = b_id;
            book.Name = book_name;
            book.Author = author;
            book.Publisher = publisher;
            book.Amount = amout.ToString();
            return book;
        }

    }

    class ChineseString
    {
        public class RandomChinese
        {
            public RandomChinese()
            {
            }

            public string GetRandomChinese(int strlength)
            {
                // 获取GB2312编码页（表） 
                Encoding gb = Encoding.GetEncoding("gb2312");

                object[] bytes = this.CreateRegionCode(strlength);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < strlength; i++)
                {
                    string temp = gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                    sb.Append(temp);
                }

                return sb.ToString();
            }

            /** 
            此函数在汉字编码范围内随机创建含两个元素的十六进制字节数组，每个字节数组代表一个汉字，并将 
            四个字节数组存储在object数组中。 
            参数：strlength，代表需要产生的汉字个数 
            **/
            private object[] CreateRegionCode(int strlength)
            {
                //定义一个字符串数组储存汉字编码的组成元素 
                string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

                Random rnd = new Random();

                //定义一个object数组用来 
                object[] bytes = new object[strlength];

                /**
                 每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bytes数组中 
                 每个汉字有四个区位码组成 
                 区位码第1位和区位码第2位作为字节数组第一个元素 
                 区位码第3位和区位码第4位作为字节数组第二个元素 
                **/
                for (int i = 0; i < strlength; i++)
                {
                    //区位码第1位 
                    int r1 = rnd.Next(11, 14);
                    string str_r1 = rBase[r1].Trim();

                    //区位码第2位 
                    rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i); // 更换随机数发生器的 种子避免产生重复值 
                    int r2;
                    if (r1 == 13)
                    {
                        r2 = rnd.Next(0, 7);
                    }
                    else
                    {
                        r2 = rnd.Next(0, 16);
                    }
                    string str_r2 = rBase[r2].Trim();

                    //区位码第3位 
                    rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                    int r3 = rnd.Next(10, 16);
                    string str_r3 = rBase[r3].Trim();

                    //区位码第4位 
                    rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                    int r4;
                    if (r3 == 10)
                    {
                        r4 = rnd.Next(1, 16);
                    }
                    else if (r3 == 15)
                    {
                        r4 = rnd.Next(0, 15);
                    }
                    else
                    {
                        r4 = rnd.Next(0, 16);
                    }
                    string str_r4 = rBase[r4].Trim();

                    // 定义两个字节变量存储产生的随机汉字区位码 
                    byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                    byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                    // 将两个字节变量存储在字节数组中 
                    byte[] str_r = new byte[] { byte1, byte2 };

                    // 将产生的一个汉字的字节数组放入object数组中 
                    bytes.SetValue(str_r, i);
                }

                return bytes;
            }
        }
    }
}
