//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactosWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mensaje
    {
        public int Id { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public bool Leido { get; set; }
        public System.DateTime Fecha { get; set; }
    
        
    }
}