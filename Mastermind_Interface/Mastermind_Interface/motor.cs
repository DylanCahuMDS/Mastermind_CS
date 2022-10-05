namespace Mastermind_Interface
{

   // using Random ;

    using System.Collections.Generic;

    using System;

    using System.Linq;


    public class Motor
    {

        public static int[] choixPC = {0,0,0,0};

        public static int[] choixJoueur = {0,0,0,0};

        public static int genererRandom()
        {//permet de g�n�rer un chiffre al�atoire entre 1 et 6
            Random rd = new Random();
            int rand_num = rd.Next(1, 7);
            return rand_num;
        }
        
        public static void choixOrdinateur()
        {//g�n�re un tableau de 4 chiffres al�atoires
            for (int i = 0; i < 4; i++)
            {
                choixPC[i] = genererRandom();
            }
        }


        public static int[] ChoixJoueur()
        {//transforme un int de 4 chiffre en tableau de ces 4 m�me chiffres

            Console.WriteLine("Veuillez taper chiffres entre 1 et 6"); 
            
            //try catch to avoid player to put letters instead of numbers
            try
            {
                //check if the player put 4 numbers
                int choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 1111 || choix > 6666)
                {
                    Console.WriteLine("Veuillez entrer 4 chiffres entre 1 et 6");
                    ChoixJoueur();
                }
                else
                {
                    //transform the int into an array of 4 numbers
                    choixJoueur[0] = choix / 1000;
                    choixJoueur[1] = (choix % 1000) / 100;
                    choixJoueur[2] = (choix % 100) / 10;
                    choixJoueur[3] = choix % 10;
                }
            }
            catch (Exception e)
                {
                    Console.WriteLine("Veuillez entrer 4 chiffres");
                    ChoixJoueur();
                }

            int choixvalide = 0;
            for (int i = 0; i < 4; i++)
            {
                if (0 < choixJoueur[i] && choixJoueur[i] < 7)
                {
                    choixvalide = choixvalide + 1;
                }
            }
            if (choixvalide == 4 && choixJoueur.Length == 4)
            {
                // Console.WriteLine("Vous avez choisi : " + PrintValues(choixJoueur));//debug
                // Console.WriteLine("Et l'ordi a choisi : " + PrintValues(choixPC));//debug
                return choixJoueur;
            }
            else
            {
                Console.WriteLine("entr� invalide");
                ChoixJoueur();
                return choixJoueur; //bidouille
            }
        }


        public static int nbCommun(int[] TabPC, int[] TabJoueur)
        {//pour chaque chiffre du tableau, si il est dans le tableau du joueur, on incr�mente le compteur
            //variables locale
            int cpt = 0;
            int[] choixPC2 = { 0, 0, 0, 0 };
            int[] choixJoueur2 = { 0, 0, 0, 0 };
            TabPC.CopyTo(choixPC2, 0);
            TabJoueur.CopyTo(choixJoueur2, 0);
            for (int i = 0; i < 4; i++)
            {
                if (choixPC2[i] == choixJoueur2[i])
                {
                    choixPC2[i] = -1;
                    choixJoueur2[i] = -2; //Pour supprimer les doublons
                    cpt = cpt + 1;
                }
            }
            if (cpt == 4)
            {
                Console.WriteLine("Bravo ! Tu as r�ussi. La solution �t� : "+ PrintValues(TabPC));
                Console.ReadLine();
            }
            else if (cpt > 1)
            {
                Console.WriteLine(cpt + " bonnes r�ponses, essaye encore !");
            }
            else
            {
                Console.WriteLine(cpt + " bonne r�ponse, essaye encore !");
            }
            for (int i = 0; i < 4; i++)
            {

                if (choixPC2[i] == choixJoueur2[0] || choixPC2[i] == TabJoueur[1] || choixPC2[i] == TabJoueur[2] || choixPC2[i] == TabJoueur[3])
                {
                    Console.WriteLine("Mais " + choixJoueur2[i] + " est mal plac�");
                }
            }
            return cpt;
        }
        
        public static string PrintValues(int[] myArr)
        {
            string result = null;
            foreach (int i in myArr)
            {
                result = result + i;
            }
            return result;
        }

    public static void Jeu()
        {
            //variables locale
            var nbJeu = 0;
            choixOrdinateur();
            //Console.WriteLine(PrintValues(choixPC)); //debug
            ChoixJoueur(); //1�re manche
            while (nbCommun(choixPC, choixJoueur) != 4)
            {
                if (nbJeu <= 10)
                {
                    //soit 11 manches de plus donc 12 manches totals
                    nbJeu += 1;
                    ChoixJoueur();
                }
                else
                {
                    Console.WriteLine("Perdu, c'�tait : "+ PrintValues(choixPC));
                    Console.WriteLine("Voulez vous relancer une partie (y/n)");
                    string rep = Console.ReadLine();
                    if (rep == "y")
                    {
                        Jeu();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

//        static void Main()
//        {
//            Jeu();
//        }
    }
}