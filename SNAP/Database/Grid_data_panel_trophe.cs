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
    public class Grid_data_panel_trophe
    {
        public string Nom { get; set; }
        public string Description { get; set; }


        public void Afficher_Trophes(SNAP_DATABASE Ctx_database_SNAP, DataGrid dataGrid, TextBox Condition)
        {
            //Récupération des données via la base de données
            List<Entity_trophes> List_table_trophe = Ctx_database_SNAP.Table_Trophes.ToList();
            //réinitialiser le tableau d'affichage
            dataGrid.Items.Clear();
            Condition.Clear();
            

            for (int i = 0; i < List_table_trophe.Count(); i++)
            {
                Grid_data_panel_trophe trophe_i = new Grid_data_panel_trophe();
                trophe_i.Nom = List_table_trophe[i].Nom;
          
                dataGrid.Items.Add(trophe_i);
            }
            if(List_table_trophe.Count()>0)
            {
                Condition.Text = List_table_trophe[0].Condition_attribution;

            }
            

        }

        //ajouter un trophe
        public bool Ajouter_Trophes(SNAP_DATABASE Contexte_database, string Nom_trophe, string Description)
        {
            //regarder si les chanmps ne sont pas vides
            if (Nom_trophe != "" && Description != "")
            //regarder si le trophe est déjà présent
            {
                var Liste_Trophes = Contexte_database.Database.SqlQuery<string>("SELECT Nom FROM Entity_trophes").ToList();
                for (int i = 0; i < Liste_Trophes.Count(); i++)
                {
                    if (Liste_Trophes.ElementAt(i).ToString().Equals(Nom_trophe))
                    {
                        MessageBox.Show("Ajout impossible, ce trophé est déjà dans la liste.");
                        return false;
                    }
                }
                Entity_trophes trophe = new Entity_trophes
                {

                    Nom = Nom_trophe,
                    Condition_attribution= Description,

                };

                Contexte_database.Table_Trophes.Add(trophe);
                Contexte_database.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("Les champs ne doivent pas être vides");
                return false;
            }

        }

      

        //supprimer un trophe
        public void Supprimer_Trophes(SNAP_DATABASE Contexte_database, Grid_data_panel_trophe Grid_panel_Trophes_selected)
        {
            //récupération de l'ID unique grâce au surom
            var index_trophe = Contexte_database.Database.SqlQuery<int>("SELECT id FROM Entity_trophes WHERE Nom ='" + Grid_panel_Trophes_selected.Nom.ToString() + "'").ToList().ElementAt(0);
            //récupération de l'entité du trophe à supprimer
            Entity_trophes trophe_to_delete = Contexte_database.Table_Trophes.Find(index_trophe);
            //suppression du trophe en base de donnée et sauvegarde
            Contexte_database.Table_Trophes.Remove(trophe_to_delete);
            Contexte_database.SaveChanges();
        }
    }
}
