//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_E_FILM_FLM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_E_FILM_FLM()
        {
            this.AvisFilm = new HashSet<T_E_AVIS_AVI>();
            this.FavorisFilm = new HashSet<T_E_COMPTE_CPT>();
        }
    
        public int FLM_ID { get; set; }
        public string FLM_TITRE { get; set; }
        public string FLM_SYNOPSIS { get; set; }
        public System.DateTime FLM_DATEPARUTION { get; set; }
        public decimal FLM_DUREE { get; set; }
        public string FLM_GENRE { get; set; }
        public string FLM_URLPHOTO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<T_E_AVIS_AVI> AvisFilm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<T_E_COMPTE_CPT> FavorisFilm { get; set; }
    }
}
