using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electronics_store.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key] //ptc este cheia primara
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //ca sa ni se genereze id ul atunci cand inseram un rand nou
        public Guid Id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DateCreated { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //genereaza o valoare atunci cand un rand este inserat sau updatat
        public DateTime? DateModified { get; set; }
    }
}