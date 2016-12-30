using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SNAP.Database;
using SNAP;

namespace SNAP.Database
{
   public class Statistiques
    {



        public void Calcul_stats(SNAP_DATABASE Ctx_database_SNAP, string nom_partie,string[] Nom_classement_ref, int[] point_classement_ref)
        {
           
            //récupération de la liste des joueurs ayant le plus de kill
            var most_kill_p = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT MAX(Nombre_kill) FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "'").ToList();
            var Joueur_most_kill = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Joueurs_ID FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND Nombre_kill='" + most_kill_p.ElementAt(0).ToString() + "'").ToList();

            //récupération de la liste des joueurs ayant le plus de death
            var most_death_p = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT MAX(Nombre_death) FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "'").ToList();
            var Joueur_most_death = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Joueurs_ID FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND Nombre_death='" + most_death_p.ElementAt(0).ToString() + "'").ToList();
            //récupération de la liste des joueurs ayant le plus d'assist
            var most_assist_p = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT MAX(Nombre_assist) FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "'").ToList();
            var Joueur_most_assist = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Joueurs_ID FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND Nombre_assist='" + most_assist_p.ElementAt(0).ToString() + "'").ToList();
            //récupération de la liste des joueurs ayant le facteur de risque le plus haut
            var most_Facteur_risque_p = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT MAX(facteur_de_risque) FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "'").ToList();
            var Joueur_most_FC = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Joueurs_ID FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND facteur_de_risque='" + most_Facteur_risque_p.ElementAt(0).ToString() + "'").ToList();
            //récupération de la liste des joueurs ayant le facteur de risque le plus bas
            var less_Facteur_risque_p = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT MIN(facteur_de_risque) FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "'").ToList();
            var Joueur_less_FC = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Joueurs_ID FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND facteur_de_risque='" + less_Facteur_risque_p.ElementAt(0).ToString() + "'").ToList();



            //trophée mort dans l'oeuf
            var index_occ = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND Nombre_death='" + most_death_p.ElementAt(0).ToString() + "'").ToList().ElementAt(0);
            var occ_tomodify = Ctx_database_SNAP.Table_Occurence.Find(index_occ);
            string trophee = "mort dans l'oeuf";
            Entity_Occurence updatedOcc = occ_tomodify;
            updatedOcc.Trophe_ID = updatedOcc.Trophe_ID + "\n" + trophee;
            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(occ_tomodify).CurrentValues.SetValues(updatedOcc);
            Ctx_database_SNAP.SaveChanges();

            //trophée Hero
            index_occ = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND facteur_de_risque='" + most_Facteur_risque_p.ElementAt(0).ToString() + "'").ToList().ElementAt(0);
            occ_tomodify = Ctx_database_SNAP.Table_Occurence.Find(index_occ);
            trophee = "Héro";
            updatedOcc = occ_tomodify;
            updatedOcc.Trophe_ID = updatedOcc.Trophe_ID + "\n" + trophee;

            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(occ_tomodify).CurrentValues.SetValues(updatedOcc);
            Ctx_database_SNAP.SaveChanges();

            //trophée Poule mouillée
            index_occ = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND facteur_de_risque='" + less_Facteur_risque_p.ElementAt(0).ToString() + "'").ToList().ElementAt(0);
            occ_tomodify = Ctx_database_SNAP.Table_Occurence.Find(index_occ);
            trophee = "Poule mouillée";
            updatedOcc = occ_tomodify;
            updatedOcc.Trophe_ID = updatedOcc.Trophe_ID + "\n" + trophee;

            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(occ_tomodify).CurrentValues.SetValues(updatedOcc);
            Ctx_database_SNAP.SaveChanges();

            //trophée Folie meurtrière
            index_occ = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND Nombre_kill='" + most_kill_p.ElementAt(0).ToString() + "'").ToList().ElementAt(0);
            occ_tomodify = Ctx_database_SNAP.Table_Occurence.Find(index_occ);
            trophee = "Folie meurtrière";
            updatedOcc = occ_tomodify;
            updatedOcc.Trophe_ID = updatedOcc.Trophe_ID + "\n" + trophee;

            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(occ_tomodify).CurrentValues.SetValues(updatedOcc);
            Ctx_database_SNAP.SaveChanges();

            //trophée Docteur
            index_occ = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND Nombre_assist='" + most_assist_p.ElementAt(0).ToString() + "'").ToList().ElementAt(0);
            occ_tomodify = Ctx_database_SNAP.Table_Occurence.Find(index_occ);
            trophee = "Docteur";
            updatedOcc = occ_tomodify;
            updatedOcc.Trophe_ID = updatedOcc.Trophe_ID + "\n" + trophee;

            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(occ_tomodify).CurrentValues.SetValues(updatedOcc);
            Ctx_database_SNAP.SaveChanges();



            //détermination du meilleur joueur
            string Best_player = "";
            if (Joueur_most_kill.ElementAt(0).ToString() == Joueur_most_FC.ElementAt(0).ToString())
            {
                Best_player = Joueur_most_kill.ElementAt(0).ToString();

            }

            else if ((Joueur_most_assist.ElementAt(0).ToString() != Joueur_most_death.ElementAt(0).ToString()) && (Joueur_most_assist.ElementAt(0).ToString() == Joueur_most_FC.ElementAt(0).ToString()))
            {
                Best_player = Joueur_most_assist.ElementAt(0).ToString();
            }
            else if ((Joueur_most_kill.ElementAt(0).ToString() != Joueur_most_death.ElementAt(0).ToString()) && (Joueur_most_kill.ElementAt(0).ToString() != Joueur_less_FC.ElementAt(0).ToString()))
            {
                Best_player = Joueur_most_kill.ElementAt(0).ToString();
            }
            else Best_player = Joueur_most_kill.ElementAt(0).ToString();

            //mise à jour meilleur joueur
            index_occ = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "' AND Joueurs_ID='" + Best_player + "'").ToList().ElementAt(0);
            occ_tomodify = Ctx_database_SNAP.Table_Occurence.Find(index_occ);

            updatedOcc = occ_tomodify;
            updatedOcc.Best_player = "oui";

            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(occ_tomodify).CurrentValues.SetValues(updatedOcc);
            Ctx_database_SNAP.SaveChanges();
            //mise à jour de la table partie
            index_occ = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_partie WHERE Nom= '" + nom_partie + "'").ToList().ElementAt(0);
            var part_tomodify = Ctx_database_SNAP.Table_Parties.Find(index_occ);
            Entity_partie updatedP = part_tomodify;
            updatedP = part_tomodify;
            updatedP.Best_player = Best_player;

            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(part_tomodify).CurrentValues.SetValues(updatedP);
            Ctx_database_SNAP.SaveChanges();
            //mise à jour de la table joueur
            //récupération de l'ID unique grâce au surom
            var index_joueur = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Joueurs WHERE Surnom ='" + Best_player + "'").ToList().ElementAt(0);
            //Récupération du joueur et de ses paramètres.
            var Joueur_tomodify = Ctx_database_SNAP.Table_Joueurs.Find(index_joueur);
            //Modifier le joueur grâce à une nouvelle entrée.
            Entity_joueurs updatedUser = Joueur_tomodify;
            updatedUser.Nb_parties_won = updatedUser.Nb_parties_won.Value + 1;

            // mise à jour et sauvegarde du contexte.
            Ctx_database_SNAP.Entry(Joueur_tomodify).CurrentValues.SetValues(updatedUser);
            Ctx_database_SNAP.SaveChanges();

            // récupération de la liste des joueurs pour la partie donnée
           
            Attribution_points_classement(nom_partie, Ctx_database_SNAP, Nom_classement_ref,point_classement_ref);

        }
          public void Attribution_points_classement(string nom_partie, SNAP_DATABASE Ctx_database_SNAP, string[] Nom_classement_ref,int[] point_classement_ref)
        {
            //Système de point:
            int Point_meilleur_joueur = 6;
            int Point_ratio_0 = -1;
            int Point_ratio_1 = 1;
            int Point_ratio_3 = 2;
            int Point_trophee_max_kill = 2;
            int Point_trophee_max_FC = 2;
            int Point_trophee_max_Assist = 2;
            int Point_trophee_max_Death = -1;
            int Point_trophee_Less_FC = -2;
            


            var Liste_occurence_partie = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT ID FROM Entity_Occurence WHERE Partie_ID= '" + nom_partie + "'").ToList();
            for (int i = 0; i<Liste_occurence_partie.Count; i++)
            {
                string trophee_max_FC = "non";
                string trophee_max_death = "non";
                string trophee_less_FC = "non";
                string trophee_max_kill = "non";
                string trophee_max_assist = "non";
                
                


                //attribution des points pour chacun des joueurs
                //0: recupération des infos utilies au calcul de point
                //Surnom du joueur
                var surnom_joueur = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Joueurs_ID FROM Entity_Occurence WHERE ID= '" + Liste_occurence_partie[i] + "'").ToList().ElementAt(0);
                //ratio
                var ratio_joueur = Ctx_database_SNAP.Database.SqlQuery<float>("SELECT ratio FROM Entity_Occurence WHERE ID= '" + Liste_occurence_partie[i]+ "'").ToList().ElementAt(0);
                    //trophee:
                var trophee= Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Trophe_ID FROM Entity_Occurence WHERE ID= '" + Liste_occurence_partie[i] + "'").ToList().ElementAt(0);
                if (trophee.Contains("Héro")) trophee_max_FC = "oui";
                if (trophee.Contains("mort dans l'oeuf")) trophee_max_death = "oui";
                if (trophee.Contains("Poule mouillée")) trophee_less_FC = "oui";
                if (trophee.Contains("Folie meurtrière")) trophee_max_kill = "oui";
                if (trophee.Contains("Docteur")) trophee_max_assist = "oui";
                //vainqueur
                var Bestplayer = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Best_player FROM Entity_Occurence WHERE ID= '" + Liste_occurence_partie[i] + "'").ToList().ElementAt(0);
                // niveau actuel du joueur
                var level_J= Ctx_database_SNAP.Database.SqlQuery<int>("SELECT Niveau FROM Entity_joueurs WHERE Surnom = '" + surnom_joueur + "'").ToList().ElementAt(0);
                //nombre de point actuel:
                var Point_J = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT Nombre_de_point FROM Entity_joueurs WHERE Surnom = '" + surnom_joueur + "'").ToList().ElementAt(0);

                int New_val_point_J = Point_J;
                // vé&rification du niveau pour appliquer les différentes pondérations.

                if (level_J < 5)
                {
                    //perte de point non applicable

                    //1: Vérification si c'est le meilleur joueur.
                    if (Bestplayer.Equals("oui")) New_val_point_J = New_val_point_J + 6;

                    //2:Vérification des trophée.=> gain ou perte de point selon le statut
                    else
                    {
                        if (trophee_max_FC.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_kill.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_assist.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        

                    }
                    if (ratio_joueur >= 3)
                    {
                        New_val_point_J = New_val_point_J + 3;
                    }
                    else
                    {
                        if (ratio_joueur >= 2)
                        {
                            New_val_point_J = New_val_point_J + 2;
                        }
                        else
                        {
                            if (ratio_joueur >= 1) New_val_point_J = New_val_point_J + 1;
                        }
                    }

                    //last: +1 pour la participation à la partie
                    New_val_point_J = New_val_point_J + 1;
                    //si pt<0 =>0
                    if (New_val_point_J < 0) New_val_point_J = 0;


                }
                if (level_J >= 5 && level_J <= 16)
                {
                    //1: Vérification si c'est le meilleur joueur.
                    if (Bestplayer.Equals("oui")) New_val_point_J = New_val_point_J + 6;

                    //2:Vérification des trophée.=> gain ou perte de point selon le statut
                    else
                    {
                        if (trophee_max_FC.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_kill.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_assist.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_less_FC.Equals("oui")) New_val_point_J = New_val_point_J - 2;
                        if (trophee_max_death.Equals("oui")) New_val_point_J = New_val_point_J-1;
                       

                    }
                    if (ratio_joueur >= 3)
                    {
                        New_val_point_J = New_val_point_J + 3;
                    }
                    else
                    {
                        if (ratio_joueur >= 2)
                        {
                            New_val_point_J = New_val_point_J + 2;
                        }
                        else
                        {
                            if (ratio_joueur >= 1)
                            {
                                New_val_point_J = New_val_point_J + 1;
                            }
                            else New_val_point_J = New_val_point_J - 1;
                        }

                    }

                    //last: +1 pour la participation à la partie
                    New_val_point_J = New_val_point_J + 1;
                    //si pt<0 =>0
                    if (New_val_point_J < 0) New_val_point_J = 0;


                }
                if (level_J >= 17 && level_J <= 19)
                {
                    //1: Vérification si c'est le meilleur joueur.
                    if (Bestplayer.Equals("oui")) New_val_point_J = New_val_point_J + 6;
                   

                    //2:Vérification des trophée.=> gain ou perte de point selon le statut
                    else
                    {
                        if (trophee_max_FC.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_kill.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_assist.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        
                      
                    }
                    if (ratio_joueur >= 3)
                    {
                        New_val_point_J = New_val_point_J + 3;
                    }
                    else
                    {
                        if (ratio_joueur >= 2)
                        {
                            New_val_point_J = New_val_point_J + 2;
                        }
                        else
                        {
                            if (ratio_joueur >= 1)
                            {
                                New_val_point_J = New_val_point_J + 1;
                            }
                            
                        }

                    }

                    if (trophee_less_FC.Equals("oui")|| trophee_max_death.Equals("oui")|| ratio_joueur<1) New_val_point_J = New_val_point_J - 30;
                    //si pt<0 =>0
                    if (New_val_point_J < 0) New_val_point_J = 0;
                    //last: +1 pour la participation à la partie
                    New_val_point_J = New_val_point_J + 1;
                   


                }
                if (level_J >= 20 && level_J <= 22)
                {
                    //1: Vérification si c'est le meilleur joueur.
                    if (Bestplayer.Equals("oui")) New_val_point_J = New_val_point_J + 6;

                    //2:Vérification des trophée.=> gain ou perte de point selon le statut
                    else
                    {
                        if (trophee_max_FC.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_kill.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_assist.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                    

                    }
                    if (ratio_joueur >= 3)
                    {
                        New_val_point_J = New_val_point_J + 3;
                    }
                    else
                    {
                        if (ratio_joueur >= 2)
                        {
                            New_val_point_J = New_val_point_J + 2;
                        }
                        else
                        {
                            if (ratio_joueur >= 1)
                            {
                                New_val_point_J = New_val_point_J + 1;
                            }
                           
                        }

                    }
                    if (trophee_less_FC.Equals("oui") || trophee_max_death.Equals("oui") || ratio_joueur < 1) New_val_point_J = New_val_point_J - 50;
                    //si pt<0 =>0
                    if (New_val_point_J < 0) New_val_point_J = 0;
                    //last: +1 pour la participation à la partie
                    New_val_point_J = New_val_point_J + 1;


                }
                if (level_J ==23)
                {
                    //1: Vérification si c'est le meilleur joueur.
                    if (Bestplayer.Equals("oui")) New_val_point_J = New_val_point_J + 6;

                    //2:Vérification des trophée.=> gain ou perte de point selon le statut
                    else
                    {
                        if (trophee_max_FC.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_kill.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_assist.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                     

                    }
                    if (ratio_joueur >= 3)
                    {
                        New_val_point_J = New_val_point_J + 3;
                    }
                    else
                    {
                        if (ratio_joueur >= 2)
                        {
                            New_val_point_J = New_val_point_J + 2;
                        }
                        else
                        {
                            if (ratio_joueur >= 1)
                            {
                                New_val_point_J = New_val_point_J + 1;
                            }
                            
                        }

                    }
                    if (trophee_less_FC.Equals("oui") || trophee_max_death.Equals("oui") || ratio_joueur < 1) New_val_point_J = New_val_point_J - 100;
                    //si pt<0 =>0
                    if (New_val_point_J < 0) New_val_point_J = 0;
                    //last: +1 pour la participation à la partie
                    New_val_point_J = New_val_point_J + 1;


                }
                if (level_J == 24)
                {
                    //1: Vérification si c'est le meilleur joueur.
                    if (Bestplayer.Equals("oui")) New_val_point_J = New_val_point_J + 6;

                    //2:Vérification des trophée.=> gain ou perte de point selon le statut
                    else
                    {
                        if (trophee_max_FC.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_kill.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                        if (trophee_max_assist.Equals("oui")) New_val_point_J = New_val_point_J + 2;
                  
                    }
                    if (ratio_joueur >= 3)
                    {
                        New_val_point_J = New_val_point_J + 3;
                    }
                    else
                    {
                        if (ratio_joueur >= 2)
                        {
                            New_val_point_J = New_val_point_J + 2;
                        }
                        else
                        {
                            if (ratio_joueur >= 1)
                            {
                                New_val_point_J = New_val_point_J + 1;
                            }
                            
                        }

                    }
                    if (trophee_less_FC.Equals("oui") || trophee_max_death.Equals("oui") || ratio_joueur < 1) New_val_point_J = New_val_point_J - 250;
                    //si pt<0 =>0
                    if (New_val_point_J < 0) New_val_point_J = 0;
                    //last: +1 pour la participation à la partie
                    New_val_point_J = New_val_point_J + 1;

                }

                //attribution du classement
                bool classement_MAJ = false;
                int j = point_classement_ref.Length;
                while (classement_MAJ == false)
                {
                    j--;
                    if (New_val_point_J >= point_classement_ref[j])
                    {
                        classement_MAJ = true;
                        //mise à jour des tables
                        var index_joueur = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT id FROM Entity_Joueurs WHERE Surnom ='" + surnom_joueur + "'").ToList().ElementAt(0);
                        var Joueur_tomodify = Ctx_database_SNAP.Table_Joueurs.Find(index_joueur);
                        Entity_joueurs updatedUser = Joueur_tomodify;
                        updatedUser.Nombre_de_point = New_val_point_J;
                        updatedUser.Niveau = j+1;
                        updatedUser.Nom_classement = Nom_classement_ref[j];
                     
                        // mise à jour et sauvegarde du contexte.
                        Ctx_database_SNAP.Entry(Joueur_tomodify).CurrentValues.SetValues(updatedUser);
                        Ctx_database_SNAP.SaveChanges();

                       
                        var occ_tomodify = Ctx_database_SNAP.Table_Occurence.Find(Liste_occurence_partie[i]);
                 
                        Entity_Occurence updatedOcc = occ_tomodify;
                        updatedOcc.Nombre_point = New_val_point_J;
                        // mise à jour et sauvegarde du contexte.
                        Ctx_database_SNAP.Entry(occ_tomodify).CurrentValues.SetValues(updatedOcc);
                        Ctx_database_SNAP.SaveChanges();

                    }
                }


            }

        }

        

    }

   
}
