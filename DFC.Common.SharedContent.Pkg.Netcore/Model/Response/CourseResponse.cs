using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.FindACourseClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class CourseResponse
    {
        public List<Course>? Courses { get; set; }
    }
}
