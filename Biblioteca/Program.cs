using Biblioteca;
using System.Data;
using System.Net.Http.Headers;

Book.LoadBooks();
var continuee = true;
while (continuee)
{
    Console.WriteLine("\nSistema de Biblioteca !!!");
    Console.WriteLine("\nO que você quer fazer:");
    Console.WriteLine("\n1. Adicionar Livro\n2. Listar Livros\n3. Livros Emprestados\n4. Emprestar Livro\n5. Devolver Livro\n6. Excluir Livro\n7. Sair");

    switch (Convert.ToInt32(Console.ReadLine()))
    {
        case 1:
            Book.AddBooks();
            break;
        case 2:
            Book.ListBooks();  
            break;
        case 3:
            Book.ListLoanBooks();
            break;
        case 4:
            Book.ListBooks();
            Console.WriteLine("\nQual Id do Livro que deseja Emprestar: ");
            Book.LoanBook(Convert.ToInt32(Console.ReadLine()));
            break;
        case 5:
            Book.ListLoanBooks();
            Console.WriteLine("\nQual é o Id do livro que deseja devolver: ");
            Book.ReturnBook(Convert.ToInt32(Console.ReadLine()));
            break;
        case 6:
            Book.ListBooks();
            Console.WriteLine("\nQual é o Id do livro que deseja excluir: ");
            Book.EraseBooks(Convert.ToInt32(Console.ReadLine()));
            break;
        case 7:
            continuee = false;
            break;
        default:
            Console.WriteLine("Entrada Inválida tente Novamente");
            break;
    }
}
