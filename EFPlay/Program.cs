using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PotterShopContext(args[0]))
            {
                Console.WriteLine("connection string == " + args[0]);

                var allpots = from p in context.Pots where p.Status == "available" select p;

                foreach (var p in allpots)
                    Console.WriteLine(p.Name + "::" + p.Description + "::" + p.Id);
            }

            using (var context = new PotterShopContext(args[0]))
            {
                var potswithimages = from pot in context.Pots where pot.Status == "available"
                                     join image in context.PotImages on pot.Id equals image.PotsId into gj
                                     from subimage in gj.DefaultIfEmpty() where subimage == null || subimage.Type == "main"
                                     select new { pot, subimage.File };

                foreach (var p in potswithimages)
                {
                    Console.WriteLine("AAA::" + p.pot.Name + " " + p.File);
                }
                
            }

                Console.ReadLine();
        }
    }
}
