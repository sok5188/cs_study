// See https://aka.ms/new-console-template for more information
#define CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
/// <summary>
/// 
/// </summary>
namespace Hello
{
    class Profile
    {
        public string Name { get; set; }
        public int height { get; set; }

    }
    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }
    class Program
    {
        
           
        
        static void Main(string[] args)
        {
            Profile[] arrpro =
            {
                new Profile(){Name ="가",height=186},
                new Profile(){Name ="나", height=158},
                new Profile(){Name="da",height=172},
                new Profile(){ Name="라",height =178},
                new Profile(){ Name="마",height=171}
            };
            var listpro = from profile in arrpro
                          orderby profile.height
                          group profile by profile.height < 175 into g
                          select new { groupkey = g.Key, profiles = g };

            foreach (var Group in listpro)
            {
                Console.WriteLine("under 175" + Group.groupkey);
                foreach(var profile in Group.profiles)
                    Console.WriteLine("{0},{1}",profile.Name,profile.height);

            }
            Product[] arrProduct =
            {
                new Product(){Title ="a", Star="가"},
                new Product(){Title ="b", Star="나"},
                new Product(){Title ="c", Star="다"},
                new Product(){Title="d", Star="라"},
                new Product{Title ="e", Star="마"}
            };
            var listPROFILE = from profile in arrpro
                              join product in arrProduct on profile.Name equals product.Star
                              select new
                              {
                                  Name = profile.Name,
                                  Title = product.Title,
                                  Height = profile.height
                              };
            foreach (var Profile in listPROFILE)
                Console.WriteLine("이름:{0} 작품:{1} 키:{2}",Profile.Name,Profile.Title,Profile.Height);
            listPROFILE = from profile in arrpro
                          join product in arrProduct on profile.Name equals product.Star into ps
                          from product in ps.DefaultIfEmpty(new Product() { Title = "Empty" })
                          select new
                          {
                              Name = profile.Name,
                              Title = product.Title,
                              Height = profile.height
                          };
            foreach (var Profile in listPROFILE)
                Console.WriteLine("이름:{0} 작품:{1} 키:{2}", Profile.Name, Profile.Title, Profile.Height);
        }
    }
}