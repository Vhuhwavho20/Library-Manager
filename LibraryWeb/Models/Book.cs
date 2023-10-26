namespace LibraryWeb.Models;

//Book model for database
public class Book{

public int Id{get;set;}

public string? book_title{get;set;}

public string? book_author{get;set;}

public string? status {get;set;}

public int assigned_borrower {get;set;}


}