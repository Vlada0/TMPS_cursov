using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Model
{
    public class Product
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        // FK
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int StyleId { get; set; }
        public virtual Style Style { get; set; }


        public int ColorId { get; set; }
        public virtual ColorOption Color { get; set; }
        //public List<Color> AvailableColors { get; set; }
        ////private string availableColors;
        ////[NotMapped]
        ////public List<Color> AvailableColors
        ////{
        ////    get
        ////    {
        ////        if(availableColors != "")
        ////        return availableColors.Split(';').ToList().ConvertAll(str => Color.FromName(str));
        ////        return new List<Color>();
        ////    }
        ////    set { availableColors = string.Join($";", value); }
        ////}

        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        //public List<Material> AvailableMaterials { get; set; }
        ////private string availableMaterials;
        ////[NotMapped]
        ////public List<Material> AvailableMaterials
        ////{
        ////    get
        ////    {
        ////        if(availableMaterials != "")
        ////        return availableMaterials.Split(';').ToList()
        ////            .ConvertAll(str=> (Material)Enum.Parse(typeof(Material), str, true));
        ////        return new List<Material>();
        ////    }
                 
        ////    set { availableMaterials = string.Join($";", value);}
        ////}

        public int? CasingId { get; set; }
        public virtual CasingType Casing { get; set; }
        //public List<CasingType> AvailableCasings { get; set; }
        ////private string availableCasings;
        ////[NotMapped]
        ////public List<CasingType> AvailableCasings
        ////{
        ////    get
        ////    {
        ////        if(availableCasings !="")
        ////        return availableCasings.Split(';').ToList()
        ////          .ConvertAll(str => (CasingType)Enum.Parse(typeof(CasingType), str, true));
        ////        return new List<CasingType>();
        ////    }
        ////    set { availableCasings = string.Join($";", value); }
        ////}

        public int? WoodId { get; set; }
        public virtual Wood Wood { get; set; }

       

        public Product()
        {
            Name = "";
            CategoryId = -1;
            Image = "";
            Description = "";
            Price = 0;

            StyleId = 1;
            MaterialId = 1;
            ColorId = 1;
            WoodId = null;
            CasingId = null;

            //AvailableColors = new List<Color>();
            //AvailableMaterials = new List<Material>();
            //AvailableStyles = new List<Style>();
            //AvailableCasings = new List<CasingType>();

        }

        public Product(string name, int categoryId, string image, string description, int styleId, int colorId,
            int materialId, double price)
        {
            Name = name;
            CategoryId = categoryId;
            Image = image;
            Description = description;
            Price = price;

            StyleId = styleId;
            ColorId = colorId;
            MaterialId = materialId;
            CasingId = null;
            WoodId = null;

            //AvailableStyles = new List<int> { 1,2,3};
            //AvailableMaterials = new List<int>();
            //AvailableColors = new List<int>();
            //AvailableCasings = new List<int>();
        }

        // Pattern Prototype
        public Product(Product original)
        {
            Name = original.Name;
            CategoryId = original.CategoryId;
            Image = original.Image;
            Description = original.Description;
            Price = original.Price;

            StyleId = original.StyleId;
            ColorId = original.ColorId;
            MaterialId = original.MaterialId;
            CasingId = original.CasingId;
            WoodId = original.WoodId;

            //AvailableColors = new List<int>(original.AvailableColors);
            //AvailableMaterials = new List<int>(original.AvailableMaterials);
            //AvailableStyles = new List<int>(original.AvailableStyles);
            //AvailableCasings = new List<int>(original.AvailableCasings);
        }



        public virtual Product clone()
        {
            return new Product(this);
        }


        // pattern Decorator
        //execute()
        public virtual void addOption()
        {

        }
        public virtual void removeOption()
        {

        }
    }

    public class Style
    {
        public int StyleId { get; set; }
        public string Name { get; set; }
        //public List<Product> Products { get; set; }
        private readonly ObservableListSource<Product> products = new ObservableListSource<Product>();
        public virtual ObservableListSource<Product> Products { get { return products; } }

        public Style() { }
        public Style(string name)  { Name = name;  }
    }
    //public enum Style
    //{
    //    UNDEFINED,
    //    CLASSIC,
    //    MODERN,
    //    LOFT
    //}

    public class ColorOption
    {
        public int ColorOptionId { get; set; }
        public string Name { get; set; }
        //public List<Product> Products { get; set; }
        private readonly ObservableListSource<Product> products = new ObservableListSource<Product>();
        public virtual ObservableListSource<Product> Products { get { return products; } }

        public ColorOption() { }
        public ColorOption(string name) { Name = name; }
    }

    public class Material
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        //public List<Product> Products { get; set; }

        private readonly ObservableListSource<Product> products = new ObservableListSource<Product>();
        public virtual ObservableListSource<Product> Products { get { return products; } }

        public Material() { }
        public Material(string name) { Name = name; }

    }
    //public enum Material
    //{
    //    UNDEFINED,
    //    WOOD,
    //    METALL
    //}

    public class CasingType
    {
        public int CasingTypeId { get; set; }
        public string Name { get; set; }
        //public List<Product> Products { get; set; }
        private readonly ObservableListSource<Product> products = new ObservableListSource<Product>();
        public virtual ObservableListSource<Product> Products { get { return products; } }

        public CasingType() { }
        public CasingType(string name) { Name = name; }
    }
    //public enum CasingType
    //{
    //    UNDEFINED,
    //    LEATHER,
    //    TEXTILE,
    //    RATTAN,
    //}

    public class Wood
    {
        public int WoodId { get; set; }
        public string Name { get; set; }
        //public List<Product> Products { get; set; }
        private readonly ObservableListSource<Product> products = new ObservableListSource<Product>();
        public virtual ObservableListSource<Product> Products { get { return products; } }

        public Wood() { }
        public Wood(string name) { Name = name; }
    }
    //public enum Wood
    //{
    //    UNDEFINED,
    //    OAK,
    //    MAPLE,
    //    ASH,
    //}

    public class DoorsType
    {
        public int DoorsTypeId { get; set; }
        public string Name { get; set; }
        //public List<Product> Products { get; set; }
        private readonly ObservableListSource<Product> products = new ObservableListSource<Product>();
        public virtual ObservableListSource<Product> Products { get { return products; } }

        public DoorsType() { }
        public DoorsType(string name) { Name = name; }
    }
    //public enum DoorsTyp
    //{
    //    UNDEFINED,
    //    NORMAL,
    //    CUPE
    //}
}
