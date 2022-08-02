using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Models
{
    public class CategoryEditCreateModel
    {
        public int CategoryId { get; set; }

        [Display(Name = "Resim")]
        [Required(ErrorMessage = "*Resim seçilmedi")]
        public string CategoryImg { get; set; }

        [Display(Name = "Kategori adı", Prompt = "Kategori adı girin")]
        [Required(ErrorMessage = "*Kategori adı zorunlu alan")]
        public string CategoryName { get; set; }

        [Display(Name = "Kategori url", Prompt = "Kategori adından otomatik olarak çevrilir")]
        [Required(ErrorMessage = "*Kategori url zorunlu alan")]
        public string CategoryUrl { get; set; }

        [Display(Name = "Göster")]
        public bool ShowHome { get; set; }
        public List<Post> Post { get; set; }
    }
}