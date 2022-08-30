using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Queries
{
    public class PagedResponse<T> 
        where T : class
        //*ovaj tip mora biti referencijalni - ne moze biti int ili struktura*// 
        //new()
        //taj tip mora imati podrazumevani konstruktor
    {
        //ukupan broj zapisa iz baze koji odgovaraju pretrazi
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
    }
}
