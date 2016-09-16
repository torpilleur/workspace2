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


namespace SNAP
{
    public class Grid_data_panel_joueurs
    {
        public string Nom { get; set; }
        public string Surnom { get; set; }
        public string Arme_primaire { get; set; }
        public string Arme_secondaire { get; set; }
        public string Profil { get; set; }


        /*****Methodes de gestion du pannel, affichage, ajout de jouerus...)**********************/
        public void Afficher_Joueurs(SNAP_DATABASE Ctx_database_SNAP,DataGrid dataGrid )
        {
            //Récupération des données via la base de données
            List<Entity_joueurs> List_table_joueur = Ctx_database_SNAP.Table_Joueurs.ToList();
            //réinitialiser le tableau d'affichage
            dataGrid.Items.Clear();

            for (int i = 0; i < List_table_joueur.Count(); i++)
            {
                Grid_data_panel_joueurs joueur_i = new Grid_data_panel_joueurs();
                joueur_i.Nom = List_table_joueur[i].Nom;
                joueur_i.Surnom = List_table_joueur[i].Surnom;
                joueur_i.Arme_primaire = List_table_joueur[i].Arme_primaire;
                joueur_i.Arme_secondaire = List_table_joueur[i].Arme_secondaire;
                joueur_i.Profil = List_table_joueur[i].Profil;

                dataGrid.Items.Add(joueur_i);
            }
        }

        //ajouter un joueur
        public bool Ajouter_Joueurs(SNAP_DATABASE Contexte_database, string Nom_joueur, string Surnom_joueur, string Arme_primaire_joueur, string Arme_secondaire_joueur, string Profil_joueur)
        {
            //regarder si les chanmps ne sont pas vides
            if (Nom_joueur != "" && Surnom_joueur != "" && Arme_primaire_joueur != "" && Arme_secondaire_joueur != "" && Profil_joueur != "")
            //regarder si le joueur est déjà présent
            {
                var Liste_joueurs = Contexte_database.Database.SqlQuery<string>("SELECT Surnom FROM Entity_joueurs").ToList();
                for (int i = 0; i < Liste_joueurs.Count(); i++)
                {
                    if (Liste_joueurs.ElementAt(i).ToString().Equals(Surnom_joueur))
                    {
                        MessageBox.Show("Ce surnom est déjà utilisé. Choisir un autre surnom");
                        return false;
                    }
                }
                Entity_joueurs Joueur = new Entity_joueurs
                {

                    Nom = Nom_joueur,
                    Surnom = Surnom_joueur,
                    Arme_primaire = Arme_primaire_joueur,
                    Arme_secondaire = Arme_secondaire_joueur,
                    Profil = Profil_joueur,
                    Nombre_kill_tot = 0,
                    Nombre_death_tot = 0,
                    Nombre_assistance_tot = 0,
                    Ratio_tot = 0,
                    Classement = "NA",
                    Nombre_de_point = 0,
                    Nombre_de_participation = 0,
                    Nom_classement = "Niveau 0",
                };

                Contexte_database.Table_Joueurs.Add(Joueur);
                Contexte_database.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("Les champs ne doivent pas être vides" + "\nLes champs non applicables doivent être remplis avec NA");
                return false;
            }

        }

        //modifier un joueur
        public bool Modifier_Joueurs(SNAP_DATABASE Contexte_database, string Nom_joueur, string Surnom_joueur, string Arme_primaire_joueur, string Arme_secondaire_joueur, string Profil_joueur)
        {

            //regarder si les chanmps ne sont pas vides
            if (Nom_joueur != "" && Surnom_joueur != "" && Arme_primaire_joueur != "" && Arme_secondaire_joueur != "" && Profil_joueur != "")

            {
                //récupération de l'ID unique grâce au surom
                var index_joueur = Contexte_database.Database.SqlQuery<int>("SELECT id FROM Entity_Joueurs WHERE Surnom ='" + Surnom_joueur + "'").ToList().ElementAt(0);
                //Récupération du joueur et de ses paramètres.
                var Joueur_tomodify = Contexte_database.Table_Joueurs.Find(index_joueur);
                //Modifier le joueur grâce à une nouvelle entrée.
                Entity_joueurs updatedUser = Joueur_tomodify;
                updatedUser.Nom = Nom_joueur;
                updatedUser.Surnom = Surnom_joueur;
                updatedUser.Arme_primaire = Arme_primaire_joueur;
                updatedUser.Arme_secondaire = Arme_secondaire_joueur;
                updatedUser.Profil = Profil_joueur;

                // mise à jour et sauvegarde du contexte.
                Contexte_database.Entry(Joueur_tomodify).CurrentValues.SetValues(updatedUser);
                Contexte_database.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("Les champs ne doivent pas être vides" + "\nLes champs non applicables doivent être remplis avec NA");
                return false;
            }
        }

