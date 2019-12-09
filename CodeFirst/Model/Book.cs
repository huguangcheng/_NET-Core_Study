using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
//Annotations  注释，释文     Component

namespace Model
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "书名是必填项！")]
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        //virtual延迟装入特性，如果遇到关联数据尚未装入的情况下，ef会自动再向数据库
        //索取相关数据
        public virtual BookOrder BookOrder { get; set; }
        public virtual BookType BookType { get;set;}
    }

}
