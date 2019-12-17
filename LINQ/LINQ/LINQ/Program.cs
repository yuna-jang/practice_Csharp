using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Profile
    {
        public string name { get; set; }
        public int height { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //func1();
            func2();
        }

        static void func1()
        {
            Profile[] arrProfile =
            {
                new Profile(){name = "김보경", height=160},
                new Profile(){name = "서현수", height=164},
                new Profile(){name = "장윤아", height=165}
            };

            var profiles = from profile in arrProfile
                           where profile.height > 163
                           orderby profile.height
                           select new
                           {
                               Name = profile.name,
                               InchHeight = profile.height * 0.393
                           };

            foreach (var profile in profiles)
                Console.WriteLine($"이름 : {profile.Name}, 키 (인치) : {profile.InchHeight}");

            var listProfile = from profile in arrProfile
                              orderby profile.height
                              group profile by profile.height < 175 into g
                              select new { GroupKey = g.Key, Profiles = g };

            foreach (var Group in listProfile)
            {
                Console.WriteLine($"175 미만?:{Group.GroupKey}");

                foreach(var profile in Group.Profiles)
                {
                    Console.WriteLine($"{profile.name}, {profile.height}");

                }
            }
            Console.ReadLine();
        }

        static void func2()
        {
            Profile[] arrProfile =
            {
                new Profile(){name = "정우성", height=186},
                new Profile(){name = "김태희", height=158 },
                new Profile(){name = "고현정", height=172},
                new Profile(){name = "이문세", height=178},
                new Profile(){name = "하하", height=171}
            };
            Product[] arrProduct =
            {
                new Product(){Title="비트", Star="정우성"},
                new Product(){Title="CF다수", Star="김태희"},
                new Product(){Title="아이리스", Star="김태희"},
                new Product(){Title="모래시계", Star="고현정"},
                new Product(){Title="예찬", Star="이문세"}
            };

            var listProfile = from profile in arrProfile
                              join product in arrProduct on profile.name equals product.Star
                              select new
                              {
                                  Name = profile.name,
                                  Height = profile.height,
                                  Title = product.Title
                              };

            Console.WriteLine("---------내부조인결과---------");
            foreach(var profile in listProfile){
                Console.WriteLine($"이름 : {profile.Name}, 키 : {profile.Height}, 작품 : {profile.Title}");
            }

            var listProfile2 =
                from profile in arrProfile
                join product in arrProduct on profile.name equals product.Star into ps
                from product in ps.DefaultIfEmpty(new Product() { Title = "없음ㅋ" }) // 연결데이터 (오른쪽 데이터)에 비어있는 값을 디폴트로 채워줌
                select new
                {
                    Name = profile.name,
                    Work = product.Title,
                    Height = profile.height
                };

            Console.WriteLine("");
            Console.WriteLine("---------외부조인결과---------");
            foreach (var profile in listProfile2)
            {
                Console.WriteLine($"이름 : {profile.Name}, 키 : {profile.Height}, 작품 : {profile.Work}");
            }

            Console.ReadLine();
        }
    }
    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }
}
