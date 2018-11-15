using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk9Group.Models
{
    public enum Material
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125

    }
    public class DeskQuote
    {
        #region memberVariables
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 2), RegularExpression(@"[a-zA-z-]*$"), Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 2), RegularExpression(@"[a-zA-z-]*$"), Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        
        
        [Display(Name = "Quote Date"), DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
 
        [Range(1, 7)]
        [RegularExpression(@"[357]"), Display(Name ="Rush Order")]
        public int? RushOrder { get; set; }
        [Range(MIN_WIDTH, maximum: MAX_WIDTH)]
        public int Width { get; set; }

        [Range(MIN_DEPTH, maximum: MAX_DEPTH)]
        public int Depth { get; set; }

        [Range(0, MAX_DRAWERS), Display(Name ="Drawer Count")]
        public int DrawerCount { get; set; }

        [Display(Name ="Desk Surface")]
        [Required]
        public Material SurfaceMaterial { get; set; }
        [Display(Name = "Customer Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Display(Name ="Surface Area")]
        public int SurfaceArea
        {
            get
            {
                return Width * Depth;
            }
        }
        [Display(Name = "Quote Price")]
        public int QuoteAmount {
            get 
            {
                return CalculateQuotePrice();
            }
                }
       
        #endregion

        #region constants
        public const int MAX_WIDTH = 96;
        public const int MIN_WIDTH = 24;
        public const int MAX_DEPTH = 48;
        public const int MIN_DEPTH = 12;
        public const int MAX_DRAWERS = 7;
        private const int PRICE_BASE = 200;

        private const int PRICE_DRAWER = 50;
        private const int PRICE_SQ_FT = 1;
        private const int BASE_SIZE = 1000;
        private const int UPPER_SIZE = 2000;
        private readonly int[,] RUSH_FEE = new int[3, 3]
            {
                { 60, 70, 80 },
                { 40, 50, 60 },
                { 30, 35, 40 }
            };
        #endregion
       /* public DeskQuote(string firstName, string lastName, int width, int depth, int drawers, Material finish, int rushDays, DateTime date)
        {
            // save name and date to quote
            FirstName = firstName;
            LastName = lastName;
            QuoteDate = date;
            // save inputs to desk object
            Width = width;
            Depth = depth;
            DrawerCount = drawers;
            RushOrder = rushDays;
            //Desk.Finish = (Materials)Enum.Parse(typeof(Materials), finish);
            SurfaceMaterial = finish;




        }*/
       
        // calculate quote price
        public int CalculateQuotePrice()
        {
            int quotePrice = PRICE_BASE + SurfaceAreaCost() + DrawerCost() + (int)SurfaceMaterial + RushFee();
            return quotePrice;
        }

        // figure cost of surface area larger than 1000sf
        public int SurfaceAreaCost()
        {

            if (SurfaceArea > BASE_SIZE)
            {
                int surfaceCost = (SurfaceArea - BASE_SIZE) * PRICE_SQ_FT;
                return surfaceCost;
            }
            else
            {
                return 0;
            }
        }

        // calculate price of drawers
        public int DrawerCost()
        {
            int drawerPrice = DrawerCount * PRICE_DRAWER;
            return drawerPrice;
        }



        // calculate rush fee based on surface area and speed
        public int RushFee()
        {
            // set size index based on surface area
            int sizeIndex = 0;
            int rush = 0;
            if (SurfaceArea < BASE_SIZE)
            {
                sizeIndex = 0;
            }
            else if (SurfaceArea <= UPPER_SIZE)
            {
                sizeIndex = 1;
            }
            else
            {
                sizeIndex = 2;
            }
            // return rush fee based on sizeIndex and speed
            if (RushOrder == 3)
            {
                rush = RUSH_FEE[0, sizeIndex];

            }
            else if (RushOrder == 5)
            {
                rush = RUSH_FEE[1, sizeIndex];
            }
            else if (RushOrder == 7)
            {
                rush = RUSH_FEE[2, sizeIndex];
            }
            else
            {
                rush = 0;
            }
            return rush;
        }

    }
}
