//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDDontomate
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.ComponentModel.DataAnnotations;
    
    public partial class PRODUCTOS
    {

        //[Display(Name = "IDProducto")]
        //[Required(ErrorMessage = "IDProducto es requerido.")]
        //[RegularExpression("PROD[A-Z]{3}*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string IDPRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
