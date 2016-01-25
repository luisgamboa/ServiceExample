using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthorBookService" in both code and config file together.
[ServiceContract]
public interface IAuthorBookService
{
	[OperationContract]
	List<string> GetAuthors();
    [OperationContract]
    List<BookLite> GetBooks(string author);
}

[DataContract]
public class BookLite
{
    public string Title { set; get; }

    [DataMember]
    public string ISBN { set; get; }

    [DataMember]
    public string EntryDate { set; get; }

}
