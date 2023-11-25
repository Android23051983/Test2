using System;
using System.Collections.Generic;

namespace Team_project.Model;

public partial class Category : Notify
{
    public int CategoryId { get; set; }

    public string categoryName;


    public string CategoryName 
    {
        get {  return categoryName; } 
        set { categoryName = value; OnPropertyChanged("CategoryName"); }
    }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
