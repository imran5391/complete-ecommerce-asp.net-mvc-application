using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eTickets.Models
{
    public class Movie: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; } //import the namespace for the MovieCategory namespace eTickets.Data


        //Relationships
        public List<Actor_Movie> Actor_Movies { get; set; } //define relation movie have multiple actormovies

        //Cinema
        public int CinemaId { get; set; } //define relation movie have multiple cinema with foregnkey
        [ForeignKey("CinemaId")]

        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; } //define relation movie have multiple producer with foregnkey
        [ForeignKey("ProducerId")]

        public Producer Producer { get; set; }
    }
}
