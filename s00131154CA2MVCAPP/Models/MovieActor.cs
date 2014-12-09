using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;

namespace s00131154CA2MVCAPP.Models
{
    public class MovieActor
    {
        [Key, Column(Order = 0)]    // Composite key (first key)
        public int MovieID { get; set; }
        [Key, Column(Order = 1)]        // Composite key (second key)
        public int ActorID { get; set; }
        public string ScreenName { get; set; }    // Additional Property for relationship
        // Nav Properties
        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}