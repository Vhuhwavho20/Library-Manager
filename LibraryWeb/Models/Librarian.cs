using System.ComponentModel.DataAnnotations;
namespace LibraryWeb.Models;

public class Librarian{

public int librarian_id{get;set;}

[Required]
public string? fullname{get;set;}

public string? password {get;set;}

}