using System.ComponentModel.DataAnnotations;
namespace LibraryWeb.Models;

//Messages model for database
public class Messages{


public int Id{get;set;}

public string? msg{get;set;}

public string? sender{get;set;}

public int? borrower_id{get;set;}

}

