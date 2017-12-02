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

        protected override void Seed(AngryBirds.AngryBirdsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Players.AddOrUpdate(x => x.Id,
                new Models.Player() { Id = 1, Name = "Pontus Magnusson", Password = "Password123" },
                new Models.Player() { Id = 2, Name = "Fredrik Ridderheim", Password = "321drowssaP" },
                new Models.Player() { Id = 3, Name = "Nisse Nilsson", Password = "Lösenord" }
                );

            context.Levels.AddOrUpdate(x => x.Id,
                new Models.Level() { Id = 1, Name = "Level 1", Birds = 4 },
                new Models.Level() { Id = 2, Name = "Level 2", Birds = 3 },
                new Models.Level() { Id = 3, Name = "Level 3", Birds = 5 }
                );

            context.Score.AddOrUpdate(x => x.Id,
                new Models.Score() { Id = 1, LevelId = 1, PlayerId = 1, Points = 2},
                new Models.Score() { Id = 2, LevelId = 1, PlayerId = 2, Points = 3},
                new Models.Score() { Id = 3, LevelId = 2, PlayerId = 3, Points = 2},
                new Models.Score() { Id = 4, LevelId = 3, PlayerId = 2, Points = 4}
                );
        }
    }
}
