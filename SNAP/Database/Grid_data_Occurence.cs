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

namespace SNAP.Database
{
    public class Grid_data_Occurence
    {
        public string partie_ID { get; set; }
        public string joueurs_ID { get; set; }
        public string trophe_ID { get; set; }
        public int? nombre_kill { get; set; }
        public int? nombre_death { get; set; }
        public int? nombre_assist { get; set; }


        public void Ajouter_Occurence(SNAP_DATABASE Contexte_database, string partie, string joueur, string trophe, int? nbkill, int? nbdeath, int? nbassist)
        {
            //faire la lisaison entr la partie les joueur et les trophes


            Entity_Occurence Occurence = new Entity_Occurence
              {

                Partie_ID = partie,
                Joueurs_ID =joueur,
                Trophe_ID =trophe,
                Nombre_kill =nbkill,
                Nombre_death=nbdeath,
                Nombre_assist=nbassist,

              };

                  Contexte_database.Table_Occurence.Add(Occurence);
                  Contexte_database.SaveChanges();
            
        }

        public void modifier_trophe (int trophe)
        {

        }
        //supprimer un joueur
        public void Supprimer_Occurence(SNAP_DATABASE Contexte_database, Grid_data_panel_partie Grid_panel_partie_selected)
        {
           //Suppression de toiutes les occurences ayant le nom de la partie à supprimer dans les entités (tables) Occurences et partie.
            Contexte_database.Database.ExecuteSqlCommand("DELETE FROM Entity_partie WHERE Nom ='" + Grid_panel_partie_selected.Nom.ToString() + "'");
            Contexte_database.Database.ExecuteSqlCommand("DELETE FROM Entity_Occurence WHERE Partie_ID ='" + Grid_panel_partie_selected.Nom.ToString() + "'");
            //sauvegarde du contexte de la base
           
            Contexte_database.SaveChanges();
        }
    }
}
