﻿using System;
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
        
        public int Id { get; set; }

        public string Name { get; set; }

        public int Birds { get; set; }

        public virtual IList<Score> Scores { get; set; }
    }

    public class Score : IComparable<Score>
    {

        public int Id { get; set; }
        
        public int Points { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        public int LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        public int CompareTo(Score score)
        {
            return Points.CompareTo(score.Points);
        }

        public override string ToString()
        {
            return Points.ToString();
        }
    }
}
