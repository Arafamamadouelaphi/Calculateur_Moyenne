using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public  class MaquetteModel:IEquatable<MaquetteModel>
    {
        public int Id;
        public ReadOnlyCollection<UE> UES { get; set; }

        private readonly List<UE> ues = new List<UE>();

        public ReadOnlyCollection<BlocModel> BLOCS { get; private set; }
        private readonly List<BlocModel> blocs = new List<BlocModel>();

        public string NomMaquette;
        public string GetNomMaquette()
        { 
            return GetNomMaquette(); 
        }
        private void SetNomMaquette(string value)
        {       
            
            if (string.IsNullOrWhiteSpace(GetNomMaquette()))

            { 
                throw new ArgumentException("Le Nom de la maquette est obligatoire");
            }
            
        }
    

        public MaquetteModel(int id, string nomMaquette, List<UE> u, List<BlocModel> blc)
        {
            Id = id;
            NomMaquette = nomMaquette;
            UES = u.AsReadOnly();
            BLOCS = blc.AsReadOnly();

        }
        public MaquetteModel(List<UE> u, List<BlocModel> blc)
        {
            UES = u.AsReadOnly();
            BLOCS = blc.AsReadOnly();
        }

        public MaquetteModel(long id,string nomMaquette)
        {
            Id = Id;
            SetNomMaquette(nomMaquette);
          
        }
        public MaquetteModel( string nomMaquette)
        {

            SetNomMaquette(nomMaquette);
            
        }

        public void supprimer(UE e)
        {
            ues.Remove(e);
        }
        public void supprimer(BlocModel e)
        {
            blocs.Remove(e);
        }
        public bool ajouteUE(UE e)
        {
            if (IsExiste(e))
            {
                ues.Add(e);
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ajouteBloc(BlocModel b)
        {
            if (IsExiste(b))
            {
                blocs.Add(b);
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool IsExiste(BlocModel b)
        {
            if (blocs.Contains(b))
                return true;
            return false;
        }

        public bool IsExiste(UE newue)
        {
            if (ues.Contains(newue))
                return true;
            return false;
        }

        public bool Equals(MaquetteModel other)
        {
            return Equals(other.GetNomMaquette());
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as MaquetteModel);
        }

        public MaquetteModel(string nomMaquette, int id)

        {
            SetNomMaquette(nomMaquette);
            Id = id;
        }
        public void setNomMaquete(string nom)
        {
            SetNomMaquette(nom);
        }
       



    }

}
