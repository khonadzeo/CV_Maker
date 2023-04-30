using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CV_Maker.Repository.Models
{
    /// <summary>
    /// represents personal details oject type
    /// </summary>
    public partial class PersonalDetail
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        [Unicode(false)]
        public string Phone { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Address { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string City { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string State { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string Country { get; set; } = null!;

        [StringLength(10)]
        [Unicode(false)]
        public string PostalCode { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Education { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string WorkExperience { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Reference { get; set; } = null!;

        [StringLength(200)]
        [Unicode(false)]
        public string About { get; set; } = null!;

        [StringLength(200)]
        [Unicode(false)]
        public string Hobbies { get; set; } = null!;

        [StringLength(200)]
        [Unicode(false)]
        public string Certificates { get; set; } = null!;

        [StringLength(200)]
        [Unicode(false)]
        public string Languages { get; set; } = null!;

        [StringLength(200)]
        [Unicode(false)]
        public string Skills { get; set; } = null!;
    }
}
