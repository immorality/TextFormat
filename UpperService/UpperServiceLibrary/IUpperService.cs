using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UpperServiceLibrary
{
   
    [ServiceContract]
    public interface IUpperService
    {

        [OperationContract]
        string Upper(string str);

        [OperationContract]
        string Lower(string str);

        [OperationContract]
        string FirstLetterOfSentenceToUpper(string str);

        [OperationContract]
        string Refactor(string str, string before, string after);

        [OperationContract]
        string SpaceAfterPunctuationMark(string str);

        [OperationContract]
        string CountOfSymbols(string str);

        [OperationContract]
        string Remove(string str, string word);

        [OperationContract]
        string Capitalize(string str);

    }
}
