using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;



namespace EntityFramework.Models
{
    public class Book : Base
    {
        
        private string _name;
        public string Name
        {
            get { return _name;} 
            set { _name = value; }
        }
        
        private string _author;
        public string Author { get { return _author; } set { _author = value; } }
        
        private string _shortdesc;
        public string Shortdesc
        {
            get { return _shortdesc; }
            set { _shortdesc= value; }
        }
        
        private string _fulldesc;
        public string Fulldesc
        {
            get { return _fulldesc; }
            set { _fulldesc= value; }
        }
        
        private int _year;
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        
        private string _status;
        [AllowNull]
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        private double _rate;
        [AllowNull]
        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        
  
        
        private byte[] _img;
        public byte[] Img
        {
            get { return _img; }
            set { _img = value; }
        }
        private byte[] _imgBack;
        public byte[] ImgBack
        {
            get { return _imgBack; }
            set { _imgBack = value; }
        }

        public List<Genre> Genres { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}