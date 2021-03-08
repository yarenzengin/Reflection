using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine(dortIslem.Topla2());
            ////topla 2 ye değer vermiyoruz çünkü ctordaki değerlerle çalışıyor
            ////AMA TOPLA metotunda bizden değer istiyor
            //Console.WriteLine(dortIslem.Topla(3, 4)); 

            var type = typeof(DortIslem); //reflection ile benim çalışacağım tip dortıslem
           /* Activator.CreateInstance(type); *///DortIslem dortIslem = new DortIslem(2, 3); Aynı şey, gelen tip ne ise onu instance et
            DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,6,7);//OBJE DÖNDÜRÜR ama biz dortısleme aktarmaya çalışıyoruz o yüzden Cast yapmalıyız
                                                      //parametrilisini kullanmak istediğimizde
            dortIslem.Topla(4,5);
            dortIslem.Topla2();

            var instance = Activator.CreateInstance(type,6,7);
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo.Invoke(instance,null));//getmethod istedeiğimiz metota ulaştık invoke ile çalıştırdık
            //hangi örneğin topla2 sini çalıştırayım
            Console.WriteLine(  "-----------------------------------------");

            var metotlar = type.GetMethods();
            foreach (var info in metotlar)
            {
                Console.WriteLine("metot adı : {0} ",info.Name );
                foreach (var parametre in info.GetParameters())
                {
                    Console.WriteLine("parametre : {0} ", parametre.Name);
                }
                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute : {0} ", attribute.GetType().Name);
                }
            }
        }
    }
    public class DortIslem
    {
        private int _sayi1;
        private int _sayi2;
        public DortIslem(int sayi1, int sayi2)// kullanıcıdan aldığımız yer
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {

        }
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        [MethodName("Carpma")]
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
    public class MethodNameAttribute : Attribute
    {
       

        public MethodNameAttribute(string name)
        {
         
        }
    }

}
