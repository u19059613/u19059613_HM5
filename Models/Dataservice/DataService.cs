using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using u19059613_HW5.Models;
using System.Data.SqlClient;

namespace u19059613_HW5.Models.Dataservice
{
    public class DataService
    {
        private static DataService instance;
        public string connectionString;

        public static DataService getInstance()
        {
          
            if (instance == null )
            {
                instance = new DataService();
            }
            return instance;

        }

        public void setConnectionString(String Connectstr)
        {
            connectionString = Connectstr;
        }


        public List<Books> getBooks()
        {
            List<Books> books = new List<Books>();
            try
            {
                SqlConnection myCOnnection = new SqlConnection("Data source = C:\\Users\\27635\\Desktop\\School\\2022\\inf272\\HW2022\\HM5\\u19059613_HW5\\u19059613_HW5");
                    myCOnnection.Open();
                SqlCommand command = new SqlCommand("Select books.bookId as ID , books.name as bName, authors.name as bAuthor," +
                    " types.name as bType, books.pagecount as bPage_Count, books.point as bPoints" +
                    " from books inner join authors on authors.authorId = books.authorId " +
                    " inner join types on types.typeId = books.typeID", myCOnnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Books Bdata = new Books();
                        Bdata.ID = Convert.ToInt32(reader["ID"]);
                        Bdata.bName = reader["BookName"].ToString();
                        Bdata.bAuthor = reader["AuthorName"].ToString();
                        Bdata.bType = reader["TypeName"].ToString();
                        books.Add(Bdata);
                    }
                }
                myCOnnection.Close();
            }
            catch
            {

            }

            return books;
        }

        public List<booksdetails> getBorrows(studentID)
        {
            List<booksdetails> bookdata = new List<booksdetails>();
            try
            {
                SqlConnection myCOnnection = new SqlConnection("Data source = C:\\Users\\27635\\Desktop\\School\\2022\\inf272\\HW2022\\HM5\\u19059613_HW5\\u19059613_HW5");
                myCOnnection.Open();
                SqlCommand command = new SqlCommand("Select borrows.borrowId as BorrowID, borrows.takenDate as Take_Date, borrows.broughtDate as Brought_Date, students.name as Borrow_By " +
                    "from borrows inner join students on students.studentId = borrows.studentId", myCOnnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        booksdetails Bdetails = new booksdetails();
                        Bdetails.BorrowID = Convert.ToInt32(reader["ID"]);
                        Bdetails.Take_Date = Convert.ToDateTime(reader["TakenDate"]);
                        Bdetails.Brought_Date = Convert.ToDateTime(reader["BroughtDate"]);
                        Bdetails.Borrow_By = GetStudentById((int)reader["studentId"]);
                        bookdata.Add(Bdetails);
                    }
                }
                myCOnnection.Close();
            }
            catch
            {

            }

            return bookdata;
        }

        public List<Students> getStudents()
        {
            List<Students> Studentdata = new List<Students>();
            try
            {
                SqlConnection myCOnnection = new SqlConnection("Data source = C:\\Users\\27635\\Desktop\\School\\2022\\inf272\\HW2022\\HM5\\u19059613_HW5\\u19059613_HW5");
                myCOnnection.Open();
                SqlCommand command = new SqlCommand("Select students.studentId as StudentID, students.name as Sname,  students.surname as Ssurname, students.class as Sclass, students.points as Spoints" +
                    "from students", myCOnnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Students Sdetails = new Students();
                        Sdetails.StudentID = Convert.ToInt32(reader["StudentID"]);
                        Sdetails.Sname = (reader["StudentName"]).ToString();
                        Sdetails.Ssurname = (reader["StudentSurname"]).ToString();
                        Sdetails.Sclass = reader["StudentClass"].ToString();
                        Sdetails.Spoints = Convert.ToInt32(reader["StudentPoints"]);
                        Studentdata.Add(Sdetails);
                    }
                }
                myCOnnection.Close();
            }
            catch
            {

            }

            return Studentdata;
        }
    }
}