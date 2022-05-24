using BuyOrSell.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyOrSell.ViewModels
{
    public class AdViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Too Long")]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Cattegory { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Town { get; set; }
        [Required]
        public DateTime Date { get; set; }

    }
}
