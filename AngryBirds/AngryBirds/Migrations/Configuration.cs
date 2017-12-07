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
            Models.Player player1 = new Models.Player() { Id = 1, Name = "Pontus Magnusson" };
            Models.Player player2 = new Models.Player() { Id = 2, Name = "Fredrik Ridderheim" };
            Models.Player player3 = new Models.Player() { Id = 3, Name = "Nisse Nilsson" };

            Models.Level level1 = new Models.Level() { Id = 1, Name = "Level 1", Birds = 4 };
            Models.Level level2 = new Models.Level() { Id = 2, Name = "Level 2", Birds = 3 };
            Models.Level level3 = new Models.Level() { Id = 3, Name = "Level 3", Birds = 5 };
            

            context.Players.AddOrUpdate(x => x.Id,
                player1,
                player2,
                player3
                );

            context.Levels.AddOrUpdate(x => x.Id,
                level1,
                level2,
                level3
                );

            context.Score.AddOrUpdate(x => x.Id,
                new Models.Score() { Id = 1, Level = level1, Player = player1, Points = 3 },
                new Models.Score() { Id = 2, Level = level2, Player = player1, Points = 2 },
                new Models.Score() { Id = 3, Level = level1, Player = player2, Points = 4 },
                new Models.Score() { Id = 4, Level = level3, Player = player3, Points = 5 },
                new Models.Score() { Id = 5, Level = level2, Player = player3, Points = 2 }
                );
        }
    }
}
