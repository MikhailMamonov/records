using Records.Domain;

namespace Records.Persistence
{
    public static class RecordsDbContextSeedData
    {
        static object synchlock = new object();
        static volatile bool seeded = false;

        public static void EnsureSeedData(this RecordsDbContext context)
        {
            if (!seeded && context.Records.Count() == 0)
            {
                lock (synchlock)
                {
                    if (!seeded)
                    {
                        var Categories = GenerateCategories();
                        var Records = GenerateRecords();
     
                        context.Categories.AddRange(Categories);
                        context.Records.AddRange(Records);

                        context.SaveChanges();
                        seeded = true;
                    }
                }
            }
        }

        #region Data
        public static Category[] GenerateCategories()
        {
            return new Category[] {
                  new Category
                  {
                      Name = "Blog",
                  },
                  new Category
                  {
                      Name= "Education",
                  },
                  new Category
                  {
                      Name = "Job"
                  },
                  new Category
                  {
                      Name = "Sport"
                  },
              };
        }

        public static Record[] GenerateRecords()
        {
            return 
                new Record[] {
                  new Record
                  {
                      CategoryId= 3,
                      Type= "income",
                      Amount=50000,
                      Description =  "salary",
                      CreationDate= new DateTime(),
                  },
                new Record
                  {
                      CategoryId= 3,
                      Type= "income",
                      Amount=50000,
                      Description =  "salary",
                      CreationDate= new DateTime(),
                  },
                new Record
                  {
                      CategoryId= 3,
                      Type= "income",
                      Amount=50000,
                      Description =  "salary",
                      CreationDate= new DateTime(),
                  },
                new Record
                  {
                      CategoryId= 3,
                      Type= "income",
                      Amount=50000,
                      Description =  "salary",
                      CreationDate= new DateTime(),
                  },
              };
        }

        #endregion
    }
}
