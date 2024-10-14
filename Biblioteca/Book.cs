using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace Biblioteca
{
    public class Book
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool? IsLoan { get; set; }
        public DateTime? LoanReturn { get; set; }

        private static List<Book> books = new List<Book>();

        private static int nextId = 1;

        public static void AddBooks()
        {
            bool continuee = true;
            Console.WriteLine("Vamos Adicionar um livro então");
            while (continuee)
            {
                Book book = new Book();

                book.Id = nextId;
                nextId++; 

                Console.WriteLine("\nQual nome do seu Livro: ");
                book.Name = Console.ReadLine();

                Console.WriteLine("\nQual Autor do seu Livro: ");
                book.Author = Console.ReadLine();

                Console.WriteLine("Adicionando Livro !!!");
                books.Add(book); 
                Console.WriteLine($"\nO livro {book.Name} foi adicionado com sucesso com o Id {book.Id}");
                continuee = false;
            }
        }

        public static void LoanBook(int bookId)
        {
            foreach (Book book in books) 
            {
              if (book.Id == bookId)
              {
                Console.WriteLine("O livro vai ser emprestado até qual data: Use xx/xx/xxxx\n:");
                var loan = Convert.ToDateTime(Console.ReadLine());

                if (loan < DateTime.Now)
                {
                  Console.WriteLine("\n-------A data do empréstimo deve ser maior que a data atual-------");
                }

                book.LoanReturn = loan;
                book.IsLoan = true;

                Console.WriteLine($"\nLivro Emprestado até {loan.ToString()}");
                break;
              }
            }
        }

        public static void ReturnBook(int bookId)
        {
            foreach(Book book in books)
            {
                if(book.Id == bookId)
                {
                    if(book.IsLoan == null || book.IsLoan == false)
                    {
                        Console.WriteLine("Esse Livro nunca foi emprestado !!");
                    }
                    else
                    {
                        book.IsLoan = false;
                        book.LoanReturn = null;

                        Console.WriteLine($"\nLivro {book.Name} Devolvido com Sucesso !!!\n");
                    }
                }
            }
        }

        public static void ListLoanBooks()
        {
            Console.WriteLine("\nLivros Emprestados:\n");

            IEnumerable<Book> searchLoanBooks = books;

            searchLoanBooks = from book in books
                              where book.LoanReturn != null
                              select book;

            foreach (Book book in searchLoanBooks)
            {
                Console.WriteLine($"ID: {book.Id}, Nome: {book.Name}, Autor: {book.Author}, Data de Retorno: {book.LoanReturn}");
            }
        }

        public static void ListBooks()
        {
            Console.WriteLine("\nLista de livros na biblioteca:");
            foreach (Book book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Nome: {book.Name}, Autor: {book.Author}, Emprestado: {(book.IsLoan.HasValue && book.IsLoan.Value ? "Sim" : "Não")}, Data de Retorno: {(book.LoanReturn.HasValue ? book.LoanReturn.Value.ToString("dd/MM/yyyy") : "Não emprestado")}");
            }
        }

        public static void EraseBooks(int bookId)
        {
            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    Console.WriteLine($"Livro {book.Name} Removido com sucesso !!!");
                    books.Remove(book);
                    break;
                }
            }
        }
        public static void LoadBooks()
        {
            Book book1 = new Book { Id = nextId++, Name = "The Silent Forest", Author = "Jane Doe", IsLoan = true };
            Book book2 = new Book { Id = nextId++, Name = "Ocean Waves", Author = "John Smith" };
            Book book3 = new Book { Id = nextId++, Name = "Mystery at the Manor", Author = "Emma Brown" };
            Book book4 = new Book { Id = nextId++, Name = "The Great Adventure", Author = "Chris Johnson" };
            Book book5 = new Book { Id = nextId++, Name = "Under the Stars", Author = "Alex Lee" };

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
        }
    }
}
