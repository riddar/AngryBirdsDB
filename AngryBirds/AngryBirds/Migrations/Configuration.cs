namespace AngryBirds.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngryBirds.AngryBirdsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngryBirdsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Players.AddOrUpdate(x => x.Id,
                new Models.Player() { Id = 1, Name = "Pontus Magnusson" },
                new Models.Player() { Id = 2, Name = "Fredrik Ridderheim" },
                new Models.Player() { Id = 3, Name = "Nisse Nilsson" }
                );

            context.Levels.AddOrUpdate(x => x.Id,
                new Models.Level() { Id = 1, Name = "Level 1", Birds = 4 },
                new Models.Level() { Id = 2, Name = "Level 2", Birds = 3 },
                new Models.Level() { Id = 3, Name = "Level 3", Birds = 5 }
                );

            //context.Score.AddOrUpdate(x => x.Id,
            //    new Models.Score() { Id = 1, Level = context.Levels.Where(l => l.Id == 1).First(), Player = context.Players.Where(p => p.Id == 1).First(), Points = 3 },
            //    new Models.Score() { Id = 2, Level = context.Levels.Where(l => l.Id == 2).First(), Player = context.Players.Where(p => p.Id == 1).First(), Points = 2 },
            //    new Models.Score() { Id = 3, Level = context.Levels.Where(l => l.Id == 1).First(), Player = context.Players.Where(p => p.Id == 2).First(), Points = 4 },
            //    new Models.Score() { Id = 4, Level = context.Levels.Where(l => l.Id == 3).First(), Player = context.Players.Where(p => p.Id == 3).First(), Points = 5 },
            //    new Models.Score() { Id = 5, Level = context.Levels.Where(l => l.Id == 2).First(), Player = context.Players.Where(p => p.Id == 3).First(), Points = 2 }
            //    );
        }
    }
}
