using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogumGunuParadoksu
{

    class Program
    {

        static Random r = new Random();

        static void Main(string[] args)
        {

            menu();

            Console.ReadKey();

        }

        static DogumBilgi[] rndm_Dogum(int n) /*n= kisi sayisi*/
            {

                DogumTarhi d = new DogumTarhi();

                int indeks1, indeks2, indeks3;   /*indeks1=random dogum günü yeri*/
                                                 /* indek2=randon dogum günü ayı*/
                                                 /*indeks3=random dogum günü günü*/

                DogumBilgi[] dogum_bilgi = new DogumBilgi[n];

                
                    for (int i = 0; i < n; i++)
                    {
                        dogum_bilgi[i] = new DogumBilgi();

                        indeks1 = r.Next(3);
                        dogum_bilgi[i].dogumYeri = d.yer[indeks1];

                        indeks2 = r.Next(12);
                        dogum_bilgi[i].dogumAy = indeks2;

                        indeks3 = r.Next(d.ay[indeks2]);
                        dogum_bilgi[i].dogumGun = indeks3;
                    }
                                  
            return dogum_bilgi;              
            }
        static int kisiSayisi()
            {
                int kisiSay;            /*yalnızca integer alınması gerekiyor*/
                Console.WriteLine("Kişi sayısını giriniz!");
                return kisiSay = Convert.ToInt32(Console.ReadLine());
            }
        static int[,,] sehirliEslesmeHesapla(DogumBilgi[] dogum_bilgi, int n)
        {

            int[,,] dogumGunuMatrisi = new int[3, 12, 31];

                for (int j = 0; j < n; j++)
                {
                    for (int i = j + 1; i < n; i++)
                    {


                        if (dogum_bilgi[j].dogumAy == dogum_bilgi[i].dogumAy &&
                            dogum_bilgi[j].dogumGun == dogum_bilgi[i].dogumGun &&
                            string.Compare(dogum_bilgi[j].dogumYeri, dogum_bilgi[i].dogumYeri) == 0 &&
                            dogum_bilgi[i].dogumYeri!=null)

                        {
                            if (j == n - 1)
                                break;

                            if (string.Compare(dogum_bilgi[j].dogumYeri, "Samsun") == 0)
                            {
                                dogumGunuMatrisi[0, dogum_bilgi[j].dogumAy, dogum_bilgi[j].dogumGun] += 1;
                            dogum_bilgi[i] = new DogumBilgi();
                            }
                            else if (string.Compare(dogum_bilgi[j].dogumYeri, "İzmir") == 0)
                            {
                                dogumGunuMatrisi[1, dogum_bilgi[j].dogumAy, dogum_bilgi[j].dogumGun] += 1;
                            dogum_bilgi[i] = new DogumBilgi();
                            }
                            else if (string.Compare(dogum_bilgi[j].dogumYeri, "Burdur") == 0)
                            {
                                dogumGunuMatrisi[2, dogum_bilgi[j].dogumAy, dogum_bilgi[j].dogumGun] += 1;
                            dogum_bilgi[i] = new DogumBilgi();
                            }

                        
                    }
                 }               
            }
            return dogumGunuMatrisi;
        }
        static void sehirliTestDeneyleri()
        {          
            int[,] test = new int[3, 11];
            int[,,] cakisma100 = new int[3,12, 31];
            int[,,] cakisma250 = new int[3,12, 31];
            int[,,] cakisma1000 = new int[3,12, 31];

            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine("\n" + (k + 1) + ".Deney sonucları listeleniyor(100 Kişi için)..\n");
                cakisma100 = sehirliEslesmeHesapla(rndm_Dogum(100), 100);
                test[0, k] = CakismaTopla3d(cakisma100);
                test[0, 10] += test[0, k];
                sonucBas3d(cakisma100);
                devamKontrol();
            }
            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine("\n" + (k + 1) + ".Deney sonucları listeleniyor(250 Kişi için)..\n");
                cakisma250 = sehirliEslesmeHesapla(rndm_Dogum(250), 250);
                test[1, k] = CakismaTopla3d(cakisma250);
                test[1, 10] += test[1, k];
                sonucBas3d(cakisma250);
                devamKontrol();
            }
            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine("\n" + (k + 1) + ".Deney sonucları listeleniyor(1000 Kişi için)..\n");
                cakisma1000 = sehirliEslesmeHesapla(rndm_Dogum(1000), 1000);
                test[2, k] = CakismaTopla3d(cakisma1000);
                test[2, 10] += test[2, k];
                sonucBas3d(cakisma1000);
                devamKontrol();
            }


            Console.WriteLine(" Deney No       100              250               1000");
            Console.WriteLine("----------   ---------         --------          ---------");

            for (int m = 0; m < 10; m++)
            {
                Console.WriteLine($"{m + 1,5} {test[0, m],12} {test[1, m],16} {test[2, m],19}");
            }
            Console.WriteLine("----------   ---------         --------          ---------");
            Console.Write("Ortalama: ");
            Console.WriteLine($"{(float)test[0, 10] / 10,9} {(float)test[1, 10] / 10,16} {(float)test[2, 10] / 10,19}");

        }
        static void sehirsizDeneyler()
        {
            int n;

            n = kisiSayisi();

            istenilenHesapla(rndm_Dogum(n), n);

       
        }
        static void istenilenHesapla(DogumBilgi[] dogum_bilgi, int n)
          {
              int[,] aylik = new int[12, 31];
                                    
                for (int j = 0; j < n; j++)
                {
                    for (int i = j + 1; i <= n - 1; i++)
                    {
                        if (dogum_bilgi[j].dogumAy == dogum_bilgi[i].dogumAy &&
                            dogum_bilgi[j].dogumGun == dogum_bilgi[i].dogumGun &&
                            dogum_bilgi[i].dogumYeri != null )
                            
                        {
                            aylik[dogum_bilgi[j].dogumAy, dogum_bilgi[j].dogumGun] += 1;
                            
                            dogum_bilgi[i] = new DogumBilgi();
                        }
                    }
                }
                Console.Write("Deney için sonuçlar listeleniyor.\n\n");

                for (int i = 0; i < 12; i++)
                {
                    ayAdiBas(i);

                    for (int j = 0; j < 31; j++)
                    {

                         Console.Write($"[{aylik[i, j],1}]");
                    
                        if (j == 15)
                            Console.Write("\n\t ");
                    }

                    Console.WriteLine();
                }                                                 
          }
        static int[,] eslesmeHesapla(DogumBilgi[] dogum_bilgi,int n)
        {
            int[,] cakismaDizi = new int[12, 31];

            for (int j = 0; j < n; j++)
            {
                for (int i = j + 1; i <= n-1; i++)
                {
                    if (dogum_bilgi[j].dogumAy == dogum_bilgi[i].dogumAy &&
                        dogum_bilgi[j].dogumGun == dogum_bilgi[i].dogumGun &&
                        dogum_bilgi[i].dogumYeri !=null)
                    {
                        cakismaDizi[dogum_bilgi[j].dogumAy, dogum_bilgi[j].dogumGun] += 1;                  
                        dogum_bilgi[i] = new DogumBilgi();
                    }
                }            
            }
           return cakismaDizi;
        }
        static int CakismaTopla3d(int[,,] matris )
        {
            int cakisma = 0;
        
            for(int m = 0; m < matris.GetLength(0); m++)
            {
                for(int i=0;i<matris.GetLength(1); i++)
                {
                    for(int j = 0; j < matris.GetLength(2); j++)
                    {
                        cakisma += matris[m, i, j];
                    }
                }
            }
            
            return cakisma;
        }
        static void sonucBas3d(int[,,] matris)
        {
            for(int m = 0; m < 3; m++)
            {
                sehirAdiBas(m);

                for (int i = 0; i < 12; i++)
                {
                    ayAdiBas(i);

                    for (int j = 0; j < 31; j++)
                    {

                        Console.Write($"[{matris[m , i, j],1}]");

                        if (j == 15)
                            Console.Write("\n\t ");
                    }

                    Console.WriteLine();
                }
            }
            
        }        
        static void sehirsiz_test_deneyleri() 
            {                                   
                int[,] test = new int[3, 11];
                int[,] cakisma100 = new int[12, 31];
                int[,] cakisma250 = new int[12, 31];
                int[,] cakisma1000 = new int[12, 31];

                for (int k = 0; k<10; k++)  {
                    Console.WriteLine("\n"+(k+1)+".Deney sonucları listeleniyor(100 Kişi için)..\n");
                    cakisma100 = eslesmeHesapla(rndm_Dogum(100), 100);           
                    test[0, k] = cakismaTopla(cakisma100);         
                    test[0, 10] += test[0, k];                                         
                    sonucBas(cakisma100);
                    devamKontrol();
                }
                for (int k = 0; k < 10; k++)
                {
                    Console.WriteLine("\n"+ (k+1) + ".Deney sonucları listeleniyor(250 Kişi için)..\n");
                    cakisma250 = eslesmeHesapla(rndm_Dogum(250), 250);
                    test[1, k] = cakismaTopla(cakisma250);
                    test[1, 10] += test[1, k];
                    sonucBas(cakisma250);
                    devamKontrol();
                }
                for (int k = 0; k < 10; k++)
                {
                    Console.WriteLine("\n"+ (k+1) + ".Deney sonucları listeleniyor(1000 Kişi için)..\n");
                    cakisma1000 = eslesmeHesapla(rndm_Dogum(1000), 1000);
                    test[2, k] = cakismaTopla(cakisma1000);
                    test[2, 10] += test[2, k];
                    sonucBas(cakisma1000);
                    devamKontrol();
                }


                Console.WriteLine(" Deney No       100              250               1000");
                Console.WriteLine("----------   ---------         --------          ---------");

                for (int m = 0; m < 10; m++)
                {
                    Console.WriteLine($"{m + 1,5} {test[0, m],12} {test[1, m],16} {test[2, m],19}");
                }
                Console.WriteLine("----------   ---------         --------          ---------");
                Console.Write("Ortalama: ");
                Console.WriteLine($"{(float)test[0, 10]/10,9} {(float) test[1, 10]/10,16} {(float)test[2, 10] / 10,19}");
            
            }
        static void sonucBas(int [,] matris)
        {
            for (int i = 0; i < 12; i++)
            {
                ayAdiBas(i);

                for (int j = 0; j < 31; j++)
                {

                    Console.Write($"[{matris[i, j],1}]");

                    if (j == 15)
                        Console.Write("\n\t ");
                }

                Console.WriteLine();
            }
        }
        static int cakismaTopla(int[,] matris)
        {
            int cakisma = 0;

            for(int i = 0; i < matris.GetLength(0); i++)
            {
                for(int j = 0; j < matris.GetLength(1); j++)
                {
                    cakisma += matris[i, j];
                }
            }

            return cakisma;
        }
        static void sifirlayici(int[,] matris)
            {           
                    for (int j = 0; j < 12; j++)
                    {
                        for (int k = 0; k < 31; k++)
                        {
                            matris[j, k] = 0;
                        }
                    }               
            }
        static void ayAdiBas(int indeks)
            {
                if (indeks == 0)
                    Console.Write("Ocak: ");
                else if (indeks == 1)
                    Console.Write("Şubat: ");
                else if (indeks == 2)
                    Console.Write("Mart: ");
                else if (indeks == 3)
                    Console.Write("Nisan: ");
                else if (indeks == 4)
                    Console.Write("Mayıs: ");
                else if (indeks == 5)
                    Console.Write("Haziran: ");
                else if (indeks == 6)
                    Console.Write("Temmuz: ");
                else if (indeks == 7)
                    Console.Write("Ağustos: ");
                else if (indeks == 8)
                    Console.Write("Eylül: ");
                else if (indeks == 9)
                    Console.Write("Ekim: ");
                else if (indeks == 10)
                    Console.Write("Kasım: ");
                else if (indeks == 11)
                    Console.Write("Aralık: ");

            }
        static void sehirAdiBas(int indeks)
        {
            if (indeks == 0)
                Console.Write("\t\t [Samsun] \n");
            else if (indeks == 1)
                Console.Write("\t\t[İzmir] \n");
            else if (indeks == 2)
                Console.Write("\t\t[Burdur] \n ");
        }
        static void devamKontrol()
            {
                string cevap;

                do
                {
                    Console.WriteLine("Bir sonraki deney sonuçlarını listelemek için bir tuşa basın:");
                    Console.WriteLine("(Menuye dönmek için m'ye basın.)");
                    cevap = Console.ReadLine();

                if (cevap == "m" )
                {
                    menu();
                    break;
                }

                } while (cevap == null);

            }
        static void menu()
            {
                int secim;

                Console.WriteLine("\n\n\t************Doğum Günü Paradoksu***********");
                Console.WriteLine("1->100,250 ve 1000 kişi için testi yapar ve sonuçları ekrana yazdırır.");
                Console.WriteLine("2->Gireceğiniz kişi sayısı için testi yapar ve sonuçları ekrana yazdırır.");
                Console.WriteLine("3->100,250 ve 1000 kişi için testi yapar ve sonuçları ekrana yazdırır[Şehir çakışmalarıda dahildir.]:");
    
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                    sehirsiz_test_deneyleri();
                    menu();

                    break;

                    case 2:
                    sehirsizDeneyler();
                    menu();
                    break;

                    case 3:
                    sehirliTestDeneyleri();
                    menu();
                    break;
                }            
            }
        }
    } 


   

    

    

