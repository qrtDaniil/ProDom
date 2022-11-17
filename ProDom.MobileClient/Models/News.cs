using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public List<string> ImageResourses { get; set; }
        public int ImageResoursesCount { get; set; }
        public string ImageHeader { get; set; }
        public string Created { get; set; }
    }
}
