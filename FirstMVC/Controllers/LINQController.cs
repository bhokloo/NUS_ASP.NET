using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using FirstMVC.Models;
using System.Collections;

namespace FirstMVC.Controllers
{
    public class LINQController : Controller
    {
        public ActionResult NormalLINQ()
        {

            //___________________________LINQ QUERY FOR LIST...________________________________________________

            List<string> s = new List<string> { "indrajit", "maurya", "kanojia" };

            var item = from sa in s
                       where sa.Length > 6  //length of each string...indrajit = 8.
                       orderby sa.Length
                       select sa;

            foreach (var saa in item)
            {
                Debug.WriteLine(saa);               /*
                                                        kanojia
                                                        indrajit 
                                                    */
            }

            //Deafult is Acending...small to big.
            var item1 = from sa in s
                       orderby sa.Length
                       select sa;

            foreach (var saa in item1)
            {
                Debug.WriteLine(saa);                    /*
                                                             maurya
                                                             kanojia
                                                             indrajit
                                                         */
            }
            // ORDEbyDescending.
            var item2 = from sa in s
                        orderby sa.Length descending
                        select sa;

            foreach (var saa in item2)
            {
                Debug.WriteLine(saa);                                /*
                                                                        indrajit
                                                                        kanojia         
                                                                        maurya
                                                                     */
            }

            //______________________________NEW Keyword..........

            var item3 = from sa in s
                        select new { sa };
            foreach (var saa in item3)
            {
                Debug.WriteLine("@@@@@@@@ " +saa); 
                                                            /* if object contains object it comes under { objectname = .... }
                                                            @@@@@@@@ { sa = indrajit }
                                                            @@@@@@@@ { sa = maurya }
                                                            @@@@@@@@ { sa = kanojia }
                                                            */
            }

            //______________________________NEW Keyword Again..........

            var item4 = from sa in s
                        select new { sa };
            foreach (var saa in item3)
            {
                Debug.WriteLine("##### " + saa.sa);     /*
                                                        ##### indrajit
                                                        ##### maurya
                                                        ##### kanojia
                                                        */

            }



            //_________________________LINQ QUERY FOR MULTIPLE  LIST...______________________________________

            List<string> ss = new List<string> { "laban", "meghalaya" };
            List<string> sss = new List<string> { "dei", "siliguri" };
            List<int> ssss = new List<int> { 2, 4 };

            var threelist = from first in ss
                            from second in sss
                            from third in ssss //where first.Length > 3 or where second.Length > 3
                            select new { first, second, third };

            foreach (var saa in threelist)
            {
                //Debug.WriteLine(saa.first + "  ---  " + saa.second + "----" + saa.third);
                Debug.WriteLine(saa);
                                                /*
                                                    { first = laban, second = dei, third = 2 }
                                                    { first = laban, second = dei, third = 4 }
                                                    { first = laban, second = siliguri, third = 2 }
                                                    { first = laban, second = siliguri, third = 4 }
                                                    { first = meghalaya, second = dei, third = 2 }
                                                    { first = meghalaya, second = dei, third = 4 }
                                                    { first = meghalaya, second = siliguri, third = 2 }
                                                    { first = meghalaya, second = siliguri, third = 4 }
                                                */
            }

            var threelista = from first in ss
                            from second in sss
                            from third in ssss 
                            select new { first, second, third };

            foreach (var saa in threelista)
            {
                Debug.WriteLine(saa.first + "  ---  " + saa.second + "----" + saa.third);
                                                    /*
                                                        laban-- - dei----2
                                                        laban-- - dei----4
                                                        laban-- - siliguri----2
                                                        laban-- - siliguri----4
                                                        meghalaya-- - dei----2
                                                        meghalaya-- - dei----4
                                                        meghalaya-- - siliguri----2
                                                        meghalaya-- - siliguri----4
                                                    */

            }

            var threelist1 = from first in ss
                             from second in sss
                             from third in ssss 
                             select new { first };  //3 list are there so it loops 4 times...

            foreach (var saa in threelist1)
            {
                Debug.WriteLine(saa.first);
                                                    /*
                                                        laban
                                                        laban
                                                        laban
                                                        laban
                                                        meghalaya
                                                        meghalaya
                                                        meghalaya
                                                        meghalaya
                                                    */
            }


            int[] num1 = { 0, 1, 2, 3, 4  };
            int[] num2 = { 5, 6, 7, 8, 9 };

            var dcd = from n in num1
                      from nn in num2
                      where n * nn > 20
                      select new { n, nn };

            foreach (var sd in dcd)
            {
                Debug.WriteLine(sd.n +","+ sd.nn);
            }



            //______________LINQ in MODEL CLASS_________________________________________________

            List < Demo > demoer = new List<Demo> {

                    new Demo() {name ="indrajit", age = 12 },
                    new Demo() {name ="Maurya", age =  13 }
                };

            var demoas = from demos in demoer
                         where demos.age > 10 //or where demos.age == demoer.Min(x => x.age)
                         orderby demos.age
                         select new { demos.age,demos.name }; 
                         //select new { demos }; //Passing only object then in Debug we speicfy saa.demos.age
            
            //Or You CAN sue the syntax below
            var demovar = demoer.Where(x => x.age > 10).OrderBy(x => x.age).Select(x => x.name);


            foreach (var saa in demoas)
            {
                    Debug.WriteLine(saa);   //OP :&&&&&&&&&&&&&&& { name = indrajit, age = 12 }
            }


            //______________BUILT IN AGGREGATE FUNCTIONS IN LINQ using MODEl CLASS_________________________________________________

            List<Demo> demo1 = new List<Demo> {

                new Demo() {name ="indrajit", age = 13, gender = 'M' },
                new Demo() {name ="Maurya", age =  13, gender = 'M'},
                new Demo() {name ="Kanojia", age =  133, gender = 'F'}
            };

            var minage = demo1.Min(x => x.age); //find minimum number of age of objects...
            var maxage = demo1.Max(x => x.age); //find maximum age of objects.
            var SumOFAges = demo1.Sum(x => x.age); //calculates age of all objects...
            var average = Convert.ToInt32(demo1.Average(x => x.age)); //Convert.ToInt32 removes the decimal part...find average of age of all objects.
            var count = demo1.Count(); //counts the number of objects..

            Debug.WriteLine(minage + "--" + maxage + "--" + SumOFAges + "--" + average + "--" + count);


            //___________________FIND THE AGE,NAME OF YOUNGEST (Query Syntax + Method Syntax in one quest)________________

            var findyoung = from findyoungest in demo1
                            where findyoungest.age == demo1.Min(x => x.age)
                            select new { findyoungest.name,findyoungest.gender };

            foreach (var dk in findyoung)
            {
                Debug.WriteLine(dk); //OP :  { name = indrajit, gender = M }
            }


            //*************_____OTHER LINQ Methods_____************

            // .Single() // return a single
            // .SingleOrDefault() // return a single or the default value if there are no matches
            // .First() // return the first object it encounters that matches
            // .FirstOrDefault() // return the first object it encounters that matches, or the default value if no matches


            //___________________Ordering and Grouping________________

            var finda = from find in demo1
                        where find.age > 10
                        orderby find.age
                        group find by find.gender; //here group by provides a KEY......


            // OR

            var findaOtherway = demo1.OrderBy(x => x.name).GroupBy(x => x.gender);


            foreach (var dka in finda)
            {

                Debug.WriteLine("GROUP BY and ORDER by " + dka.Key + "===" + dka.Count());
                foreach (var bz in dka)
                {
                    Debug.WriteLine(bz.name +" == "+ bz.gender +" == "+bz.age);
                }
                                                                                        /* OP:
                                                                                        GROUP BY and ORDER by M=== 2
                                                                                        indrajit == M == 13
                                                                                        Maurya == M == 13
                                                                                        GROUP BY and ORDER by F=== 1
                                                                                        Kanojia == F == 133 */
            }


            return null;
        }
    }
}