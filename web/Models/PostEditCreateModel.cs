using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Mvc;

namespace web.Models
{
    public class PostEditCreateModel
    {
        public int PostId { get; set; }

        [Display(Name = "Resim")]
        [Required(ErrorMessage = "*Resim seçilmedi")]
        public string PostImg { get; set; }

        [Display(Name = "Başlık", Prompt = "Başlık girin")]
        [Required(ErrorMessage = "*Başlık zorunlu alan")]
        public string PostTitle { get; set; }

        [Display(Name = "Özet", Prompt = "Özet girin")]
        [Required(ErrorMessage = "*Özet zorunlu alan")]
        public string PostSummary { get; set; }

        [Required(ErrorMessage = "*Kategori seçilmelidir")]
        public int? CategoryId { get; set; }

        [Display(Name = "Ekleyen kişi", Prompt = "Ekleyen kişi girin")]
        [Required(ErrorMessage = "*Ekleyen kişi zorunlu alan")]
        public string AddedBy { get; set; }

        [Display(Name = "Post url", Prompt = "Başlıktan otomatik olarak çevrilir")]
        [Required(ErrorMessage = "*Post url zorunlu alan")]
        public string PostUrl { get; set; }

        [Display(Name = "İçerik", Prompt = "İçerik girin")]
        public string PostContent { get; set; }
    }
}