        //supprimer un joueur
        public void Supprimer_Joueurs(SNAP_DATABASE Contexte_database, Grid_data_panel_joueurs Grid_panel_joueurs_selected)
        {
            //récupération de l'ID unique grâce au surom
            var index_joueur = Contexte_database.Database.SqlQuery<int>("SELECT id FROM Entity_Joueurs WHERE Surnom ='" + Grid_panel_joueurs_selected.Surnom.ToString() + "'").ToList().ElementAt(0);
            //récupération de l'entité du joueur à supprimer
            Entity_joueurs Joueur_to_delete = Contexte_database.Table_Joueurs.Find(index_joueur);
            //suppression du joueur en base de donnée et sauvegarde
            Contexte_database.Table_Joueurs.Remove(Joueur_to_delete);
            Contexte_database.SaveChanges();
        }


        public void Update_Addpartie(SNAP_DATABASE Contexte_database, string nom_joueur, int? Num_kill, int? Num_death,int? Num_assist, float? Num_ratio)
            {
            
            //récupérer les stats avant l'ajout de cette partie afin de pouvoir les ajouter.
            var nb_kill = Contexte_database.Database.SqlQuery<int?>("SELECT Nombre_kill_tot FROM Entity_Joueurs WHERE Surnom ='" + nom_joueur + "'");
            var nb_death = Contexte_database.Database.SqlQuery<int?>("SELECT Nombre_death_tot FROM Entity_Joueurs WHERE Surnom ='" + nom_joueur + "'");
            var nb_assist = Contexte_database.Database.SqlQuery<int?>("SELECT Nombre_assistance_tot FROM Entity_Joueurs WHERE Surnom ='" + nom_joueur + "'");
            var nb_ratio = Contexte_database.Database.SqlQuery<float?>("SELECT Ratio_tot FROM Entity_Joueurs WHERE Surnom ='" + nom_joueur + "'");
            var nb_participation = Contexte_database.Database.SqlQuery<int?>("SELECT Nombre_de_participation FROM Entity_Joueurs WHERE Surnom ='" + nom_joueur + "'");

            //calcul des nouvelles stats
            int? nbkill_tot = nb_kill.ElementAt(0) + Num_kill;
            int? nbdeath_tot = nb_death.ElementAt(0) + Num_death;
            int? nbassist_tot = nb_assist.ElementAt(0) + Num_assist;
            int? nbparticipation_tot = nb_participation.ElementAt(0) + 1;
            float? ratio_tot = (nb_ratio.ElementAt(0)* nb_participation.ElementAt(0) + Num_ratio)/ nbparticipation_tot;

            //mise à jour des stats
          /* Contexte_database.Database.ExecuteSqlCommand("UPDATE Entity_Joueurs SET Nombre_kill_tot = '" + nbkill_tot + "' WHERE Surnom ='"+ nom_joueur+"'");
            Contexte_database.Database.ExecuteSqlCommand("UPDATE Entity_Joueurs SET Nombre_death_tot = '" + nbdeath_tot + "' WHERE Surnom ='" + nom_joueur + "'");
            Contexte_database.Database.ExecuteSqlCommand("UPDATE Entity_Joueurs SET Nombre_assistance_tot = '" + nbassist_tot + "' WHERE Surnom ='" + nom_joueur + "'");
            Contexte_database.Database.ExecuteSqlCommand("UPDATE Entity_Joueurs SET Ratio_tot = '" + ratio_tot.ToString() + "' WHERE Surnom ='" + nom_joueur + "'");
            Contexte_database.Database.ExecuteSqlCommand("UPDATE Entity_Joueurs SET Nombre_de_participation = '" + nbparticipation_tot + "' WHERE Surnom ='" + nom_joueur + "'");
            Contexte_database.Entry(Joueur_tomodify).Reload();*/

            var index_joueur = Contexte_database.Database.SqlQuery<int>("SELECT id FROM Entity_Joueurs WHERE Surnom ='" + nom_joueur + "'").ToList().ElementAt(0);
            var Joueur_tomodify = Contexte_database.Table_Joueurs.Find(index_joueur);
            Entity_joueurs updatedUser = Joueur_tomodify;
            updatedUser.Nombre_kill_tot = nbkill_tot;
            updatedUser.Nombre_death_tot = nbdeath_tot;
            updatedUser.Nombre_assistance_tot = nbassist_tot;
            updatedUser.Ratio_tot = ratio_tot;
            updatedUser.Nombre_de_participation = nbparticipation_tot;

            // mise à jour et sauvegarde du contexte.
            Contexte_database.Entry(Joueur_tomodify).CurrentValues.SetValues(updatedUser);
         
            
            Contexte_database.SaveChanges();


        }

    }

   
    }
