using System;
using System.Collections.Generic;

namespace Team_project.Model;

public partial class Author : Notify
{
    public int AuthorId { get; set; }
    public string firstName;
    private string lastName;

    public string FirstName 
    { 
        get {  return firstName; }
        set { firstName = value; OnPropertyChanged("FirstName"); }
    }

    public string LastName 
    {
        get { return lastName; }
        set { lastName = value; OnPropertyChanged("LastName"); }
    } 

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
