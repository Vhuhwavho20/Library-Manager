//Author: Vhuhwavho Mokoma
//Data: 12/10/2023

public class Book{
int book_id;
string book_title;
string book_author;
string status;

//Constructor for book object
public Book(int id,string title,string author,string sts){
    book_id = id;
    book_title = title;
    book_author = author;
    status = sts;

}

//Getters for Book class attributes

public int getID(){
    return book_id;
}

public string getTitle(){
    return book_title;
}

public int getAuthor(){
    return book_author;
}

public int getStatus(){
    return status;
}

}