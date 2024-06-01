using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models;

public class Chapter : Base
{
            
            private string _name;
            public string Name
            {
                get { return _name;} 
                set { _name = value; }
            }
            
            private string _volume;
            public string Volume
            {
                get { return _volume; }
                set { _volume = value; }
            }
            
            private int _number;
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }
            
            private string _text;
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }
            
            private DateTime _dateUpload;
            [Column(TypeName = "date")]
            public DateTime DateUpload
            {
                get { return _dateUpload; }
                set { _dateUpload = value; }
            }
            
            [ForeignKey("BookId")]
            public Guid BookId { get; set; }
            
            
           
}