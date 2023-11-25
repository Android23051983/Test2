using System;
using System.Collections.Generic;

namespace Team_project.Model;

public partial class Book : Notify
{
    public int BookId { get; set; }

    public string title;
    public string description;
    public string Title 
    {
        get {  return title; } 
        set { title = value; OnPropertyChanged("Title"); }
    }

    public string? Description 
    {
        get { return description; } 
        set { description = value; OnPropertyChanged("Description"); }
    }

    public int? AuthorFk { get; set; }

    public int? CategoryFk { get; set; }

    public virtual Author? AuthorFkNavigation { get; set; }

    public virtual Category? CategoryFkNavigation { get; set; }
}
