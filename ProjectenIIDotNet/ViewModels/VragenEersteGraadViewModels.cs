using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectenIIDotNet.Models.Domein;

namespace ProjectenIIDotNet.ViewModels
{
    public class VragenEersteGraadViewModel
    {
        public VragenEersteGraadViewModel ()
        {
            
        }

        [Display(Name = "Wat is de warmste maand?")]
        [Required(ErrorMessage = "{0}")]
        public Maand WarmsteMaandVraag { get; set; }

        [Display(Name = "Wat is de temperatuur van de warmste maand?")]
        [Required(ErrorMessage = "{0}")]
        public string TemperatuurWarmsteMaandVraag { get; set; }

        [Display(Name = "Wat is de koudste maand?")]
        [Required(ErrorMessage = "{0}")]
        public Maand KoudsteMaandVraag { get; set; }

        [Display(Name = "Wat is de temperatuur van de koudste maand?")]
        [Required(ErrorMessage = "{0}")]
        public string TemperatuurKoudsteMaandVraag { get; set; }

        [Display(Name = "Hoeveel droge maanden zijn er?")]
        [Required(ErrorMessage = "{0}")]
        public int AantalDrogeMaandenVraag { get; set; }

        [Display(Name = "Hoeveel neerslag is er in de zomer?")]
        [Required(ErrorMessage = "{0}")]
        public int NeerslagZomerVraag { get; set; }

        [Display(Name = "Hoeveel neerslag is er in de winter?")]
        [Required(ErrorMessage = "{0}")]
        public int NeerslagWinterVraag { get; set; }
    }
}