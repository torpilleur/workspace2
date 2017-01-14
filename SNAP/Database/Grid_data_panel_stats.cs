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
    public class Grid_data_panel_stats
    {
        public int? classement { get; set; }
        public string Surnom { get; set; }
        public int? Nombre_de_point { get; set; }
        public int? Niveau { get; set; }
        public string Nom_classement { get; set; }


        /*****Methodes de gestion du pannel, affichage, ajout de jouerus...)**********************/
        public void Afficher_Stats(SNAP_DATABASE Ctx_database_SNAP,DataGrid dataGrid_stats)
        {
            //Récupération des données via la base de données
            List<Entity_joueurs> List_table_joueur = Ctx_database_SNAP.Table_Joueurs.ToList();
            //réinitialiser le tableau d'affichage
            dataGrid_stats.Items.Clear();

            for (int i = 0; i < List_table_joueur.Count(); i++)
            {
                Grid_data_panel_stats stats_joueur = new Grid_data_panel_stats();
                stats_joueur.classement = List_table_joueur[i].classement;
                stats_joueur.Surnom = List_table_joueur[i].Surnom;
                stats_joueur.Nombre_de_point = List_table_joueur[i].Nombre_de_point;
                stats_joueur.Niveau = List_table_joueur[i].Niveau;
                stats_joueur.Nom_classement = List_table_joueur[i].Nom_classement;

                dataGrid_stats.Items.Add(stats_joueur);
            }
        }

       

        }

    }

   
    
