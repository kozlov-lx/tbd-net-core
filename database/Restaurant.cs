namespace tbd.database
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("restaurant")]
    public class Restaurant
    {
        [Key]
        [Column("restaurant_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")] [Required] public string Name { get; set; }

        [ForeignKey(nameof(City))]
        [Column("city_id")]
        [Required]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}