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



        public void Calcul_stats(SNAP_DATABASE Ctx_database_SNAP, string nom_partie)
        {
            // récupération de la liste des joueurs pour la partie donnée
           // var Liste_occurence_partie = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Joueurs_ID FROM Entity_Occurence WHERE Partie_ID= '"+nom_partie+"'").ToList();
            //récupération de la liste des joueurs ayant le plus de kill
            //récupération de la liste des joueurs ayant le plus de death
            //récupération de la liste des joueurs ayant le plus d'assist
            //détermination du meilleur joueur


           /* for (int i = 0; i < Liste_parties.Count(); i++)
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
            Contexte_database.SaveChanges();*/

        }
       /* public string Attribution_trophes(string Joueur)
        {

            return "Aucun";

        }

        public string[,] Attribution_points_classement(string Joueur, int nb_point, string[,] Liste_classements)
        { int nb_point_new = 0;


            return (Liste_classements);

        }

    }*/

}

   
}
