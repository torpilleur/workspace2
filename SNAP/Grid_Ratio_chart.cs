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
using System.Windows.Controls.DataVisualization.Charting;
using System.Collections.ObjectModel;

namespace SNAP
{
    public class Grid_Ratio_chart
    {
        public ObservableCollection<KeyValuePair<string, float>> ValueList { get; private set; }
        public ObservableCollection<KeyValuePair<string, int>> ValueList_point { get; private set; }

        public Grid_Ratio_chart()
        {
            this.ValueList = new ObservableCollection<KeyValuePair<string, float>>();
            this.ValueList_point = new ObservableCollection<KeyValuePair<string, int>>();

        }

        public void Add(KeyValuePair<string, float> data)
        {
            ValueList.Add(data);
        }
        public void Addpoint(KeyValuePair<string, int> data)
        {
            ValueList_point.Add(data);
        }



        public void Afficher_Graphique(SNAP_DATABASE Ctx_database_SNAP, AreaSeries chartratio, AreaSeries chartpoint, string joueur)
    {
            //initialiser la liste:
            ValueList.Clear();
            ValueList_point.Clear();
            //Récupération des données du joueur selectionné
            //récupération de la liste des joueurs ayant le facteur de risque le plus haut
            var liste_partie_joueur = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Partie_ID FROM Entity_Occurence WHERE Joueurs_ID= '" + joueur + "'").ToList();
            var Liste_point_joueur = Ctx_database_SNAP.Database.SqlQuery<int>("SELECT Nombre_point FROM Entity_Occurence WHERE Joueurs_ID= '" + joueur + "'").ToList();
            var Liste_ratio_joueur= Ctx_database_SNAP.Database.SqlQuery<float>("SELECT ratio FROM Entity_Occurence WHERE Joueurs_ID= '" + joueur + "'").ToList();
            //enrichier la liste avec les données des joueurs.
            for (int i = 0; i < liste_partie_joueur.Count; i++)
            {
                string datepartie = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Date FROM Entity_partie WHERE Nom = '" + liste_partie_joueur.ElementAt(i) + "'").ToList().ElementAt(0);
                KeyValuePair<string, float> data=new KeyValuePair<string, float>(datepartie, Liste_ratio_joueur.ElementAt(i));
                this.Add(data);
                KeyValuePair<string, int> datapoint = new KeyValuePair<string, int>(datepartie, Liste_point_joueur.ElementAt(i));
                this.Addpoint(datapoint);

            }
            //conctruction du graphique:
            chartratio.ItemsSource = this.ValueList;
            chartpoint.ItemsSource = this.ValueList_point;

        }
      



    }
}