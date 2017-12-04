using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngryBirds.Models
{
    class Entities
    {

    }

    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual IList<Score> Scores { get; set; }
    }

    public class Level
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Birds { get; set; }

        public virtual IList<Score> Scores { get; set; }
    }

    public class Score : IComparable<Score>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Points { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        public int LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        public int CompareTo(Score score)
        {
            if (Points > score.Points) return -1;
            if (Points == score.Points) return 0;
            return 1;
        }
    }
}
