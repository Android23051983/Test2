using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Team_project.Model;

namespace Team_project.ViewModel
{
    public class MainWindowViewModel : Notify
    {
        DbbooksContext db = new DbbooksContext();
       
        public ObservableCollection<Book> BooksObserv { get; set; }

        public Book? selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }               
        }
        public MainWindowViewModel()
        {
            db.Database.EnsureCreated();
            db.Books.Load();
            db.Authors.Load();
            db.Categories.Load();
            BooksObserv = db.Books.Local.ToObservableCollection();
        }

        private void AddMethod()
        {
            db.SaveChanges();
        }

        private void DeleteMethod()
        {
            Book? book = SelectedBook as Book;
            db.Books.Remove(book);
            db.SaveChanges();
        }

        private void UpdateMethod() 
        {
            Book? book = SelectedBook as Book;
            //if (book is null) return;
            book.Title = SelectedBook.Title;
            book.Description = SelectedBook.Description;
            book.AuthorFkNavigation.FirstName = SelectedBook.AuthorFkNavigation.FirstName;
            book.AuthorFkNavigation.LastName = SelectedBook.AuthorFkNavigation.LastName;
            book.CategoryFkNavigation.CategoryName = SelectedBook.CategoryFkNavigation.CategoryName;
            db.Books.UpdateRange(book);
            db.SaveChanges();
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? new RelayCommand(obj => { AddMethod(); });
            }
        }

        private RelayCommand deleteComand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteComand ?? new RelayCommand(obj => { DeleteMethod(); });
            }
        }

        private RelayCommand updateComand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateComand ?? new RelayCommand(obj => { UpdateMethod(); });
            }
        }
    }
}
