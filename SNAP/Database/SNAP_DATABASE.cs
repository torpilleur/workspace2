namespace SNAP.Database
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class SNAP_DATABASE : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « Model1 » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « SNAP.Database.Model1 » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « Model1 » dans le fichier de configuration de l'application.
        public SNAP_DATABASE()
            : base("name=SNAP.Properties.Settings.database2ConnectionString")
        {
        }
  
        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<Entity_joueurs> Table_Joueurs { get; set; }
        public virtual DbSet<Entity_partie> Table_Parties { get; set; }
 
        public virtual DbSet<Entity_Classement_Nom> Table_Classement_Nom { get; set; }
        public virtual DbSet<Entity_Occurence> Table_Occurence { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class Entity_joueurs
    {
        public int ID { get; set; }

        public string Nom { get; set; }
        public string Surnom { get; set; }
        public string Arme_primaire { get; set; }
        public string Arme_secondaire { get; set; }
        public string Profil { get; set; }
        public int? Nombre_kill_tot { get; set; }
        public int? Nombre_death_tot { get; set; }
        public int? Nombre_assistance_tot { get; set; }
        public float? Ratio_tot { get; set; }
        public int? Niveau { get; set; }
        public int? Nombre_de_point { get; set; }
        public int? Nombre_de_participation { get; set; }
        public string Nom_classement { get; set; }
        public int? Nb_parties_won { get; set; }
        public int? classement { get; set; }

    }
    public class Entity_partie
    {
        public int ID { get; set; }

        public string Nom { get; set; }
        public string Date { get; set; }
        public int? Nombre_de_participant { get; set; }
        public string Best_player { get; set; }
        

    }
  
    public class Entity_Classement_Nom
    {
        public int ID { get; set; }

        public string Nom { get; set; }
        public int? Nombre_point_ref { get; set; }
       
    }
    public class Entity_Occurence
    {
        public int ID { get; set; }

        public string Partie_ID { get; set; }
        public string Joueurs_ID { get; set; }
        public string Trophe_ID { get; set; }
        public int? Nombre_kill { get; set; }
        public int? Nombre_death { get; set; }
        public int? Nombre_assist { get; set; }
        public float? ratio { get; set; }
        public int? facteur_de_risque { get; set; }
        public string Best_player { get; set; }
        public int? Nombre_point { get; set; }
        public int? Delta_point { get; set; }


    }
}