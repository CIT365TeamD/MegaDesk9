using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaDesk9Group.Models;

namespace MegaDesk9Group.Data
{
    public class DbInitializer
    {
        public static void Initialize(MegaDesk9GroupContext context)
        {
            if (context.DeskQuote.Any())
            {
                return; // DB already seeded
            }

            var deskquotes = new DeskQuote[]
            {
                new DeskQuote{FirstName="Aaron", LastName="Abernathy", QuoteDate=DateTime.Parse("2015-09-21"),RushOrder=3,Width=96,Depth=24,DrawerCount=2,SurfaceMaterial=Material.Oak},
                new DeskQuote{FirstName="Betty", LastName="Boop", QuoteDate=DateTime.Parse("2012-05-11"),RushOrder=5,Width=24,Depth=35,DrawerCount=0,SurfaceMaterial=Material.Pine},
                new DeskQuote{FirstName="Cameron", LastName="Cooper", QuoteDate=DateTime.Parse("2018-08-09"),RushOrder=7,Width=50,Depth=29,DrawerCount=5,SurfaceMaterial=Material.Laminate},
                new DeskQuote{FirstName="David", LastName="Dresen", QuoteDate=DateTime.Parse("2010-11-29"),Width=83,Depth=25,DrawerCount=7,SurfaceMaterial=Material.Rosewood},
                new DeskQuote{FirstName="Emma", LastName="Eager", QuoteDate=DateTime.Parse("2010-12-24"),RushOrder=3,Width=28,Depth=48,DrawerCount=1,SurfaceMaterial=Material.Veneer},
                new DeskQuote{FirstName="Fred", LastName="Fox", QuoteDate=DateTime.Parse("2017-02-06"),Width=90,Depth=45,DrawerCount=6,SurfaceMaterial=Material.Pine},
                new DeskQuote{FirstName="George", LastName="Gunther", QuoteDate=DateTime.Parse("2015-08-16"),RushOrder=5,Width=85,Depth=30,DrawerCount=3,SurfaceMaterial=Material.Veneer},
                new DeskQuote{FirstName="Heidi", LastName="Hatch", QuoteDate=DateTime.Parse("2009-03-05"),RushOrder=7,Width=75,Depth=31,DrawerCount=6,SurfaceMaterial=Material.Laminate},
                new DeskQuote{FirstName="Jacob", LastName="Jordan", QuoteDate=DateTime.Parse("2016-09-30"),RushOrder=3,Width=92,Depth=27,DrawerCount=0,SurfaceMaterial=Material.Oak},
                new DeskQuote{FirstName="Kyle", LastName="Kelly", QuoteDate=DateTime.Parse("2018-04-12"),Width=28,Depth=36,DrawerCount=4,SurfaceMaterial=Material.Pine},
                new DeskQuote{FirstName="Lizzy", LastName="Long", QuoteDate=DateTime.Parse("2012-11-01"),RushOrder=5,Width=38,Depth=28,DrawerCount=3,SurfaceMaterial=Material.Rosewood},
                new DeskQuote{FirstName="Martha", LastName="Mason", QuoteDate=DateTime.Parse("2011-05-08"),RushOrder=7,Width=54,Depth=46,DrawerCount=6,SurfaceMaterial=Material.Oak},
            };
            foreach (DeskQuote d in deskquotes)
            {
                context.DeskQuote.Add(d);
            }
            context.SaveChanges();
        }
    }
}
