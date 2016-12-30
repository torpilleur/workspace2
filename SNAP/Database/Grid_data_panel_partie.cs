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
    public class Grid_data_panel_partie
    {
        public string Nom { get; set; }
        public string Date { get; set; }
        public int Nbjoueurs { get; set; }
    

        public void Afficher_Partie(SNAP_DATABASE Ctx_database_SNAP, DataGrid dataGrid)
        {
            //Récupération des données via la base de données
            List<Entity_partie> List_table_partie = Ctx_database_SNAP.Table_Parties.ToList();
            //réinitialiser le tableau d'affichage
            dataGrid.Items.Clear();
           


            for (int i = 0; i < List_table_partie.Count(); i++)
            {
                Grid_data_panel_partie partie_i = new Grid_data_panel_partie();
                partie_i.Nom = List_table_partie[i].Nom;
                partie_i.Date = List_table_partie[i].Date;

                dataGrid.Items.Add(partie_i);
            }
           
        }
        public bool Ajouter_Partie(SNAP_DATABASE Contexte_database, string nom, string date, int nb_joueur)
        {
            //regarder si la partie est déjà présent
            
                var Liste_parties = Contexte_database.Database.SqlQuery<string>("SELECT Nom FROM Entity_partie").ToList();
                for (int i = 0; i < Liste_parties.Count(); i++)
                {
                    if (Liste_parties.ElementAt(i).ToString().Equals(nom))
                    {
                        MessageBox.Show("Ajout impossible, cette partie est déjà dans la liste.");
                        return false;
                    }
                }
            Entity_partie partie = new Entity_partie
            {

                    Nom = nom,
                    Date = date,
                    Nombre_de_participant = nb_joueur,

            };

                Contexte_database.Table_Parties.Add(partie);
                Contexte_database.SaveChanges();
                return true;
         }
       

    }

}
