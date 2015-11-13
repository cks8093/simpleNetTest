using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    //LINQ는 Language Integrate Query의 약자로써 통합 질의 언어 라고 말할 수 있습니다..
    //기존의 Query는 Database의 데이터를 다루기 위해 사용하는 언어쯤으로 여겨 졌습니다. 
    //하지만 LINQ는 컬렉션 형태로 되어있는 모든 데이터에 대해 질의를 할 수 있는 마이크로소프트의 새로운 기술입니다.
    public class linqTest
    {
        public linqTest()
        {
            Profile[] arrProfile = 
            {
                new Profile(){Name="정우성", Height=186},
                new Profile(){Name="김태희", Height=158},
                new Profile(){Name="고현정", Height=172},
                new Profile(){Name="이문세", Height=178},
                new Profile(){Name="하하", Height=172}        
            };

            simple(arrProfile);

            join(arrProfile);
        }

        private void join(Profile[] arrProfile)
        {
            
        }

        private static void simple(Profile[] arrProfile)
        {

            var profiles1 = from profile in arrProfile
                            where profile.Height < 175
                            orderby profile.Height
                            select new
                            {
                                Name = profile.Name,
                                InchHeight = profile.Height * 0.393
                            };
            Console.WriteLine("linq 쿼리문");
            foreach (var profile in profiles1)
                Console.WriteLine("{0}, {1}", profile.Name, profile.InchHeight);

            Console.WriteLine();
            Console.WriteLine("람다식");
            var profiles2 = arrProfile.
                            Where(profile => profile.Height < 175).
                            OrderBy(profile => profile.Height).
                            Select(profile => new
                            {
                                Name = profile.Name,
                                InchHeight = profile.Height * 0.393
                            });
            foreach (var profile in profiles1)
                Console.WriteLine("{0}, {1}", profile.Name, profile.InchHeight);
        }
    }

    public class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
}
